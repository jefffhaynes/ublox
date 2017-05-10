using BinarySerialization;

namespace ublox
{
    public class PacketContentBase
    {
        [FieldOrder(0)]
        [FieldEndianness(Endianness.Big)]
        public MessageId MessageId { get; set; }

        [FieldOrder(1)]
        public ushort Length { get; set; }
    }
}
