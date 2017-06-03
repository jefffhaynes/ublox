using System.Collections.Generic;
using BinarySerialization;
using ublox.Core.Data;

namespace ublox.Core.Messages
{
    public class CfgMsg : CfgMsgPoll
    {
        [FieldCount(6)]
        public List<MessageRate> PortRates { get; set; }
    }
}
