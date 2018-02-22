﻿using System;
using ublox.Core.Data;
using ublox.Core.Messages;  

namespace ublox.Core
{
    public class PositionVelocityTimeEventArgs : BasePositionVelocityTimeEventArgs
    {
        public PositionVelocityTimeEventArgs(NavPvt navPvt) : base(navPvt)
        {
            TimeAccuracy = navPvt.UbloxDateTime.TimeAccuracy;
            SatelliteCount = navPvt.SatelliteCount;
            Velocity = navPvt.Velocity;
            PositionDilutionOfPrecision = navPvt.PositionDilutionOfPrecision;
            Flags2 = navPvt.Flags2;
        }

        public byte Flags2 { get; }
        public TimeSpan TimeAccuracy { get; }
        public uint SatelliteCount { get; }
        public Velocity3 Velocity { get; }
        public double PositionDilutionOfPrecision { get; }
    }
}
