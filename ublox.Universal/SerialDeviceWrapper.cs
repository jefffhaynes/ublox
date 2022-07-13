using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using ublox.Core;

namespace ublox.Universal
{
    /// <summary>
    /// A wrapper for the <see cref="SerialDevice">SerialDevice</see> class that can be used with the u-blox <see cref="Device">Device</see> class.
    /// </summary>
    public class SerialDeviceWrapper : ISerialDevice
    {
        private readonly SerialDevice _serialDevice;

        /// <summary>
        /// Instantiates a new SerialDeviceWrapper.
        /// </summary>
        /// <param name="serialDevice"></param>
        public SerialDeviceWrapper(SerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
        }

        /// <summary>
        /// Writes data to the serial device.
        /// </summary>
        /// <param name="data"></param>
        public void Write(byte[] data)
        {
            using (var writer = new DataWriter(_serialDevice.OutputStream))
            {
                writer.WriteBytes(data);
                writer.StoreAsync().AsTask().Wait();
                writer.DetachStream();
            }
        }

        /// <summary>
        /// Reads data from the serial device.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<byte[]> ReadAsync(uint count, CancellationToken cancellationToken)
        {
            // needed because LoadAsync incorrectly completes sometimes
            var bufferStream = new MemoryStream();

            do
            {
                using (var reader = new DataReader(_serialDevice.InputStream))
                {
                    var read = await reader.LoadAsync(count - (uint)bufferStream.Length);

                    var data = new byte[read];
                    reader.ReadBytes(data);

                    await bufferStream.WriteAsync(data, 0, data.Length, cancellationToken);

                    if (bufferStream.Length < count)
                    {
                        await Task.Delay(100, cancellationToken);
                    }

                    reader.DetachStream();
                }
            } while (bufferStream.Length < count);

            return bufferStream.ToArray();
        }

        public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if(offset != 0)
            {
                throw new NotSupportedException();
            }

            if(count < 0)
            {
                throw new NotSupportedException();
            }

            var data = await ReadAsync((uint) count, cancellationToken);

            data.CopyTo(buffer, 0);

            return data.Length;
        }
    }
}
