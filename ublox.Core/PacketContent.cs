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
        [Subtype("MessageId", MessageId.MON_VER, typeof(MonVer))]
        [Subtype("MessageId", MessageId.MON_VER, typeof(MonVerPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype("MessageId", MessageId.CFG_PRT, typeof(CfgPrt))]
        [Subtype("MessageId", MessageId.CFG_MSG, typeof(CfgMsg))]
        [Subtype("MessageId", MessageId.CFG_MSG, typeof(CfgMsgPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype("MessageId", MessageId.CFG_TP5, typeof(CfgTp5))]
        [Subtype("MessageId", MessageId.NAV_PVT, typeof(NavPvt))]
        [Subtype("MessageId", MessageId.NAV_PVT, typeof(NavPvtPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype("MessageId", MessageId.NAV_ATT, typeof(NavAtt))]
        [Subtype("MessageId", MessageId.CFG_HNR, typeof(CfgHnr))]
        [Subtype("MessageId", MessageId.RXM_RAWX, typeof(RxmRawx))]
        [Subtype("MessageId", MessageId.HNR_PVT, typeof(HnrPvt))]
        [Subtype("MessageId", MessageId.HNR_PVT, typeof(HnrPvtPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype("MessageId", MessageId.ESF_STATUS, typeof(EsfStatus))]
        [Subtype("MessageId", MessageId.ESF_STATUS, typeof(EsfStatusPoll), BindingMode = BindingMode.OneWayToSource)]
        public PacketPayload Payload { get; set; }
    }
}
