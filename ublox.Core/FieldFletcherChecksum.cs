using System;
using BinarySerialization;

namespace ublox.Core
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
                _sum1 = (_sum1 + buffer[i]) % byte.MaxValue;
                _sum2 = (_sum2 + _sum1) % byte.MaxValue;
            }
        }

        protected override object ComputeFinal()
        {
            return BitConverter.ToUInt16(new[] {(byte)_sum1, (byte)_sum2}, 0);
        }
    }
}
