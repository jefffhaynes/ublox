using System;
using ublox.Core.Data;
using ublox.Core.Messages;
using ublox.Core.Messages.Enums;

namespace ublox.Core
{
    public class PositionVelocityTimeEventArgs : EventArgs
    {
        internal PositionVelocityTimeEventArgs(NavPvt navPvt)
        {
            DateTime = navPvt.UbloxDateTime.DateTime;
            FixType = navPvt.FixType;
            Latitude = navPvt.Latitude;
            Longitude = navPvt.Longitude;
            SatelliteCount = navPvt.SatelliteCount;
            Height = navPvt.Height;
            HeightAboveMeanSeaLevel = navPvt.HeightAboveMeanSeaLevel;
            HorizontalAccuracyEstimate = navPvt.HorizontalAccuracyEstimate;
            VerticalAccuracyEstimate = navPvt.VerticalAccuracyEstimate;
            Velocity = navPvt.Velocity;
            GroundSpeed = navPvt.GroundSpeed;
            HeadingOfMotion = navPvt.HeadingOfMotion;
            SpeedAccuracyEstimate = navPvt.SpeedAccuracyEstimate;
            HeadingAccuracyEstimate = navPvt.HeadingAccuracyEstimate;
            PositionDilutionOfPrecision = navPvt.PositionDilutionOfPrecision;
            HeadingOfVehicle = navPvt.HeadingOfVehicle;
        }

        public DateTime DateTime { get; }
        public GnssFixType FixType { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public int SatelliteCount { get; }
        public Distance Height { get; }
        public Distance HeightAboveMeanSeaLevel { get; }
        public Distance HorizontalAccuracyEstimate { get; }
        public Distance VerticalAccuracyEstimate { get; }
        public Velocity3 Velocity { get; }
        public Velocity GroundSpeed { get; }
        public double HeadingOfMotion { get; }
        public Velocity SpeedAccuracyEstimate { get; }
        public double HeadingAccuracyEstimate { get; }
        public double PositionDilutionOfPrecision { get; }
        public double HeadingOfVehicle { get; }
    }
}
