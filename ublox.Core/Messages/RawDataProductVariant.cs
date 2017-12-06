using BinarySerialization;
using System.Collections.Generic;
using ublox.Core.Data;
using ublox.Core.Messages.Enums;

namespace ublox.Core.Messages
{
    public class RawDataProductVariant : PacketPayload
    {
        [FieldOrder(0)]
        [SerializeAs(SerializedType.Float8)]
        public double ReceiverTimeOfWeek { get; set; }

        [FieldOrder(1)]
        [SerializeAs(SerializedType.UInt2)]
        public int GpsWeekNumber { get; set; }

        [FieldOrder(2)]
        [SerializeAs(SerializedType.Int1)]
        public int GpsLeapSeconds { get; set; }

        [FieldOrder(3)]
        [SerializeAs(SerializedType.UInt1)]
        public int NumberOfMeasurements { get; set; }

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
        [SerializeAs(SerializedType.Float8)]
        public double PrMes { get; set; }

        [FieldOrder(1)]
        [SerializeAs(SerializedType.Float8)]
        public double CpMes { get; set; }

        [FieldOrder(2)]
        [SerializeAs(SerializedType.Float4)]
        public float DoMes { get; set; }

        [FieldOrder(3)]
        [SerializeAs(SerializedType.UInt1)]
        public uint GNSSId { get; set; }

        [FieldOrder(4)]
        [SerializeAs(SerializedType.UInt1)]
        public uint SvId { get; set; }

        [FieldOrder(5)]
        [SerializeAs(SerializedType.UInt1)]
        public uint Reserved { get; set; }

        [FieldOrder(6)]
        [SerializeAs(SerializedType.UInt1)]
        public uint FrequId { get; set; }

        [FieldOrder(7)]
        [SerializeAs(SerializedType.UInt2)]
        public uint LockTime { get; set; }

        [FieldOrder(8)]
        [SerializeAs(SerializedType.UInt1)]
        public uint Cno { get; set; }

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
        [SerializeAs(SerializedType.UInt1)]
        public uint TrkStat { get; set; }

        [FieldOrder(13)]
        [SerializeAs(SerializedType.UInt1)]
        public uint Reserved2 { get; set; }

    }
}
