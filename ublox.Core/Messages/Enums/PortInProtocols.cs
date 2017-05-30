using System;

namespace ublox.Core.Messages.Enums
{
    [Flags]
    public enum PortInProtocols : ushort
    {
        Ubx = 0b00000001,
        Nmea = 0b00000010,
        Rtcm = 0b00000100,
        Rtcm3 = 0b00010000,
    }
}
