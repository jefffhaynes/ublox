using System;

namespace ublox.Core.Messages.Enums
{
    [Flags]
    internal enum UartMode : uint
    {
        SixBit = 0b00_000_0_01000000,
        SevenBit = 0b00_000_0_10000000,
        EightBit = 0b00_000_0_11000000,
        OddParity = 0b00_001_0_00000000,
        NoParity = 0b00_100_0_00000000,
        OneStopBit = 0b00_000_0_00000000,
        OnePointFiveStopBit = 0b01_000_0_00000000,
        TwoStopBit = 0b10_000_0_00000000,
        PointFiveStopBit = 0b11_000_0_00000000,
        MysteryBit = 0b00_000_0_00010000
    }
}
