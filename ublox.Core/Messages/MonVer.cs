using System.Collections.Generic;
using BinarySerialization;
using ublox.Core.Data;

namespace ublox.Core.Messages
{
    internal class MonVer : PacketPayload
    {
        [FieldOrder(0)]
        [FieldLength(30)]
        public string SoftwareVersion { get; set; }

        [FieldOrder(1)]
        [FieldLength(10)]
        public string HardwareVersion { get; set; }
        
        [FieldOrder(2)]
        [ItemLength(30)]
        public List<Extension> Extensions { get; set; }
    }
}
