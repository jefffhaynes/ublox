using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BinarySerialization;
using ublox.Core.Data;
using ublox.Core.Messages;
using ublox.Core.Messages.Enums;

#if DEBUG
using System.IO;
#endif

namespace ublox.Core
{
    public class Device : IDisposable
    {
        private static readonly BinarySerializer Serializer = new BinarySerializer();
        private readonly SemaphoreSlim _completionLock = new SemaphoreSlim(1);
        private readonly CancellationTokenSource _listenCancellationTokenSource = new CancellationTokenSource();
        private readonly ISerialDevice _serialDevice;
        private TaskCompletionSource<Packet> _commandCompletionSource;

        //private readonly TaskCompletionSource<bool> _protocolVersionTaskCompletionSource = new TaskCompletionSource<bool>();
        private const string ProtocolVersionExtensionPrefix = "PROTVER";

        public event EventHandler<RawPacketHandlerEventArgs> RawPacketHandler;

        public event EventHandler<HighNavRatePositionVelocityTimeEventargs> HighNavRatePositionVelocityTimeUpdated;
        public event EventHandler<PositionVelocityTimeEventArgs> PositionVelocityTimeUpdated;
        public event EventHandler<RawMeasurementDataEventArgs> RawDataProductVariantUpdated;

        public Device(ISerialDevice serialDevice)
        {
#if DEBUG
            Serializer.MemberDeserialized += OnMemberDeserialized;
            Serializer.MemberDeserializing += OnMemberDeserializing;
            Serializer.MemberSerialized += OnMemberSerialized;
            Serializer.MemberSerializing += OnMemberSerializing;
#endif

            _serialDevice = serialDevice;
        }

        public void Dispose()
        {
            _listenCancellationTokenSource.Cancel();
        }

        public async Task InitializeAsync()
        {
            await Task.Run(() => ListenAsync());
            await ConfigurePortAsync(UartPort.Uart1, 9600, PortInProtocols.Ubx, PortOutProtocols.Ubx);
        }

        public Task ConfigurePortAsync(UartPort port, uint baudRate, PortInProtocols inProtocols, PortOutProtocols outProtocols, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cfgPrt = new CfgPrt
            {
                Port = port,
                BaudRate = baudRate,
                InProtocols = inProtocols,
                OutProtocols = outProtocols,
                Mode = UartMode.EightBit | UartMode.OneStopBit | UartMode.NoParity
            };

            return CommandAsync(cfgPrt, cancellationToken);
        }

        public Task ConfigureHighNavigationRateAsync(byte rate, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cfgHnr = new  CfgHnr
            {
                NavRate = rate
            };

            return CommandAsync(cfgHnr, cancellationToken);
        }

        public Task ConfigureMessagesAsync(MessageId message, byte? i2CPeriod, byte? uart1Period, byte? uart2Period,
            byte? usbPeriod, byte? spiPeriod, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cfgMsg = new CfgMsg
            {
                MessageId = message,
                PortRates = new List<MessageRate>
                {
                    new MessageRate(i2CPeriod ?? 0),
                    new MessageRate(uart1Period ?? 0),
                    new MessageRate(uart2Period ?? 0),
                    new MessageRate(usbPeriod ?? 0),
                    new MessageRate(spiPeriod ?? 0),
                    new MessageRate(0)
                }
            };

            return CommandAsync(cfgMsg, cancellationToken);
        }

        public Task ConfigureMessagesAsync(MessageId message, byte? i2CPeriod, byte? uart1Period,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ConfigureMessagesAsync(message, i2CPeriod, uart1Period, null, null, null, cancellationToken);
        }

        private void PollVersion()
        {
            Poll(new MonVerPoll());
        }

        public void PollPositionVelocityTime()
        {
            Poll(new NavPvtPoll());
        }

        public void PollHighNavRatePositionVelocityTime()
        {
            Poll(new HnrPvtPoll());
        }

        private async Task CommandAsync(PacketPayload payload, CancellationToken cancellationToken)
        {
            await _completionLock.WaitAsync(cancellationToken).ConfigureAwait(false);

            _commandCompletionSource = new TaskCompletionSource<Packet>();

            try
            {
                var packet = new Packet
                {
                    Content = new PacketContent
                    {
                        Payload = payload
                    }
                };

                Send(packet);

                var responsePacket = await _commandCompletionSource.Task.ConfigureAwait(false);
                var messageId = responsePacket.Content.MessageId;

                if (messageId != MessageId.ACK_ACK)
                {
                    throw new InvalidOperationException($"Received {messageId}");
                }
            }
            finally
            {
                _completionLock.Release();
            }
        }

