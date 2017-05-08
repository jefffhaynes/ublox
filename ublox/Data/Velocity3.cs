using BinarySerialization;

namespace ublox.Data
{
    public class Velocity3
    {
        [FieldOrder(0)]
        public SignedVelocity North { get; set; }

        [FieldOrder(1)]
        public SignedVelocity East { get; set; }

        [FieldOrder(2)]
        public SignedVelocity Down { get; set; }
    }
}
