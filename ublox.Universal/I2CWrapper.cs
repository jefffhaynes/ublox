using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.I2c;
using ublox.Core;

// ReSharper disable InconsistentNaming

namespace ublox.Universal
{
    /// <summary>
    /// A wrapper for the <see cref="I2cDevice">I2cDevice</see> class that can be used with the u-blox <see cref="Device">Device</see> class.
    /// </summary>
    public class I2cWrapper : ISerialDevice
    {
        private readonly I2cDevice _i2cDevice;

        /// <summary>
        /// Instantiates a new I2cWrapper.
        /// </summary>
        /// <param name="i2cDevice"></param>
        public I2cWrapper(I2cDevice i2cDevice)
        {
            _i2cDevice = i2cDevice;
        }

        /// <summary>
        /// Writes data to the I2C bus.
        /// </summary>
        /// <param name="data"></param>
        public void Write(byte[] data)
        {
            _i2cDevice.Write(data);
        }

        /// <summary>
        /// Reads data from the I2C bus.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<byte[]> ReadAsync(uint count, CancellationToken cancellationToken)
        {
            var data = new byte[count];
            _i2cDevice.Read(data);
            return Task.FromResult(data);
        }
    }
}
