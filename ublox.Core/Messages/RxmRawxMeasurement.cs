using BinarySerialization;

namespace ublox.Core.Messages
{
    public class RxmRawxMeasurement
    {
        [FieldOrder(0)]
        public double PseudorangeMeasurement { get; set; }

        [FieldOrder(1)]
        public double CarrierPhaseMeasurement { get; set; }

        [FieldOrder(2)]
        public float DopplerMeasurement { get; set; }

        [FieldOrder(3)]
        public byte GnssId { get; set; }

        [FieldOrder(4)]
        public byte SatelliteId { get; set; }

        [FieldOrder(5)]
        public byte Reserved { get; set; }

        [FieldOrder(6)]
        public byte FrequencyId { get; set; }

        [FieldOrder(7)]
        public ushort LockTime { get; set; }

        [FieldOrder(8)]
        public byte CarrierToNoiseDensityRatio { get; set; }

        [FieldOrder(9)]
        public byte PseudorangeMeasurementStandardDeviation { get; set; }

        public double GetPseudorangeMeasurementStandardDeviation()
        {
            return System.Math.Pow(2, PseudorangeMeasurementStandardDeviation) * 0.01;
        }

        [FieldOrder(10)]
        public byte CarrierPhaseMeasurementStandardDeviation { get; set; }

        public double GetCarrierPhaseMeasurementStandardDeviation()
        {
            return CarrierPhaseMeasurementStandardDeviation * 0.004;
        }

        [FieldOrder(11)]
        public byte DopplerMeasurementStandardDeviation { get; set; }

        public double GetDopplerMeasurementStandardDeviation()
        {
            return System.Math.Pow(2, DopplerMeasurementStandardDeviation) * 0.02;
        }

        [FieldOrder(12)]
        public byte TrackingStatus { get; set; }

        [FieldOrder(13)]
        public byte Reserved2 { get; set; }
    }
}