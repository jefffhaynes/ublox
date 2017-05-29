using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using ublox.Core;

namespace ublox.Universal
{
    public class SerialDeviceWrapper : ISerialDevice
    {
        private readonly SerialDevice _serialDevice;

        public SerialDeviceWrapper(SerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
        }

        public void Write(byte[] data)
        {
            using (var writer = new DataWriter(_serialDevice.OutputStream))
            {
                writer.WriteBytes(data);
                writer.StoreAsync().AsTask().Wait();
                writer.DetachStream();
            }
        }

        public async Task<byte[]> ReadAsync(uint count, CancellationToken cancellationToken)
        {
            //var data = new byte[count];
            //var buffer = data.AsBuffer();
            //await _serialDevice.InputStream.ReadAsync(buffer, count, InputStreamOptions.Partial).AsTask(cancellationToken)
            //    .ConfigureAwait(false);
            //return data;

            using (var reader = new DataReader(_serialDevice.InputStream))
            {
                var read = await reader.LoadAsync(count).AsTask(cancellationToken).ConfigureAwait(false);

                var data = new byte[read];
                reader.ReadBytes(data);
                reader.DetachStream();
                return data;
            }
        }
    }
}
