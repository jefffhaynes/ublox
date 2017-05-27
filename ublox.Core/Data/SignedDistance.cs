using System;

namespace ublox.Core.Data
{
    public class SignedDistance : Distance
    {
        public SignedDistance()
        {
        }

        public SignedDistance(double meters) : base(meters)
        {
        }

        public int TotalMillimeters { get; set; }

        protected override double GetMillimeters()
        {
            return TotalMillimeters;
        }

        protected override void SetMillimeters(double millimeters)
        {
            TotalMillimeters = Convert.ToInt32(millimeters);
        }
    }
}
