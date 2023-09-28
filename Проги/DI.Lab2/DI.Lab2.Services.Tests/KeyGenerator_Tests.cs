using DI.Lab2.Services.Utils;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace DI.Lab2.Services.Tests
{
    [TestFixture]
    public class KeyGenerator_Tests
    {
        [Theory]
        [TestCase(0.5, 1)]
        [TestCase(0.2, 1)]
        [TestCase(0.1, 1)]
        [TestCase(1, 2)]
        [TestCase(0.5, 2)]
        [TestCase(0.2, 2)]
        public void KeyGenerator_Generate_MakesSequenceWithCorrectLength(double t, double T)
        {
            // Arrange
            int n = int.Parse(Math.Truncate(T / t).ToString());

            // Act
            var generated = KeyGenerator.Generate(T, t);

            // Assert
            generated.Should().HaveCount(n);
        }

        [Theory]
        [TestCase(0.5, 1)]
        [TestCase(0.2, 1)]
        [TestCase(0.1, 1)]
        [TestCase(1, 2)]
        [TestCase(0.5, 2)]
        [TestCase(0.2, 2)]
        public void KeyGenerator_Generate_MakesShuffledSequence(double t, double T)
        {
            // Arrange
            int n = int.Parse(Math.Truncate(T / t).ToString());

            // Act
            var generated = KeyGenerator.Generate(T, t);
            var orderedGenerated = generated.OrderBy(x => x);

            // Assert
            generated.Should().NotContainInOrder(orderedGenerated);
        }
    }
}
