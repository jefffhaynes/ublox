using BinarySerialization;

namespace ublox.Core.Data
{
    public class SensorStatus
    {
        [FieldOrder(0)]
        public byte SensorStatus1 { get; set; }

        [FieldOrder(1)]
        public byte SensorStatus2 { get; set; }

        [FieldOrder(2)]
        public byte Frequency { get; set; }

        [FieldOrder(3)]
        public byte Faults { get; set; }
    }
}
