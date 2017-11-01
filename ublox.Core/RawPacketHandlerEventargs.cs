using System;
using ublox.Core.Data;
using ublox.Core.Messages;
using ublox.Core.Messages.Enums;

namespace ublox.Core
{
    public class RawPacketHandlerEventArgs : EventArgs
    {
        internal RawPacketHandlerEventArgs(MessageId messageId, PacketPayload packetPayload)
        {
            this.MessageId = messageId;
            this.PacketPayload = packetPayload;
        }
    
        public MessageId MessageId { get; }
        public PacketPayload PacketPayload { get; }
    }
}
