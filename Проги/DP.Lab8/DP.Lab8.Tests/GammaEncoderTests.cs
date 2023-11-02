using DP.Lab8.Code;
using FluentAssertions;

namespace DP.Lab8.Tests
{
    public class GammaEncoderTests
    {
        [Fact]
        public void Decode_Encoded_ReturnsInitMessage()
        {
            Generator generator = new Generator(1);
            GammaEncoder encoder = new GammaEncoder(generator);
            string initMsg = "Начальное сообщение";

            string encoded = encoder.Encode(initMsg);
            string decoded = encoder.Decode(encoded);

            decoded.Should().BeEquivalentTo(initMsg);
        }
    }
}
