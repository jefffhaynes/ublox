using BinarySerialization;
using ublox.Core.Messages;

namespace ublox.Core
{
    public class PacketContent
    {
        [FieldOrder(0)]
        [FieldEndianness(Endianness.Big)]
        public MessageId MessageId { get; set; }

        [FieldOrder(1)]
        public ushort Length { get; set; }

        [FieldOrder(2)]
        [FieldLength("Length")]
        [Subtype("MessageId", MessageId.ACK_ACK, typeof(Ack))]
        [Subtype("MessageId", MessageId.ACK_NAK, typeof(Nak))]
        [Subtype("MessageId", MessageId.CFG_TP5, typeof(CfgTp5))]
        [Subtype("MessageId", MessageId.NAV_PVT, typeof(NavPvt))]
        [Subtype("MessageId", MessageId.NAV_PVT, typeof(NavPvtPoll), BindingMode = BindingMode.OneWay)]
        public PacketPayload Payload { get; set; }
    }
}
