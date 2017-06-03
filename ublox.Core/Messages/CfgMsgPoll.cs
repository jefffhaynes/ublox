using BinarySerialization;

namespace ublox.Core.Messages
{
    public class CfgMsgPoll : PacketPayload
    {
        [FieldEndianness(Endianness.Big)]
        public MessageId MessageId { get; set; }
    }
}
