using System;
using System.Collections.Generic;
using System.Linq;
using ublox.Core.Messages;

namespace ublox.Core
{
    public class RawMeasurementDataEventArgs : EventArgs
    {
        public RawMeasurementDataEventArgs(RxmRawx rxmRawx)
        {
            ReceiverTimeOfWeek = rxmRawx.ReceiverTimeOfWeek;
            GpsWeekNumber = rxmRawx.GpsWeekNumber;
            GpsLeapSeconds = rxmRawx.GpsLeapSeconds;
            ReceiverTrackingStatus = rxmRawx.ReceiverTrackingStatus;

            Measurements = rxmRawx.Measurements.Select(m => new RawDataProductVariantMeasure(m)).ToList();
        }

        /// <summary>
        ///     Measurement time of week in receiver local time approximately aligned to the GPS time system.The receiver local
        ///     time of week, week number and leap second information can be used to translate the time to other time systems.
        ///     More information about the difference in time systems can be found in RINEX 3 documentation.For a receiver
        ///     operating in GLONASS only mode, UTC time can be determined by subtracting the leapS field from GPS time regardless
        ///     of whether the GPS leap seconds are valid.
        /// </summary>
        public double ReceiverTimeOfWeek { get; }

        /// <summary>
        ///     GPS week number in receiver local time.
        /// </summary>
        public ushort GpsWeekNumber { get; }

        /// <summary>
        ///     GPS leap seconds (GPS-UTC). This field represents the receiver's best knowledge of the leap seconds offset.A flag
        ///     is given in the recStat bitfield to indicate if the leap seconds are known.
        /// </summary>
        public byte GpsLeapSeconds { get; }

        /// <summary>
        ///     Receiver tracking status bitfield
        /// </summary>
        public byte ReceiverTrackingStatus { get; }

        public List<RawDataProductVariantMeasure> Measurements { get; }
    }
}