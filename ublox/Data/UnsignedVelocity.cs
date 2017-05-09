using System;

namespace ublox.Data
{
    public class UnsignedVelocity : Velocity
    {
        public UnsignedVelocity()
        {
        }

        public UnsignedVelocity(double metersPerSecond) : base(metersPerSecond)
        {
        }

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
