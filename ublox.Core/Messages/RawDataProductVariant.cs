using BinarySerialization;
using System.Collections.Generic;
using ublox.Core.Data;
using ublox.Core.Messages.Enums;

namespace ublox.Core.Messages
{
    public class RawDataProductVariant : PacketPayload
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
        [FieldCount(3)]
        public byte[] Reserved { get; set; }

        [FieldOrder(6)]
        [FieldCount(nameof(NumberOfMeasurements))]
        public List<RawDataProductVariantMeasure> Measures { get; set; }
    }

    public class RawDataProductVariantMeasure
    {

        [FieldOrder(0)]
        public double PrMes { get; set; }

        [FieldOrder(1)]
        public double CpMes { get; set; }

        [FieldOrder(2)]
        public float DoMes { get; set; }

        [FieldOrder(3)]
        public byte GNSSId { get; set; }

        [FieldOrder(4)]
        public byte SvId { get; set; }

        [FieldOrder(5)]
        public byte Reserved { get; set; }

        [FieldOrder(6)]
        public byte FrequId { get; set; }

        [FieldOrder(7)]
        public ushort LockTime { get; set; }

        [FieldOrder(8)]
        public byte Cno { get; set; }

        [FieldOrder(9)]
        public byte PrStdev { get; set; }

        public double GetPrStdev()
        {
            return System.Math.Pow(2, PrStdev) * 0.01;
        }

        [FieldOrder(10)]
        public byte CpStdev { get; set; }

        public double GetCpStdev()
        {
            return CpStdev * 0.004;
        }

        [FieldOrder(11)]
        public byte DoStdev { get; set; }

        public double GetDoStdev()
        {
            return System.Math.Pow(2, DoStdev) * 0.02;
        }

        [FieldOrder(12)]
        public byte TrkStat { get; set; }

        [FieldOrder(13)]
        public byte Reserved2 { get; set; }

    }
}
