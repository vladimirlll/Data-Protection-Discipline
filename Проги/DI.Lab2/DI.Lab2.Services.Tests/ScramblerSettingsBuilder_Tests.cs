using DI.Lab2.Services.Exceptions;
using DI.Lab2.Services.Models;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DI.Lab2.Services.Tests
{
    [TestFixture]
    public class ScramblerSettingsBuilder_Tests
    {
        private ScramblerSettings.Builder builder;

        [SetUp]
        public void SetUp() => builder = new ScramblerSettings.Builder();

        [Theory]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(double.MinValue)]
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
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(double.MinValue)]
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
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(double.MinValue)]
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
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(0.5)]
        [TestCase(0.9)]
        [TestCase(0.9999)]
        [TestCase(2.0001)]
        [TestCase(3)]
        [TestCase(double.MinValue)]
        [TestCase(double.MaxValue)]
        public void ScramblerSettingsBuilder_SetTNotSatisfiedValue_GenerateException(double T)
        {
            // Arrange

            // Act
            Action genEx = () => builder.SetT(T);

            // Assert
            genEx.Should().Throw<NonPositiveTimeIntervalException>();
        }

        [Test]
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
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(double.MinValue)]
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
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(2, 10.0001)]
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
        [TestCase(2, 1.5)]
        [TestCase(2, 0.3)]
        [TestCase(2, 1.3)]
        [TestCase(2, 1.1)]
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
        [TestCase(10, 5)]
        [TestCase(10, 2)]
        [TestCase(10, 10)]
        [TestCase(8, 2)]
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
