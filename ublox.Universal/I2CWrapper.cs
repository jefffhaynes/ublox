using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.I2c;
using ublox.Core;

// ReSharper disable InconsistentNaming

namespace ublox.Universal
{
    public class I2cWrapper : ISerialDevice
    {
        private readonly I2cDevice _i2cDevice;

        public I2cWrapper(I2cDevice i2cDevice)
        {
            _i2cDevice = i2cDevice;
        }

        public void Write(byte[] data)
        {
            _i2cDevice.Write(data);
            throw new System.NotImplementedException();
        }

        public Task<byte[]> ReadAsync(uint count, CancellationToken cancellationToken)
        {
            var data = new byte[count];
            _i2cDevice.Read(data);
            return Task.FromResult(data);
        }
    }
}
