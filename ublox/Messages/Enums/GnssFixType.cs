namespace ublox.Messages.Enums
{
    public enum GnssFixType : byte
    {
        NoFix = 0,
        DeadReckoning = 1,
        TwoD = 2,
        ThreeD = 3,
        GnssAndDeadReckoning = 4,
        TimeOnly = 5,
    }
}
