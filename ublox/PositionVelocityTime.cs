using System;
using ublox.Data;
using ublox.Messages.Enums;

namespace ublox
{
    public class PositionVelocityTime
    {
        public DateTime DateTime { get; set; }
        public GnssFixType FixType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SatelliteCount { get; set; }
        public Distance Height { get; set; }
        public Distance HeightAboveMeanSeaLevel { get; set; }
        public Distance HorizontalAccuracyEstimate { get; set; }
        public Distance VerticalAccuracyEstimate { get; set; }
        public Velocity3 Velocity { get; set; }
        public Velocity GroundSpeed { get; set; }
        public double HeadingOfMotion { get; set; }
        public Velocity SpeedAccuracyEstimate { get; set; }
        public double HeadingAccuracyEstimate { get; set; }
        public double PositionDilutionOfPrecision { get; set; }
        public double HeadingOfVehicle { get; set; }
    }
}
