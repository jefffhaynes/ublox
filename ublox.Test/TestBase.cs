using System;
using System.IO;
using System.Linq;
using BinarySerialization;
using Xunit.Sdk;

namespace ublox.Test
{
    public abstract class TestBase
    {
        private static readonly BinarySerializer Serializer = new BinarySerializer();

        protected void Serialize(PacketPayload packetPayload, byte[] expected)
        {
            var stream = new MemoryStream();
            var packet = new Packet
            {
                SyncCharacters = Constants.SyncCharacters,
                Content = new PacketContent
                {
                    Payload = packetPayload
                }
            };

            Serializer.Serialize(stream, packet);

            AssertEqual(expected, stream.ToArray());
        }

        private void AssertEqual(byte[] expected, byte[] actual)
        {
            // first compare values
            var length = Math.Min(expected.Length, actual.Length);

            for (int i = 0; i < length; i++)
            {
                if (actual[i] != expected[i])
                {
                    var actualHex = string.Join(", ", actual.Select(b =>$"0x{b:x2}"));
                    throw new XunitException($"Expected 0x{expected[i]:x2} at position {i}, actual was 0x{actual[i]:x2}.");
                }
            }

            if (expected.Length != actual.Length)
            {
                throw new XunitException($"Expected {expected.Length} bytes, actual was {actual.Length} bytes.");
            }
        }
    }
}
