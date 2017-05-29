using System;
using ublox.Core.Data;
using ublox.Core.Messages;
using ublox.Core.Messages.Enums;
using Xunit;

namespace ublox.Test
{
    public class MessageTests : TestBase
    {
        [Fact]
        public void NavPvtPoll()
        {
            var navPvtPoll = new NavPvtPoll();
            Serialize(navPvtPoll, new byte[]{ 0xb5, 0x62, 0x01, 0x07, 0x00, 0x00, 0x08, 0x19 });
        }

        [Fact]
        public void NavPvt()
        {
            var navPvt = new NavPvt
            {
                GpsTimeOfWeek = new GpsTimeOfWeek(TimeSpan.FromDays(2)),
                UbloxDateTime = new UbloxDateTime(new DateTime(2017, 5, 29, 14, 44, 0, DateTimeKind.Utc)),
                FixType = GnssFixType.ThreeD,
                SatelliteCount = 4,
                Longitude = 45.234,
                Latitude = 38.2323,
                Height = new SignedDistance(674.3),
                HeightAboveMeanSeaLevel = new SignedDistance(645.34),
                HorizontalAccuracyEstimate = new UnsignedDistance(23.2),
                VerticalAccuracyEstimate = new UnsignedDistance(13.23),
                Velocity = new Velocity3(3.5, 6.76, 0.01),
                GroundSpeed = new SignedVelocity(5.332),
                HeadingOfMotion = 234.65,
                SpeedAccuracyEstimate = new UnsignedVelocity(1.13),
                HeadingAccuracyEstimate = 12.3,
                PositionDilutionOfPrecision = 0.5323,
                HeadingOfVehicle = 232.23
            };

            Serialize(navPvt,
                new byte[]
                {
                    0xb5, 0x62, 0x01, 0x07, 0x54, 0x00, 0x70, 0x30, 0x2e, 0x09, 0xe1, 0x07, 0x05, 0x08, 0x03, 0x05,
                    0x27, 0x00, 0x00, 0x00, 0x00, 0x00, 0x65, 0x01, 0x00, 0x00, 0x03, 0x00, 0x00, 0x04, 0x20, 0x29,
                    0xf6, 0x1a, 0x38, 0xc9, 0xc9, 0x16, 0xfc, 0x49, 0x0a, 0x00, 0xdc, 0xd8, 0x09, 0x00, 0xa0, 0x5a,
                    0x00, 0x00, 0xae, 0x33, 0x00, 0x00, 0xac, 0x0d, 0x00, 0x00, 0x68, 0x1a, 0x00, 0x00, 0x0a, 0x00,
                    0x00, 0x00, 0xd4, 0x14, 0x00, 0x00, 0x28, 0x0c, 0x66, 0x01, 0x6a, 0x04, 0x00, 0x00, 0xb0, 0xc4,
                    0x12, 0x00, 0x35, 0x00, 0x00, 0xd8, 0x5a, 0x62, 0x01, 0x00, 0xb2, 0x55
                });
        }
    }
}
