using System;
using BinarySerialization;

namespace ublox.Core.Data
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
