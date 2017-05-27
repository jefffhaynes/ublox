using System;

namespace ublox.Core.Data
{
    public class UnsignedDistance : Distance
    {
        public UnsignedDistance()
        {
        }

        public UnsignedDistance(double meters) : base(meters)
        {
        }

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
