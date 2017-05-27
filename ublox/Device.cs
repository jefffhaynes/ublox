using System;
using System.Threading;
using System.Threading.Tasks;
using BinarySerialization;
using ublox.Messages;

namespace ublox
{
    public class Device : IDisposable
    {
        private static readonly BinarySerializer Serializer = new BinarySerializer();
        private readonly SemaphoreSlim _completionLock = new SemaphoreSlim(1);
        private readonly CancellationTokenSource _listenCancellationTokenSource = new CancellationTokenSource();
        private readonly ISerialDevice _serialDevice;
        private TaskCompletionSource<Packet> _commandCompletionSource;
        private MessageId _expectedMessageId;

        public Device(ISerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
            Task.Run(() => ListenAsync());
        }

        public void Dispose()
        {
            _listenCancellationTokenSource.Cancel();
        }

        public async Task<PositionVelocityTime> GetPositionVelocityTimeAsync(CancellationToken cancellationToken)
        {
            var navPvt = await PollAsync<NavPvt>(MessageId.NAV_PVT, cancellationToken).ConfigureAwait(false);
            return navPvt.GetPositionVelocityTime();
        }

        private async Task CommandAsync(PacketPayload payload, CancellationToken cancellationToken)
        {
            var packet = new Packet
            {
                Content = new PacketContent
                {
                    Payload = payload
                }
            };

            var response = await SendAsync(packet, cancellationToken).ConfigureAwait(false);

            if (response.MessageId != MessageId.ACK_ACK)
            {
                throw new InvalidOperationException($"Received {response.MessageId}");
            }
        }

        private async Task<TPacketPayload> PollAsync<TPacketPayload>(MessageId messageId, CancellationToken cancellationToken) where TPacketPayload : PacketPayload
        {
            var packet = new Packet
            {
                Content = new PacketContent
                {
                    MessageId = messageId
                }
            };

            var packetContent = await SendAsync(packet, cancellationToken);
            return packetContent.Payload as TPacketPayload;
        }

        private async Task<PacketContent> SendAsync(Packet packet, CancellationToken cancellationToken)
        {
            using (var stream = new SerialDeviceStream(_serialDevice))
            {
                Serializer.Serialize(stream, packet);
            }

            /* There is an intrinsic but probably (?) harmless race condition in the u-blox protocol.
             * As incoming messges could either be the result of polling or periodic reporting from
             * the device, we don't really know if what we're getting back is what we asked for or is
             * simply something similar that was already "in flight".  In practice, we probably don't 
             * care although it's possible (I don't know) that this could cause problems if the mistaken
             * response is answering a slightly different question than the one which was asked.  We 
             * lock to minimize the opportunity for the race condition to occur but it is impossible to 
             * completely prevent it as the incoming packets lack any sort of operation context.
            */
            try
            {
                await _completionLock.WaitAsync(cancellationToken).ConfigureAwait(false);
                _commandCompletionSource = new TaskCompletionSource<Packet>();

                // for non-polling operations MessageId will be zero, but that's ok
                _expectedMessageId = packet.Content.MessageId;
            }
            finally
            {
                _completionLock.Release();
            }

            var responsePacket = await _commandCompletionSource.Task.ConfigureAwait(false);
            return responsePacket.Content as PacketContent;
        }

        private async void ListenAsync()
        {
            var cancellationToken = _listenCancellationTokenSource.Token;

            while (!cancellationToken.IsCancellationRequested)
            {
                using (var stream = new SerialDeviceStream(_serialDevice))
                {
                    var packet = await Serializer.DeserializeAsync<Packet>(stream, cancellationToken)
                        .ConfigureAwait(false);

                    var messageId = packet.Content.MessageId;

                    try
                    {
                        await _completionLock.WaitAsync(cancellationToken);

                        if (messageId == MessageId.ACK_ACK || messageId == MessageId.ACK_NAK
                            || packet.Content.MessageId == _expectedMessageId)
                        {
                            _commandCompletionSource?.SetResult(packet);
                        }
                    }
                    finally
                    {
                        _completionLock.Release();
                    }
                }
            }
        }
    }
}