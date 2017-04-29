using BinarySerialization;

namespace ublox.Messages
{
    public class NavPvt : Payload
    {
        [FieldOrder(0)]
        public GpsTimeOfWeek GpsTimeOfWeek { get; set; }

        [FieldOrder(1)]
        public UbloxDateTime UbloxDateTime { get; set; }

        [FieldOrder(2)]
        public GnssFixType FixType { get; set; }

        [FieldOrder(3)]
        public byte Flags { get; set; }

        [FieldOrder(4)]
        public byte Flags2 { get; set; }

        [FieldOrder(5)]
        public byte SatelliteCount { get; set; }

        [FieldOrder(6)]
        [FieldScale(10000000)]
        [SerializeAs(SerializedType.Int4)]
        public double Longitude { get; set; }

        [FieldOrder(7)]
        [FieldScale(10000000)]
        [SerializeAs(SerializedType.Int4)]
        public double Latitude { get; set; }

        [FieldOrder(8)]
        public SignedDistance Height { get; set; }

        [FieldOrder(9)]
        public SignedDistance HeightAboveMeanSeaLevel { get; set; }

        [FieldOrder(10)]
        public UnsignedDistance HorizontalAccuracyEstimate { get; set; }

        [FieldOrder(11)]
        public UnsignedDistance VerticalAccuracyEstimate { get; set; }

        [FieldOrder(12)]
        public Velocity3 Velocity { get; set; }

        [FieldOrder(13)]
        public SignedVelocity GroundSpeed { get; set; }

        [FieldOrder(14)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.Int4)]
        public double HeadingOfMotion { get; set; }

        [FieldOrder(15)]
        public UnsignedVelocity SpeedAccuracyEstimate { get; set; }

        [FieldOrder(16)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.UInt4)]
        public double HeadingAccuracyEstimate { get; set; }

        [FieldOrder(17)]
        [FieldScale(100)]
        [SerializeAs(SerializedType.UInt2)]
        public double PositionDilutionOfPrecision { get; set; }

        [FieldOrder(18)]
        public byte Reserved1 { get; set; }
        
        [FieldOrder(19)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.Int4)]
        public double HeadingOfVehicle { get; set; }

        [FieldOrder(18)]
        public byte Reserved2 { get; set; }
    }
}
