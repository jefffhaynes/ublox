using ublox.Core.Data;
using ublox.Core.Messages;

namespace ublox.Core
{
    public class HighNavRatePositionVelocityTimeEventArgs : BasePositionVelocityTimeEventArgs
    {
        public HighNavRatePositionVelocityTimeEventArgs(HnrPvt hnrPvt) : base(hnrPvt)
        {
            Speed = hnrPvt.Speed;
        }

        public SignedVelocity Speed { get; }
    }
}
