using System;
using BinarySerialization;

namespace ublox.Data
{
    public class GpsTimeOfWeek
    {
        public GpsTimeOfWeek()
        {
        }

        public GpsTimeOfWeek(TimeSpan timeOfWeek)
        {
            TimeOfWeek = timeOfWeek;
        }

        public uint Milliseconds { get; set; }

        [Ignore]
        public TimeSpan TimeOfWeek
        {
            get => TimeSpan.FromMilliseconds(Milliseconds);
            set => Milliseconds = (uint) value.TotalMilliseconds;
        }
    }
}
