using System;

namespace ublox
{
    public class UnsignedDistance : Distance
    {
        public uint TotalMillimeters { get; set; }

        protected override double GetMillimeters()
        {
            return TotalMillimeters;
        }

        protected override void SetMillimeters(double millimeters)
        {
            TotalMillimeters = Convert.ToUInt32(millimeters);
        }
    }
}
