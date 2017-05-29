using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BinarySerialization;
using ublox.Core.Messages;

namespace ublox.Core
{
    public class Device : IDisposable
    {
        private static readonly BinarySerializer Serializer = new BinarySerializer();
        private readonly SemaphoreSlim _completionLock = new SemaphoreSlim(1);
        private readonly CancellationTokenSource _listenCancellationTokenSource = new CancellationTokenSource();
        private readonly ISerialDevice _serialDevice;
        private TaskCompletionSource<Packet> _commandCompletionSource;

        public event EventHandler<PositionVelocityTimeEventArgs> PositionVelocityTimeUpdated;
        
        public Device(ISerialDevice serialDevice)
        {
#if DEBUG
            Serializer.MemberDeserialized += OnMemberDeserialized;
            Serializer.MemberDeserializing += OnMemberDeserializing;
            Serializer.MemberSerialized += OnMemberSerialized;
            Serializer.MemberSerializing += OnMemberSerializing;
#endif

            _serialDevice = serialDevice;
            Task.Run(() => ListenAsync());
        }

        public void Dispose()
        {
            _listenCancellationTokenSource.Cancel();
        }

        public void PollPositionVelocityTime()
        {
            Poll(new NavPvtPoll());
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
            using (var stream = new SerialDeviceStream(_serialDevice))
            {
                Serializer.Serialize(stream, Constants.SyncCharacters);
                Serializer.Serialize(stream, packet);
            }
        }

        private async void ListenAsync()
        {
            var cancellationToken = _listenCancellationTokenSource.Token;

            while (!cancellationToken.IsCancellationRequested)
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

                    var packet = await Serializer.DeserializeAsync<Packet>(stream, cancellationToken)
                        .ConfigureAwait(false);

                    Debug.WriteLine($"Recieved {packet.Content.MessageId}");

                    var messageId = packet.Content.MessageId;

                    if (messageId == MessageId.ACK_ACK || messageId == MessageId.ACK_NAK)
                    {
                        _commandCompletionSource?.SetResult(packet);
                    }
                    else
                    {
                        switch (messageId)
                        {
                            case MessageId.NAV_PVT:
                            {
                                PositionVelocityTimeUpdated?.Invoke(this,
                                    new PositionVelocityTimeEventArgs(packet.Content.Payload as NavPvt));

                                break;
                            }
                        }
                    }
                }
            }
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