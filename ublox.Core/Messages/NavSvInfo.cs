using BinarySerialization;
using System.Collections.Generic;
using ublox.Core.Data;

namespace ublox.Core.Messages
{
    public class SvInfo
    {
        [FieldOrder(0)]
        public byte Channel { get; set; }

        [FieldOrder(1)]
        public byte SvId { get; set; }

        [FieldOrder(2)]
        public byte Flags { get; set; }

        [FieldOrder(3)]
        public byte Quality { get; set; }

        [FieldOrder(4)]
        public byte CN0 { get; set; }

        [FieldOrder(5)]
        public sbyte Elevation { get; set; }

        [FieldOrder(6)]
        public short Azimuth { get; set; }

        [FieldOrder(7)]
        public int PseudorangeResidual { get; set; }
    }

    public class NavSvInfo : PacketPayload
    {
        [FieldOrder(0)]
        public GpsTimeOfWeek GpsTimeOfWeek { get; set; }

        [FieldOrder(1)]
        public byte ChannelCount { get; set; }

        [FieldOrder(2)]
        public byte Flags { get; set; }

        [FieldOrder(3)]
        public short Reserved { get; set; }

        [FieldOrder(4)]
        [FieldCount(nameof(ChannelCount))]
        public List<SvInfo> Satellites { get; set; }
    }
}
