namespace ublox.Messages
{
    public class Nak : PacketPayload
    {
        public MessageId NotAcknowledgedMessage { get; set; }
    }
}
