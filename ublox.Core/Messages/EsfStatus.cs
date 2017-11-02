using BinarySerialization;
using ublox.Core.Data;
using ublox.Core.Messages.Enums;

namespace ublox.Core.Messages
{
    public class EsfStatus : PacketPayload
    {
        [FieldOrder(0)]
        public GpsTimeOfWeek GpsTimeOfWeek { get; set; }

        [FieldOrder(1)]
        public byte Version { get; set; }

        [FieldOrder(2)]
        [FieldLength(7)]
        public byte[] Reserved1 { get; set; }

        [FieldOrder(3)]
        public FusionMode FusionMode { get; set; }

        [FieldOrder(4)]
        [FieldLength(2)]
        public byte[] Reserved2 { get; set; }

        [FieldOrder(5)]
        public byte SensorCount { get; set; }

        [FieldOrder(6)]
        [FieldCount("SensorCount")]
        public SensorStatus[] Sensors { get; set; }
    }
}
