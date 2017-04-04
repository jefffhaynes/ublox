using BinarySerialization;

namespace ublox
{
    public class Packet
    {
        [FieldOrder(0)]
        public ushort SyncCharacters { get; set; }

        [FieldOrder(1)]
        [FieldCrc16("Crc")]
        public PacketContent Content { get; set; }

        [FieldOrder(2)]
        public ushort Crc { get; set; }
    }
}
