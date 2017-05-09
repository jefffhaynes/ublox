using BinarySerialization;

namespace ublox.Data
{
    public abstract class Velocity
    {
        protected Velocity()
        {
        }

        protected Velocity(double metersPerSecond)
        {
            MetersPerSecond = metersPerSecond;
        }

        [Ignore]
        public double MetersPerSecond
        {
            get => GetMillimetersPerSecond() / Constants.MillimetersPerMeter;
            set => SetMillimetersPerSecond(value * Constants.MillimetersPerMeter);
        }

        protected abstract double GetMillimetersPerSecond();
        protected abstract void SetMillimetersPerSecond(double millimetersPerSecond);
    }
}
