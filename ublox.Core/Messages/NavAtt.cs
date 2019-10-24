using BinarySerialization;
using ublox.Core.Data;
using ublox.Core.Messages.Enums;

namespace ublox.Core.Messages
{
    public class NavAtt : PacketPayload
    {
        [FieldOrder(0)]
        public GpsTimeOfWeek GpsTimeOfWeek { get; set; }

        [FieldOrder(1)]
        public byte Version { get; set; }

        [FieldOrder(2)]
        [FieldLength(3)]
        public byte Reserved { get; set; }

        [FieldOrder(3)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.Int4)]
        public double Roll { get; set; }

        [FieldOrder(4)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.Int4)]
        public double Pitch { get; set; }

        [FieldOrder(5)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.Int4)]
        public double Heading { get; set; }

        [FieldOrder(6)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.UInt4)]
        public double AccuracyRoll { get; set; }

        [FieldOrder(7)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.UInt4)]
        public double AccuracyPitch { get; set; }

        [FieldOrder(8)]
        [FieldScale(100000)]
        [SerializeAs(SerializedType.UInt4)]
        public double AccuracyHeading { get; set; }
    }
}
