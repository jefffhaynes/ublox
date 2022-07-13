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
        [FieldLength(nameof(Length))]
        [Subtype(nameof(MessageId), MessageId.ACK_ACK, typeof(Ack))]
        [Subtype(nameof(MessageId), MessageId.ACK_NAK, typeof(Nak))]
        [Subtype(nameof(MessageId), MessageId.MON_VER, typeof(MonVer))]
        [Subtype(nameof(MessageId), MessageId.MON_VER, typeof(MonVerPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype(nameof(MessageId), MessageId.CFG_PRT, typeof(CfgPrt))]
        [Subtype(nameof(MessageId), MessageId.CFG_MSG, typeof(CfgMsg))]
        [Subtype(nameof(MessageId), MessageId.CFG_MSG, typeof(CfgMsgPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype(nameof(MessageId), MessageId.CFG_TP5, typeof(CfgTp5))]
        [Subtype(nameof(MessageId), MessageId.NAV_PVT, typeof(NavPvt))]
        [Subtype(nameof(MessageId), MessageId.NAV_PVT, typeof(NavPvtPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype(nameof(MessageId), MessageId.NAV_ATT, typeof(NavAtt))]
        [Subtype(nameof(MessageId), MessageId.NAV_SAT, typeof(NavSat))]
        [Subtype(nameof(MessageId), MessageId.NAV_SAT, typeof(NavSatPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype(nameof(MessageId), MessageId.NAV_SVINFO, typeof(NavSvInfo))]
        [Subtype(nameof(MessageId), MessageId.NAV_SVINFO, typeof(NavSvInfoPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype(nameof(MessageId), MessageId.CFG_HNR, typeof(CfgHnr))]
        [Subtype(nameof(MessageId), MessageId.RXM_RAWX, typeof(RxmRawx))]
        [Subtype(nameof(MessageId), MessageId.HNR_PVT, typeof(HnrPvt))]
        [Subtype(nameof(MessageId), MessageId.HNR_PVT, typeof(HnrPvtPoll), BindingMode = BindingMode.OneWayToSource)]
        [Subtype(nameof(MessageId), MessageId.ESF_STATUS, typeof(EsfStatus))]
        [Subtype(nameof(MessageId), MessageId.ESF_STATUS, typeof(EsfStatusPoll), BindingMode = BindingMode.OneWayToSource)]
        public PacketPayload Payload { get; set; }
    }
}
