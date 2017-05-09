using System;
using System.Threading;
using System.Threading.Tasks;
using BinarySerialization;

namespace ublox
{
    public class Device : IDisposable
    {
        private static readonly BinarySerializer Serializer = new BinarySerializer();
        private readonly SemaphoreSlim _completionLock = new SemaphoreSlim(1);
        private readonly CancellationTokenSource _listenCancellationTokenSource = new CancellationTokenSource();
        private readonly ISerialDevice _serialDevice;
        private TaskCompletionSource<Packet> _commandCompletionSource;
        private MessageId? _expectedResponseId;

        public Device(ISerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
            Task.Run(() => ListenAsync());
        }

        public void Dispose()
        {
        }

        private async Task<PacketContent> SendAsync(PacketPayload payload, CancellationToken cancellationToken,
            MessageId? expectedResponseId = null)
        {
            var packet = new Packet
            {
                Content = new PacketContent
                {
                    Payload = payload
                }
            };

            using (var stream = new SerialDeviceStream(_serialDevice))
            {
                Serializer.Serialize(stream, packet);
            }

            try
            {
                await _completionLock.WaitAsync(cancellationToken);
                _commandCompletionSource = new TaskCompletionSource<Packet>();

                _expectedResponseId = expectedResponseId;
            }
            finally
            {
                _completionLock.Release();
            }

            var responsePacket = await _commandCompletionSource.Task;
            return responsePacket.Content;
        }

        private async void ListenAsync()
        {
            var cancellationToken = _listenCancellationTokenSource.Token;

            while (!cancellationToken.IsCancellationRequested)
            {
                using (var stream = new SerialDeviceStream(_serialDevice))
                {
                    var packet = await Serializer.DeserializeAsync<Packet>(stream, cancellationToken);

                    var messageId = packet.Content.MessageId;

                    try
                    {
                        await _completionLock.WaitAsync(cancellationToken);

                        if (messageId == MessageId.ACK_ACK || messageId == MessageId.ACK_NAK ||
                            messageId == _expectedResponseId)
                        {
                            // command response, dispatch to completion source
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