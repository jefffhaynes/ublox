using BinarySerialization;

namespace ublox.Core.Data
{
    public class Extension
    {
        [SerializeAs(SerializedType.NullTerminatedString)]
        public string Value { get; set; }
    }
}
