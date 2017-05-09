using BinarySerialization;
using ublox.Messages;

namespace ublox
{
    public class PacketContent
    {
        [FieldOrder(1)]
        [FieldEndianness(Endianness.Big)]
        public MessageId MessageId { get; set; }

        [FieldOrder(2)]
        public ushort Length { get; set; }

        [FieldOrder(3)]
        [FieldLength("Length")]
        [Subtype("MessageId", MessageId.ACK_ACK, typeof(Ack))]
        [Subtype("MessageId", MessageId.ACK_NAK, typeof(Nak))]
        [Subtype("MessageId", MessageId.CFG_TP5, typeof(CfgTp5))]
        [Subtype("MessageId", MessageId.NAV_PVT, typeof(NavPvt))]
        public PacketPayload Payload { get; set; }
    }
}
