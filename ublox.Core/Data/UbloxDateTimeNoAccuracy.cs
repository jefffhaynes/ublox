using System;
using BinarySerialization;

namespace ublox.Core.Data
{
    public class UbloxDateTimeNoAccuracy
    {
        public UbloxDateTimeNoAccuracy()
        {
        }

        public UbloxDateTimeNoAccuracy(DateTime dateTime)
        {
            DateTime = dateTime;
        }

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
        public int Nanosecond { get; set; }

        [Ignore]
        public DateTime DateTime
        {
            get
            {
                var dt = new DateTime(Year, Month, Day, Hour, Minute, Second);
                var ticks = Nanosecond / Constants.NanosecondsPerTick;
                return dt.AddTicks(ticks);
            }

            set
            {
                Year = (ushort) value.Year;
                Month = (byte) value.Month;
                Day = (byte) value.Day;
                Hour = (byte) value.Hour;
                Minute = (byte) value.Minute;
                Second = (byte) value.Second;

                // ignore leap seconds so we don't break DateTime
                if (Second > 59)
                {
                    Second = 59;
                }

                var remainder = value - new DateTime(Year, Month, Day, Hour, Minute, Second);
                Nanosecond = (int) (remainder.Ticks * Constants.NanosecondsPerTick);
            }
        }
    }
}
