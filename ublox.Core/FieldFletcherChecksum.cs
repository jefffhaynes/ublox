using System;
using BinarySerialization;

namespace ublox.Core
{
    public class FieldFletcherChecksum : FieldValueAttributeBase
    {
        class FletcherState
        {
            public int Sum1 { get; set; }
            public int Sum2 { get; set; }
        }

        public FieldFletcherChecksum(string valuePath) : base(valuePath)
        {
        }

        protected override object GetInitialState(BinarySerializationContext context)
        {
            return new FletcherState();
        }

        protected override object GetUpdatedState(object state, byte[] buffer, int offset, int count)
        {
            var fletcherState = (FletcherState) state;

            for (int i = offset; i < count; i++)
            {
                fletcherState.Sum1 += buffer[i];
                fletcherState.Sum2 += fletcherState.Sum1;
            }

            return fletcherState;
        }

        protected override object GetFinalValue(object state)
        {
            var fletcherState = (FletcherState) state;
            var a = fletcherState.Sum1 & 0xff;
            var b = fletcherState.Sum2 & 0xff;
            return BitConverter.ToUInt16(new[] { (byte)a, (byte)b }, 0);
        }
    }
}
