using BinarySerialization;

namespace ublox.Data
{
    public abstract class Distance
    {
        private const double MillimetersPerMeter = 1000;

        [Ignore]
        public double TotalMeters
        {
            get => GetMillimeters() / MillimetersPerMeter;
            set => SetMillimeters(value * MillimetersPerMeter);
        }

        protected abstract double GetMillimeters();
        protected abstract void SetMillimeters(double millimeters);
    }
}
