using System;

namespace ublox.Messages
{
    [Flags]
    public enum TimepulseOptions : uint
    {
        None = 0x0,
        Active = 0x1,
        LockGpsFreq = 0x2,
        LockedOtherSet = 0x4,
        IsFrequency = 0x8,
        IsLength = 0x10,
        AlignToTopOfSecond = 0x20,
        InversePolarity = 0x40,
        GpsTime = 0x80
    }
}
