using System;

namespace ublox.Core.Messages.Enums
{
    [Flags]
    public enum PortOutProtocols : ushort
    {
        Ubx = 0b00000001,
        Nmea = 0b00000010,
        Rtcm3 = 0b00010000,
    }
}
