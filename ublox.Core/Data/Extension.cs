using BinarySerialization;

namespace ublox.Core.Data
{
    public class Extension
    {
        [SerializeAs(SerializedType.TerminatedString)]
        public string Value { get; set; }
    }
}
