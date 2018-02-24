using System;

namespace ublox.Core.Data
{
    public class SignedVelocity : Velocity
    {
        public SignedVelocity()
        {
        }

        public SignedVelocity(double metersPerSecond) : base(metersPerSecond)
        {
        }

        public int MillimetersPerSecond { get; set; }

        protected override double GetMillimetersPerSecond()
        {
            return MillimetersPerSecond;
        }

        protected override void SetMillimetersPerSecond(double millimetersPerSecond)
        {
            MillimetersPerSecond = Convert.ToInt32(millimetersPerSecond);
        }
    }
}
