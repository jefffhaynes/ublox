using System.Threading;
using System.Threading.Tasks;

namespace ublox.Core
{
    public interface ISerialDevice
    {
        void Write(byte[] data);
        Task<byte[]> ReadAsync(int count, CancellationToken cancellationToken);
    }
}
