using BinarySerialization;
using ublox.Messages;

namespace ublox
{
    public class PacketContent : PacketContentBase
    {
        [FieldLength("Length")]
        [Subtype("MessageId", MessageId.ACK_ACK, typeof(Ack))]
        [Subtype("MessageId", MessageId.ACK_NAK, typeof(Nak))]
        [Subtype("MessageId", MessageId.CFG_TP5, typeof(CfgTp5))]
        [Subtype("MessageId", MessageId.NAV_PVT, typeof(NavPvt))]
        public PacketPayload Payload { get; set; }
    }
}
