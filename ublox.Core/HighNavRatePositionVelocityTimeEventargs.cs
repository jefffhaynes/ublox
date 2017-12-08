using ublox.Core.Data;
using ublox.Core.Messages;

namespace ublox.Core
{
    public class HighNavRatePositionVelocityTimeEventArgs : BasePositionVelocityTimeEventArgs
    {
        internal HighNavRatePositionVelocityTimeEventArgs(HnrPvt hnrPvt) : base(hnrPvt)
        {
            Speed = hnrPvt.Speed;
        }

        public SignedVelocity Speed { get; }
    }
}
