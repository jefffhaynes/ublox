using System;
using ublox.Core.Data;
using ublox.Core.Messages;
using ublox.Core.Messages.Enums;

namespace ublox.Core
{
    public class HighNavRatePositionVelocityTimeEventargs : BasePositionVelocityTimeEventArgs
    {
        internal HighNavRatePositionVelocityTimeEventargs(HnrPvt hnrPvt) : base(hnrPvt)
        {
            Speed = hnrPvt.Speed;
        }

        public SignedVelocity Speed { get; }
    }
}
