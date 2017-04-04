namespace ublox.Messages
{
    public class Ack : Payload
    {
        public MessageId AcknowledgedMessage { get; set; }
    }
}
