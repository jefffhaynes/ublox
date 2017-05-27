using System;

namespace ublox.Core.Messages.Enums
{
    [Flags]
    public enum AntennaOptions : ushort
    {
        None = 0x0,
        EnableAntennaSupplyVoltageControl = 0x1,
        EnableShortCircuitDetection = 0x2,
        EnableOpenCircuitDetection = 0x4,
        PowerDownAntennaOnShortCircuitDetection = 0x8,
        EnableAutoRecoveryFromShort = 0x10
    }
}
