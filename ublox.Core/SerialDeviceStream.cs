using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ublox.Core
{
    public class SerialDeviceStream : Stream
    {
        private readonly ISerialDevice _serialDevice;

        public SerialDeviceStream(ISerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (offset != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), offset, "Must be zero.");
            }

            if (count != buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Must match buffer length.");
            }

            _serialDevice.Write(buffer);
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (offset != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), offset, "Must be zero.");
            }

            if (count != buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Must match buffer length.");
            }

            var data = await _serialDevice.ReadAsync((uint)count, cancellationToken);
            Array.Copy(data, buffer, data.Length);
            return data.Length;
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => true;
        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
    }
}
