using System;
using BinarySerialization;

namespace ublox
{
    public class FieldFletcherChecksum : FieldValueAttributeBase
    {
        private int _sum1;
        private int _sum2;

        public FieldFletcherChecksum(string valuePath) : base(valuePath)
        {
        }

        protected override void Reset(BinarySerializationContext context)
        {
            _sum1 = 0;
            _sum2 = 0;
        }

        protected override void Compute(byte[] buffer, int offset, int count)
        {
            for (int i = offset; i < count; i++)
            {
                _sum1 = (_sum2 + buffer[i]) % byte.MaxValue;
                _sum2 = (_sum2 + _sum1) % byte.MaxValue;
            }
        }

        protected override object ComputeFinal()
        {
            var a = (byte)(byte.MaxValue - (_sum1 + _sum2) % byte.MaxValue);
            var b = (byte)(byte.MaxValue - (_sum1 + a) % byte.MaxValue);

            return BitConverter.ToUInt16(new[] {a, b}, 0);
        }
    }
}
