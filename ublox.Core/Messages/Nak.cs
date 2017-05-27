namespace ublox.Core.Messages
{
    public class Nak : PacketPayload
    {
        public MessageId NotAcknowledgedMessage { get; set; }
    }
}
