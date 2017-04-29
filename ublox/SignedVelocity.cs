using System;

namespace ublox
{
    public class SignedVelocity : Velocity
    {
        public uint MillimetersPerSecond { get; set; }

        protected override double GetMillimetersPerSecond()
        {
            return MillimetersPerSecond;
        }

        protected override void SetMillimetersPerSecond(double millimetersPerSecond)
        {
            MillimetersPerSecond = Convert.ToUInt32(millimetersPerSecond);
        }
    }
}
