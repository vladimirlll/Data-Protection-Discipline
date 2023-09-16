using DI.Lab5.Realization.Encoders;
using FluentAssertions;

namespace DI.Lab5.Test
{
    public class SubstitutionEncoderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void SubstitutionEncoder_Constructor_ThrowsException_IfGroupCapacityIsNotPositive(
            int groupCapacity)
        {
            // Arrange

            Action action = () => new SubstitutionEncoder(groupCapacity, 
                new int[] {1});

            // Act, Assert

            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("Размерность группы должна быть положительной");
        }

        [Theory]
        [InlineData(4, new int[] {1, 2, 3})]
        [InlineData(4, new int[] {1, 2, 3, 5})]
        [InlineData(4, new int[] {1})]
        [InlineData(4, new int[] {1, 2})]
        public void SubstitutionEncoder_Constructor_ThrowsException_IfSubstitutionIsNotGood(
            int groupCapacity,
            int[] substitition)
        {
            // Arrange

            Action action = () => new SubstitutionEncoder(groupCapacity,
                substitition);

            // Act, Assert

            action.Should()
                .Throw<ArgumentException>();
        }

        [Fact]
        public void SubstitutionEncoder_Encode_ReturnsTheSame_WithNoSubstitution()
        {
            // Arrange

            SubstitutionEncoder encoder = new
                SubstitutionEncoder(4, new int[] { 1, 2, 3, 4 });
            string msg = "Hello";

            // Act

            string encoded = encoder.Encode(msg);

            // Assert
            encoded.Should().BeEquivalentTo(msg);
        }

        [Fact]
        public void SubstitutionEncoder_Encode_ReturnsMixed_WithNormalSubstitution()
        {
            // Arrange

            SubstitutionEncoder encoder = new
                SubstitutionEncoder(4, new int[] { 4, 3, 2, 1 });
            string msg = "Hello World";
            string enc = "lleHoW odlr";

            // Act

            string encoded = encoder.Encode(msg);

            // Assert

            encoded.Should().BeEquivalentTo(enc);
        }

        [Fact]
        public void SubstitutionEncoder_Encode_ThrowException_IfMessageSmallerSubstitution()
        {
            // Arrange

            SubstitutionEncoder encoder = new
                SubstitutionEncoder(4, new int[] { 4, 3, 2, 1 });
            string msg = "Hel";

            // Act

            Action action = () => encoder.Encode(msg);

            // Assert

            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("Заданная подстановка не может использоваться " +
                "для заданного сообщения");
        }
    }
}
