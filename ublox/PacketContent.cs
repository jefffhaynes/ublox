using BinarySerialization;
using ublox.Messages;

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
        [Subtype("MessageId", MessageId.ACK_ACK, typeof(Ack))]
        [Subtype("MessageId", MessageId.ACK_NAK, typeof(Nak))]
        public Payload Payload { get; set; }
    }
}
