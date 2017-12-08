using BinarySerialization;
using System.Collections.Generic;

namespace ublox.Core.Messages
{
    public class RxmRawx : PacketPayload
    {
        [FieldOrder(0)]
        public double ReceiverTimeOfWeek { get; set; }

        [FieldOrder(1)]
        public ushort GpsWeekNumber { get; set; }

        [FieldOrder(2)]
        public byte GpsLeapSeconds { get; set; }

        [FieldOrder(3)]
        public byte NumberOfMeasurements { get; set; }

        [FieldOrder(4)]
        public byte ReceiverTrackingStatus { get; set; }

        [FieldOrder(5)]
        [FieldLength(3)]
        public byte[] Reserved { get; set; }

        [FieldOrder(6)]
        [FieldCount(nameof(NumberOfMeasurements))]
        public List<RxmRawxMeasurement> Measurements { get; set; }
    }
}
