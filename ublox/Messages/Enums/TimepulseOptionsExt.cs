using System;

namespace ublox.Messages.Enums
{
    [Flags]
    public enum TimepulseOptionsExt : uint
    {
        None = 0x0,
        Active = 0x1,
        LockGnssFreq = 0x2,
        LockedOtherSet = 0x4,
        IsFrequency = 0x8,
        IsLength = 0x10,
        AlignToTopOfSecond = 0x20,
        InversePolarity = 0x40,
        GpsTime = 0x80,
        GlonassTime = 0x100,
        BeiDouTime = 0x200,
        GalileoTime = 0x400,
        SyncMode1 = 0x800
    }
}
