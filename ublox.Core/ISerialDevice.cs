using System.Threading;
using System.Threading.Tasks;

namespace ublox.Core
{
    public interface ISerialDevice
    {
        void Write(byte[] data);
        Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
    }
}
