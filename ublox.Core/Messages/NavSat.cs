using BinarySerialization;
using System.Collections.Generic;
using ublox.Core.Data;

namespace ublox.Core.Messages
{
    public class SatelliteDetail
    {
        [FieldOrder(0)]
        public byte GnssId { get; set; }

        [FieldOrder(1)]
        public byte SvId { get; set; }

        [FieldOrder(2)]
        public byte CN0 { get; set; }

        [FieldOrder(3)]
        public sbyte Elevation { get; set; }

        [FieldOrder(4)]
        public short Azimuth { get; set; }

        [FieldOrder(5)]
        [FieldScale(10)]
        public short PseudorangeResidual { get; set; }

        [FieldOrder(6)]
        public int Flags { get; set; }
    }

    public class NavSat : PacketPayload
    {
        [FieldOrder(0)]
        public GpsTimeOfWeek GpsTimeOfWeek { get; set; }

        [FieldOrder(1)]
        public byte Version { get; set; }
        
        [FieldOrder(2)]
        public byte SatelliteCount { get; set; }

        [FieldOrder(3)]
        public short Reserved { get; set; }

        [FieldOrder(4)]
        [FieldCount(nameof(SatelliteCount))]
        public List<SatelliteDetail> Satellites { get; set; }
    }
}
