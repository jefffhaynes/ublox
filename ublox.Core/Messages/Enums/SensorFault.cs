using System;

namespace ublox.Core.Messages.Enums
{
    [Flags]
    public enum SensorFault : byte
    {        
        /// <summary>
        ///  No faults detected
        /// </summary>
        OK = 0,
    
        /// <summary>
        ///  Bad measurements detected
        /// </summary>
        badMeas = 1,

        /// <summary>
        /// Bad measurement time-tags detected
        /// </summary>
        badTTag = 2,

        /// <summary>
        ///  Missing or time-misaligned measurements detected
        /// </summary>
        missingMeas = 4,

        /// <summary>
        /// High measurement noise-level detected
        /// </summary>
        noisyMeas = 8
    }
}