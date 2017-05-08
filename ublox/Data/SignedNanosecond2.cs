using System;
using BinarySerialization;

namespace ublox.Data
{
    public class SignedNanosecond2
    {
        public short Value { get; set; }

        [Ignore]
        public TimeSpan Time
        {
            get => TimeSpan.FromTicks(Value * Constants.TicksPerNanosecond);
            set => Value = (short)(value.Ticks / (double)Constants.TicksPerNanosecond);
        }
    }
}
