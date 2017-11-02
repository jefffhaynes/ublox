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
        BadMeasurements = 1,

        /// <summary>
        /// Bad measurement time-tags detected
        /// </summary>
        BadTimeTags = 2,

        /// <summary>
        ///  Missing or time-misaligned measurements detected
        /// </summary>
        MissingMeasurements = 4,

        /// <summary>
        /// High measurement noise-level detected
        /// </summary>
        NoisyMeasurements = 8
    }
}