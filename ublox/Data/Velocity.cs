namespace ublox.Data
{
    public abstract class Velocity
    {
        protected abstract double GetMillimetersPerSecond();
        protected abstract void SetMillimetersPerSecond(double millimetersPerSecond);
    }
}
