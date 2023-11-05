using DP.Lab9.Code;
using FluentAssertions;

namespace DP.Lab9.Tests
{
    public class OneTimeCipherEncoderTests
    {
        [Fact]
        public void Encode_ShouldReturnEncodedWithLengthEqualToMessage()
        {
            OneTimeCipherEncoder encoder = new OneTimeCipherEncoder();
            string initial = "Исходный текст сообщения!";

            string encoded = encoder.Encode(initial);

            encoded.Should().HaveLength(initial.Length);
        }

        [Fact]
        public void Encode_ShouldProduceKeyWithLengthEqualToMessage()
        {
            OneTimeCipherEncoder encoder = new OneTimeCipherEncoder();
            string initial = "Исходный текст сообщения!";

            string encoded = encoder.Encode(initial);

            encoder.Key.Should().HaveCount(initial.Length);
        }

        [Fact]
        public void Decode_Encoded_ReturnsInitialMessage()
        {
            OneTimeCipherEncoder encoder = new OneTimeCipherEncoder();
            string initial = "Исходный текст сообщения!";

            string encoded = encoder.Encode(initial);
            string decoded = encoder.Decode(encoded);

            decoded.Should().BeEquivalentTo(initial);
        }


        [Fact]
        public void Decoded_NotEncodedWithAnotherLengthThanRealEncoded_ThrowsException()
        {
            OneTimeCipherEncoder encoder = new OneTimeCipherEncoder();
            string initial = "Исходный текст сообщения!";

            string encoded = encoder.Encode(initial);
            encoded += "123";
            Action act = () =>
            {
                string decoded = encoder.Decode(encoded);
            };

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Decoded_WithoutAnyEncodeCallsBefore_ThrowsException()
        {
            OneTimeCipherEncoder encoder = new OneTimeCipherEncoder();
            string initial = "Исходный текст сообщения!";

            string enc = "Зашифровано";
            Action act = () =>
            {
                string decoded = encoder.Decode(enc);
            };

            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
