using BinarySerialization;

namespace ublox.Core.Data
{
    public abstract class Distance
    {
        protected Distance()
        {
        }

        protected Distance(double meters)
        {
            TotalMeters = meters;
        }

        [Ignore]
        public double TotalMeters
        {
            get => GetMillimeters() / Constants.MillimetersPerMeter;
            set => SetMillimeters(value * Constants.MillimetersPerMeter);
        }

        protected abstract double GetMillimeters();
        protected abstract void SetMillimeters(double millimeters);
    }
}