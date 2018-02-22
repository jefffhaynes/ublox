using System;
using BinarySerialization;

namespace ublox.Core.Data
{
    public class SignedNanosecond2
    {
        public short Value { get; set; }

        [Ignore]
        public TimeSpan Time
        {
            get => TimeSpan.FromTicks(Value / Constants.NanosecondsPerTick);
            set => Value = (short)(value.Ticks * (double)Constants.NanosecondsPerTick);
        }
    }
}
