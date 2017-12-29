using System;
using ublox.Core.Data;
using ublox.Core.Messages;  

namespace ublox.Core
{
    public class PositionVelocityTimeEventArgs : BasePositionVelocityTimeEventArgs
    {
        internal PositionVelocityTimeEventArgs(NavPvt navPvt) : base(navPvt)
        {
            TimeAccuracy = navPvt.UbloxDateTime.TimeAccuracy;
            SatelliteCount = navPvt.SatelliteCount;
            Velocity = navPvt.Velocity;
            PositionDilutionOfPrecision = navPvt.PositionDilutionOfPrecision;
            Flags2 = navPvt.Flags2;
        }

        public TimeSpan TimeAccuracy { get; }
        public uint SatelliteCount { get; }
        public Velocity3 Velocity { get; }
        public double PositionDilutionOfPrecision { get; }
        public byte Flags2 { get; }
    }
}
