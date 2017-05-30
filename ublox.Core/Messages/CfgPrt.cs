using BinarySerialization;
using ublox.Core.Messages.Enums;

namespace ublox.Core.Messages
{
    internal class CfgPrt : PacketPayload
    {
        [FieldOrder(0)]
        public UartPort Port { get; set; }

        [FieldOrder(1)]
        public byte Reserved { get; set; }

        [FieldOrder(2)]
        public ushort TxReady { get; set; }

        [FieldOrder(3)]
        public UartMode Mode { get; set; }

        [FieldOrder(4)]
        public uint BaudRate { get; set; }

        [FieldOrder(5)]
        public PortInProtocols InProtocols { get; set; }

        [FieldOrder(6)]
        public PortOutProtocols OutProtocols { get; set; }

        [FieldOrder(7)]
        public ushort Options { get; set; }

        [FieldOrder(8)]
        public ushort Reserved2 { get; set; } 
    }
}
