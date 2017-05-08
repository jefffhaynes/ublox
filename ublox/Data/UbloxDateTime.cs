using System;
using BinarySerialization;

namespace ublox.Data
{
    public class UbloxDateTime
    {
        [FieldOrder(0)]
        public ushort Year { get; set; }

        [FieldOrder(1)]
        public byte Month { get; set; }

        [FieldOrder(2)]
        public byte Day { get; set; }

        [FieldOrder(3)]
        public byte Hour { get; set; }

        [FieldOrder(4)]
        public byte Minute { get; set; }

        [FieldOrder(5)]
        public byte Second { get; set; }

        [FieldOrder(6)]
        public byte ValidityFlags { get; set; }
        
        [FieldOrder(7)]
        public uint TimeAccuracy { get; set; }

        [FieldOrder(8)]
        public int Nanosecond { get; set; }

        public DateTime ToDateTime()
        {
            var dt = new DateTime(Year, Month, Day, Hour, Minute, Second);
            var ticks = Nanosecond * Constants.TicksPerNanosecond;
            return dt.AddTicks(ticks);
        }
    }
}
