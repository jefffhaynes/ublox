namespace ublox.Core
{
    public class RawDataProductVariantMeasure
    {
        /// <summary>
        /// Pseudorange measurement [m]. GLONASS inter frequency channel delays are compensated with an internal calibration table.
        /// </summary>
        public double Pseudorange { get; }

        /// <summary>
        /// Carrier phase measurement [cycles]. The carrier phase initial ambiguity is initialized using an approximate value to make the magnitude of the phase close to the pseudorange measurement.Clock resets are applied to both phase and code measurements in accordance with the RINEX specification.
        /// </summary>
        public double CarrierPhaseMeasurement { get; }

        /// <summary>
        /// Doppler measurement (positive sign for approaching satellites) [Hz]
        /// </summary>
        public float DopplerMeasurement { get; }

        /// <summary>
        /// GNSS identifier (see Satellite Numbering for a list of identifiers)
        /// </summary>
        public byte GnssIdentifier { get; }

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

        public RawDataProductVariantMeasure(Messages.RxmRawxMeasurement m)
        {
            Pseudorange = m.PseudorangeMeasurement;
            CarrierPhaseMeasurement = m.CarrierPhaseMeasurement;
            DopplerMeasurement = m.DopplerMeasurement;
            GnssIdentifier = m.GnssId;
            SatelliteIdentifier = m.SatelliteId;

            FrequencyId = m.FrequencyId;
            CarrierPhaseLocktimeCounter = m.LockTime;
            CarrierToNoiseDensityRatio = m.CarrierToNoiseDensityRatio;
            EstimatedPseudorangeMeasurementStandardDeviation = m.PseudorangeMeasurementStandardDeviation;
            EstimatedCarrierPhaseMeasurementStandardDeviation = m.CarrierPhaseMeasurementStandardDeviation;
            EstimatedDopplerMeasurementStandardDeviation = m.DopplerMeasurementStandardDeviation;
        }
    }
}