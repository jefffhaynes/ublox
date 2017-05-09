using BinarySerialization;

namespace ublox.Data
{
    public class Velocity3
    {
        public Velocity3()
        {
        }

        public Velocity3(double metersPerSecondNorth, double metersPerSecondEast, double metersPerSecondDown)
        {
            North = new SignedVelocity(metersPerSecondNorth);
            East = new SignedVelocity(metersPerSecondEast);
            Down = new SignedVelocity(metersPerSecondDown);
        }

        [FieldOrder(0)]
        public SignedVelocity North { get; set; }

        [FieldOrder(1)]
        public SignedVelocity East { get; set; }

        [FieldOrder(2)]
        public SignedVelocity Down { get; set; }
    }
}
