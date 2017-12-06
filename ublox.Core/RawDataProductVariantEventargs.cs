using System;
using System.Linq;
using ublox.Core.Data;

namespace ublox.Core
{
    public class RawDataProductVariantEventargs : EventArgs
    {
        /// <summary>
        /// Measurement time of week in receiver local time approximately aligned to the GPS time system.The receiver local time of week, week number and leap second information can be used to translate the time to other time systems.        /// More information about the difference in time systems can be found in RINEX 3 documentation.For a receiver operating in GLONASS only mode, UTC time can be determined by subtracting the leapS field from GPS time regardless of whether the GPS leap seconds are valid.        /// </summary>
        public double ReceiverTimeOfWeek { get; }

        /// <summary>
        /// GPS week number in receiver local time.
        /// </summary>
        public ushort GpsWeekNumber { get; }

        /// <summary>
        /// GPS leap seconds (GPS-UTC). This field represents the receiver's best knowledge of the leap seconds offset.A flag is given in the recStat bitfield to indicate if the leap seconds are known.
        /// </summary>
        public byte GpsLeapSeconds { get; }

        /// <summary>
        /// Receiver tracking status bitfield
        /// </summary>
        public byte ReceiverTrackingStatus { get; }

        public RawDataProductVariantMeasure[] Measures { get; }

        internal RawDataProductVariantEventargs(Messages.RawDataProductVariant p)
        {
            ReceiverTimeOfWeek = p.ReceiverTimeOfWeek;
            GpsWeekNumber = p.GpsWeekNumber;
            GpsLeapSeconds = p.GpsLeapSeconds;
            ReceiverTrackingStatus = p.ReceiverTrackingStatus;

            Measures = p.Measures.Select(m => new RawDataProductVariantMeasure(m)).ToArray();
        }

    }

    public class RawDataProductVariantMeasure
    {
        /// <summary>
        /// Pseudorange measurement [m]. GLONASS inter frequency channel delays are compensated with an internal calibration table.
        /// </summary>
        public double Pseudorange { get; }

        /// <summary>
        /// Carrier phase measurement [cycles]. The carrier phase initial ambiguity is initialized using an approximate value to make the magnitude of the phase close to the pseudorange measurement.Clock resets are applied to both phase and code measurements in accordance with the RINEX specification.        /// </summary>
        public double CarrierPhaseMeasurement { get; }

        /// <summary>
        /// Doppler measurement (positive sign for approaching satellites) [Hz]
        /// </summary>
        public float DopplerMeasurement { get; }

        /// <summary>
        /// GNSS identifier (see Satellite Numbering for a list of identifiers)
        /// </summary>
        public byte GNSSIdentifier { get; }

        /// <summary>
        /// Satellite identifier (see Satellite Numbering)
        /// </summary>
        public byte SatelliteIdentifier { get; }

        /// <summary>
        /// Only used for GLONASS: This is the frequency slot + 7 (range from 0 to 13)
        /// </summary>
        public byte FrequencyId { get; }

        /// <summary>
        /// Carrier phase locktime counter (maximum 64500ms)
        /// </summary>
        public ushort CarrierPhaseLocktimeCounter { get; }

        /// <summary>
        /// Carrier-to-noise density ratio (signal strength) [dB-Hz]
        /// </summary>
        public byte CarrierToNoiseDensityRatio { get; }

        /// <summary>
        /// Estimated pseudorange measurement standard deviation
        /// </summary>
        public byte EstimatedPseudorangeMeasurementStandardDeviation { get; }

        /// <summary>
        /// Estimated carrier phase measurement standard deviation(note a raw value of 0x0F indicates the value is invalid)
        /// </summary>
        public byte EstimatedCarrierPhaseMeasurementStandardDeviation { get; }

        /// <summary>
        /// Estimated Doppler measurement standard deviation.
        /// </summary>
        public byte EstimatedDopplerMeasurementStandardDeviation { get; }

        /// <summary>
        /// Tracking status bitfield
        /// </summary>
        public byte TrackingStatusBitfield { get; set; }

        internal RawDataProductVariantMeasure(Messages.RawDataProductVariantMeasure m)
        {
            Pseudorange = m.PrMes;
            CarrierPhaseMeasurement = m.CpMes;
            DopplerMeasurement = m.DoMes;
            GNSSIdentifier = m.GNSSId;
            SatelliteIdentifier = m.SvId;

            FrequencyId = m.FrequId;
            CarrierPhaseLocktimeCounter = m.LockTime;
            CarrierToNoiseDensityRatio = m.Cno;
            EstimatedPseudorangeMeasurementStandardDeviation = m.PrStdev;
            EstimatedCarrierPhaseMeasurementStandardDeviation = m.CpStdev;
            EstimatedDopplerMeasurementStandardDeviation = m.DoStdev;
        }
    }
}
