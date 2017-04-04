using BinarySerialization;

namespace ublox
{
    public class PacketContent
    {
        [FieldOrder(1)]
        public MessageId MessageId { get; set; }

        [FieldOrder(2)]
        public ushort Length { get; set; }

        [FieldOrder(3)]
        [FieldLength("Length")]
        public Payload Payload { get; set; }
    }
}
