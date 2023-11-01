using DP.Lab7.Code;
using FluentAssertions;

namespace DP.Lab7.Tests
{
    public class RussianVigenereEncoderTests
    {
        [Fact]
        public void Decode_EncodedWithInitialMessageBiggerThanKey_ReturnsInitialMessage()
        {
            RussianVigenereEncoder encoder = new RussianVigenereEncoder("Ключик");
            string initial = "Исходный текст сообщения!";

            string encoded = encoder.Encode(initial);
            string decoded = encoder.Decode(encoded);

            decoded.Should().BeEquivalentTo(initial);
        }

        [Fact]
        public void Decode_EncodedWithInitialMessageLessThanKey_ReturnsInitialMessage()
        {
            RussianVigenereEncoder encoder = new RussianVigenereEncoder("Ключик");
            string initial = "текст";

            string encoded = encoder.Encode(initial);
            string decoded = encoder.Decode(encoded);

            decoded.Should().BeEquivalentTo(initial);
        }
    }
}
