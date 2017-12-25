using System;
using ublox.Core.Data;
using ublox.Core.Messages;
using ublox.Core.Messages.Enums;

namespace ublox.Core
{
    public class BasePositionVelocityTimeEventArgs : EventArgs
    {
        internal BasePositionVelocityTimeEventArgs(NavPvt navPvt)
        {
            GpsTimeOfWeek = navPvt.GpsTimeOfWeek;
            DateTime = navPvt.UbloxDateTime.DateTime;
            FixType = navPvt.FixType;
            Flags = navPvt.Flags;
            Latitude = navPvt.Latitude;
            Longitude = navPvt.Longitude;
            Height = navPvt.Height;
            HeightAboveMeanSeaLevel = navPvt.HeightAboveMeanSeaLevel;
            HorizontalAccuracyEstimate = navPvt.HorizontalAccuracyEstimate;
            VerticalAccuracyEstimate = navPvt.VerticalAccuracyEstimate;
            GroundSpeed = navPvt.GroundSpeed;
            HeadingOfMotion = navPvt.HeadingOfMotion;
            SpeedAccuracyEstimate = navPvt.SpeedAccuracyEstimate;
            HeadingAccuracyEstimate = navPvt.HeadingAccuracyEstimate;
            HeadingOfVehicle = navPvt.HeadingOfVehicle;
        }

        internal BasePositionVelocityTimeEventArgs(HnrPvt hnrPvt)
        {
            GpsTimeOfWeek = hnrPvt.GpsTimeOfWeek;
            DateTime = hnrPvt.UbloxDateTime.DateTime;
            FixType = hnrPvt.FixType;
            Flags = hnrPvt.Flags;
            Latitude = hnrPvt.Latitude;
            Longitude = hnrPvt.Longitude;
            Height = hnrPvt.Height;
            HeightAboveMeanSeaLevel = hnrPvt.HeightAboveMeanSeaLevel;
            HorizontalAccuracyEstimate = hnrPvt.HorizontalAccuracyEstimate;
            VerticalAccuracyEstimate = hnrPvt.VerticalAccuracyEstimate;
            GroundSpeed = hnrPvt.GroundSpeed;
            HeadingOfMotion = hnrPvt.HeadingOfMotion;
            SpeedAccuracyEstimate = hnrPvt.SpeedAccuracyEstimate;
            HeadingAccuracyEstimate = hnrPvt.HeadingAccuracyEstimate;
            HeadingOfVehicle = hnrPvt.HeadingOfVehicle;
        }

        public GpsTimeOfWeek GpsTimeOfWeek { get; }
        public DateTime DateTime { get; }
        public GnssFixType FixType { get; }
        public byte Flags { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public Distance Height { get; }
        public Distance HeightAboveMeanSeaLevel { get; }
        public Distance HorizontalAccuracyEstimate { get; }
        public Distance VerticalAccuracyEstimate { get; }
        public Velocity GroundSpeed { get; }
        public double HeadingOfMotion { get; }
        public Velocity SpeedAccuracyEstimate { get; }
        public double HeadingAccuracyEstimate { get; }
        public double? HeadingOfVehicle { get; }
    }
}
