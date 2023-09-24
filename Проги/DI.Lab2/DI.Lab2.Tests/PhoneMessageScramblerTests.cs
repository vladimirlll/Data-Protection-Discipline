using DI.Lab2.Base.Algorithms;
using DI.Lab2.Base.Exceptions;
using DI.Lab2.Base.Models;
using DI.Lab2.Base.Utils;
using FluentAssertions;

namespace DI.Lab2.Tests
{
    public class PhoneMessageScramblerTests
    {
        private ScramblerSettings settings;

        public PhoneMessageScramblerTests()
        {
            ScramblerSettings.Builder builder = new 
                ScramblerSettings.Builder();

            settings = builder.SetA(1)
                .SetB(1)
                .SetC(1)
                .SetAlpha(1)
                .SetBeta(1)
                .SetGamma(1)
                .SetT(1)
                .Sett(0.5)
                .SetKey(new List<int> { 2, 1})
                .Build();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-0.0000001)]
        [InlineData(double.MinValue)]
        public void PhoneMessageScrambler_Constructor_WithNonPositiveMessageDuration_ThrowsException(
            double duration)
        {
            // Arrange
            Action genEx = () =>
            {
                Scrambler scrambler = new
                    PhoneMessageScrambler(settings, duration);
            };

            // Act

            // Assert
            genEx.Should()
                .Throw<NonPositiveMessageDurationException>();
        }

        [Fact]
        public void PhoneMessageScrambler_InputSignalAt_ReturnsCorrectValue()
        {
            // Arrange
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 10);

            // Act
            var inSignal = scrambler.InputSignalValueAt(0);

            // Assert
            // X(t) = 1 * sin(0) + 1 * cos(0) + 0 = 1
            inSignal.Should().BeApproximately(1, Constants.EPSILON);
        }
    }
}
