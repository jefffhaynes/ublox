namespace ublox.Messages
{
    public class Ack : PacketPayload
    {
        public MessageId AcknowledgedMessage { get; set; }
    }
}
