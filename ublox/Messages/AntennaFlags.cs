using System;

namespace ublox.Messages
{
    [Flags]
    public enum AntennaFlags : ushort
    {
        AntennaSupplyVoltageControlSignalEnable = 0x01,
        ShortCircuitDetectionEnable = 0x02,
        OpenCircuitDetectionEnable = 0x04,
        PowerDownAntennaSupplyOnShortCircuit = 0x08,
        RecoveryFromShortEnable = 0x10
    }
}