        private void Poll(PacketPayload packetPayload)
        {
            var packet = new Packet
            {
                Content = new PacketContent
                {
                    Payload = packetPayload
                }
            };

            Send(packet);
        }

        private void Send(Packet packet)
        {
#if DEBUG
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, Constants.SyncCharacters);
                Serializer.Serialize(stream, packet);

                var data = stream.ToArray();

                Debug.WriteLine($"Sending: {BitConverter.ToString(data)}");
            }
#endif

            using (var stream = new SerialDeviceStream(_serialDevice))
            {
                Serializer.Serialize(stream, Constants.SyncCharacters);
                Serializer.Serialize(stream, packet);
            }
        }

        private async void ListenAsync(bool once = false)
        {
            var cancellationToken = _listenCancellationTokenSource.Token;

            do
            {
                using (var stream = new SerialDeviceStream(_serialDevice))
                {
                    var sync1 = new byte[1];
                    var sync2 = new byte[1];

                    while (sync2[0] != 0x62)
                    {
                        while (sync1[0] != 0xb5)
                        {
                            await stream.ReadAsync(sync1, 0, sync1.Length, cancellationToken);
                        }

                        await stream.ReadAsync(sync2, 0, sync2.Length, cancellationToken);
                    }

                    Debug.WriteLine("Found sync");

                    var packet = await Serializer.DeserializeAsync<Packet>(stream, cancellationToken)
                        .ConfigureAwait(false);

                    Debug.WriteLine($"Recieved {packet.Content.MessageId}");

                    var messageId = packet.Content.MessageId;
                    switch (messageId)
                    {
                        case MessageId.ACK_ACK:
                        case MessageId.ACK_NAK:
                            _commandCompletionSource?.SetResult(packet);
                            break;

                        case MessageId.MON_VER:
                            {
                                var monVer = (MonVer)packet.Content.Payload;
                                var extensions = monVer.Extensions;
                                var protVerExtension =
                                    extensions.FirstOrDefault(
                                        extension => extension.Value.StartsWith(ProtocolVersionExtensionPrefix));

                                if (protVerExtension != null)
                                {
                                    var extensionParts = protVerExtension.Value.Split(' ');
                                    var protocolVersion = extensionParts[1];
                                    //_protocolVersionTaskCompletionSource.SetResult(true);
                                }

                                break;
                            }
                        case MessageId.RXM_RAWX:
                            {
                                RawDataProductVariantUpdated?.Invoke(this, new RawMeasurementDataEventArgs((RxmRawx)packet.Content.Payload));
                                break;
                            }

                        case MessageId.NAV_PVT:
                            {
                                PositionVelocityTimeUpdated?.Invoke(this,
                                    new PositionVelocityTimeEventArgs((NavPvt)packet.Content.Payload));

                                break;
                            }

                        case MessageId.HNR_PVT:
                            {
                                HighNavRatePositionVelocityTimeUpdated?.Invoke(this,
                                    new HighNavRatePositionVelocityTimeEventargs((HnrPvt)packet.Content.Payload));

                                break;
                            }
                    }
                    RawPacketHandler?.Invoke(this, new RawPacketHandlerEventArgs(messageId, packet.Content.Payload));
                }
            } while (!cancellationToken.IsCancellationRequested && !once);
        }

        private static void OnMemberSerializing(object sender, MemberSerializingEventArgs e)
        {
            Debug.WriteLine("S-Start: {0} @ {1}", e.MemberName, e.Offset);
        }

        private static void OnMemberSerialized(object sender, MemberSerializedEventArgs e)
        {
            var value = e.Value ?? "null";
            Debug.WriteLine("S-End: {0} ({1}) @ {2}", e.MemberName, value, e.Offset);
        }

        private static void OnMemberDeserializing(object sender, MemberSerializingEventArgs e)
        {
            Debug.WriteLine("D-Start: {0} @ {1}", e.MemberName, e.Offset);
        }

        private static void OnMemberDeserialized(object sender, MemberSerializedEventArgs e)
        {
            var value = e.Value ?? "null";
            Debug.WriteLine("D-End: {0} ({1}) @ {2}", e.MemberName, value, e.Offset);
        }
    }
}