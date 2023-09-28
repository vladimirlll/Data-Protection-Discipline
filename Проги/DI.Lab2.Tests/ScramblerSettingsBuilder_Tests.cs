using DI.Lab2.Services.Exceptions;
using DI.Lab2.Services.Models;
using FluentAssertions;

namespace DI.Lab2.Tests
{
    public class ScramblerSettingsBuilder_Tests
    {
        private ScramblerSettings.Builder builder = new ScramblerSettings.Builder();
        public ScramblerSettingsBuilder_Tests()
        {
            
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(double.MinValue)]
        public void ScramblerSettingsBuilder_SetAlphaNonPositive_GeneratesException(
            double alpha)
        {
            // Arrange

            // Act
            Action genEx = () => builder.SetAlpha(alpha);

            // Assert
            genEx.Should().Throw<NonPositiveCoeffException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(double.MinValue)]
        public void ScramblerSettingsBuilder_SetBettaNonPositive_GeneratesException(
            double betta)
        {
            // Arrange

            // Act
            Action genEx = () => builder.SetBeta(betta);

            // Assert
            genEx.Should().Throw<NonPositiveCoeffException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(double.MinValue)]
        public void ScramblerSettingsBuilder_SetGammaNonPositive_GeneratesException(
            double gamma)
        {
            // Arrange

            // Act
            Action genEx = () => builder.SetGamma(gamma);

            // Assert
            genEx.Should().Throw<NonPositiveCoeffException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(0.5)]
        [InlineData(0.9)]
        [InlineData(0.9999)]
        [InlineData(2.0001)]
        [InlineData(3)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        public void ScramblerSettingsBuilder_SetTNotSatisfiedValue_GenerateException(double T)
        {
            // Arrange

            // Act
            Action genEx = () => builder.SetT(T);

            // Assert
            genEx.Should().Throw<NonPositiveTimeIntervalException>();
        }

        [Fact]
        public void ScramblerSettingsBuilder_SettBeforeSetT_GenerateException()
        {
            // Arrange

            // Act
            Action genEx = () =>
            {
                builder.Sett(1);
            };

            // Assert
            genEx.Should().Throw<TIsNotSetException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(double.MinValue)]
        public void ScramblerSettingsBuilder_SettNonPositive_GenerateException(double t)
        {
            // Arrange

            // Act
            Action genEx = () =>
            {
                builder.SetT(2);
                builder.Sett(t);
            };

            // Assert
            genEx.Should().Throw<NonPositiveCoeffException>();
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(2, 10)]
        [InlineData(2, 10.0001)]
        public void ScramblerSettingsBuilder_SetTSmallert_GenerateException(
            double T, double t)
        {
            // Arrange

            // Act
            Action genEx = () =>
            {
                builder.SetT(T);
                builder.Sett(t);
            };

            // Assert
            genEx.Should().Throw<TIsSmallertException>();
        }

        [Theory]
        [InlineData(2, 1.5)]
        [InlineData(2, 0.3)]
        [InlineData(2, 1.3)]
        [InlineData(2, 1.1)]
        public void ScramblerSettingsBuilder_SetT_Sett_WithNotSatisfiedTtDivision_GenerateException(
            double T, double t)
        {
            // Arrange

            // Act
            Action genEx = () =>
            {
                builder.SetT(T);
                builder.Sett(t);
            };

            // Assert
            genEx.Should().Throw<TDividetIsNotSatisfiedException>();
        }

        [Theory]
        [InlineData(10, 5)]
        [InlineData(10, 2)]
        [InlineData(10, 10)]
        [InlineData(8, 2)]
        public void ScramblerSettingsBuilder_SetT_Sett_WithSatisfiedTtDivision_DoesntGenerateException(
            double T, double t)
        {
            // Arrange

            // Act
            Action genEx = () =>
            {
                builder.SetT(T);
                builder.Sett(t);
            };

            // Assert
            genEx.Should().NotThrow<TDividetIsNotSatisfiedException>();
        }

    }
}
