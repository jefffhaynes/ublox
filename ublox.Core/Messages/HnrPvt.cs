using BinarySerialization;
using ublox.Core.Data;
using ublox.Core.Messages.Enums;

namespace ublox.Core.Messages
{
    public class HnrPvt : PacketPayload
    {
        [FieldOrder(0)]
        public GpsTimeOfWeek GpsTimeOfWeek { get; set; }

        [FieldOrder(1)]
        public UbloxDateTimeNoAccuracy UbloxDateTime { get; set; }

        [FieldOrder(2)]
        public GnssFixType FixType { get; set; }

        [FieldOrder(3)]
        public byte Flags { get; set; }

        [FieldOrder(4)]
        [FieldLength(2)]
        public byte[] Reserved1 { get; set; }

        [FieldOrder(5)]
        [FieldScale(10000000)]
        [SerializeAs(SerializedType.Int4)]
        public double Longitude { get; set; }

        [FieldOrder(6)]
        [FieldScale(10000000)]
        [SerializeAs(SerializedType.Int4)]
        public double Latitude { get; set; }

        [FieldOrder(7)]
        public SignedDistance Height { get; set; }

        [FieldOrder(8)]
        public SignedDistance HeightAboveMeanSeaLevel { get; set; }

        [FieldOrder(9)]
        public SignedVelocity GroundSpeed { get; set; }

        [FieldOrder(10)]
        public SignedVelocity Speed { get; set; }
        
        [FieldOrder(11)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.Int4)]
        public double HeadingOfMotion { get; set; }

        [FieldOrder(12)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.Int4)]
        public double HeadingOfVehicle { get; set; }

        [FieldOrder(13)]
        public UnsignedDistance HorizontalAccuracyEstimate { get; set; }

        [FieldOrder(14)]
        public UnsignedDistance VerticalAccuracyEstimate { get; set; }

        [FieldOrder(15)]
        public UnsignedVelocity SpeedAccuracyEstimate { get; set; }

        [FieldOrder(16)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.UInt4)]
        public double HeadingAccuracyEstimate { get; set; }
        
        [FieldOrder(17)]
        [FieldLength(4)]
        public byte[] Reserved2 { get; set; }
    }
}
