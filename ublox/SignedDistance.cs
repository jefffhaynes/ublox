using System;

namespace ublox
{
    public class SignedDistance : Distance
    {
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
