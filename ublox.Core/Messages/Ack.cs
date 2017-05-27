namespace ublox.Core.Messages
{
    public class Ack : PacketPayload
    {
        public MessageId AcknowledgedMessage { get; set; }
    }
}
