using BinarySerialization;

namespace ublox.Core.Messages
{
    public class CfgHnr : PacketPayload
    {
        [FieldOrder(0)]
        public byte NavRate { get; set; }

        [FieldOrder(1)]
        [FieldLength(3)]
        public byte[] Reserved { get; set; }
    }
}
