using DI.Lab2.Services.Algorithms;
using DI.Lab2.Services.Exceptions;
using DI.Lab2.Services.Models;
using DI.Lab2.Services.Utils;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DI.Lab2.Services.Tests
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
                .SetKey(new List<int> { 1, 0})
                .Build();
        }


        [Theory]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-0.0000001)]
        [TestCase(double.MinValue)]
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

        [Test]
        public void PhoneMessageScrambler_InputSignalAt_ReturnsCorrectValue()
        {
            // Arrange
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 10);

            // Act
            var inSignal = scrambler.InputSignalValueAt(0);

            // Assert
            // X(0) = 1 * sin(0) + 1 * cos(0) + 0 = 1
            inSignal.Should().BeApproximately(1, Constants.EPSILON);
        }

        [Theory]
        [TestCase(-1)]
        [TestCase(-0.000001)]
        [TestCase(11)]
        [TestCase(10.0000001)]
        public void PhoneMessageScrambler_InputSignalAt_WithIncorrectTime_ThrowsException(
            double time)
        {
            // Arrange
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 10);

            // Act
            Action genEx = () => 
                scrambler.InputSignalValueAt(time);

            // Assert
            genEx.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [TestCase(-1)]
        [TestCase(-0.000001)]
        [TestCase(11)]
        [TestCase(10.0000001)]
        public void PhoneMessageScrambler_OutputSignalAt_WithIncorrectTime_ThrowsException(
            double time)
        {
            // Arrange
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 10);

            // Act
            Action genEx = () =>
                scrambler.OutputSignalValueAt(time);

            // Assert
            genEx.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void PhoneMessageScrambler_OutputSignalAt_ReturnsCorrectValue()
        {
            // Arrange
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 2);

            // Act
            var outSignal = scrambler.OutputSignalValueAt(0.5);

            // Assert
            // X(0) = 1 * sin(0) + 1 * cos(0) + 0 = 1
            // 0 - 0.5 -> 0.5 - 1; 0.5 - 1 -> 0 - 0.5
            outSignal.Should().HaveCount(1);
            outSignal.ElementAt(0)
                .Should()
                .BeApproximately(1, Constants.EPSILON);
        }

        [Test]
        public void PhoneMessageScrambler_OutputSignalAt_StartPointsOfSmallSegments_ReturnsTheSameLikeInputSignalAtNewPos()
        {
            // Arrange 
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 2);

            // Act
            var inSignal = scrambler.InputSignalValueAt(0.5);
            var outSignal = scrambler.OutputSignalValueAt(0);

            // Assert
            outSignal.Should().HaveCount(1);
            inSignal.Should().BeApproximately(outSignal.ElementAt(0), 
                Constants.EPSILON);
        }

        [Test]
        public void PhoneMessageScrambler_OutputSignalAt_MidPointOfSmallSegments_ReturnsTheSameLikeInputSignalAtNewPos()
        {
            // Arrange 
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 2);

            // Act
            var inSignal = scrambler.InputSignalValueAt(0.25);
            var outSignal = scrambler.OutputSignalValueAt(0.75);

            // Assert
            outSignal.Should().HaveCount(1);
            inSignal.Should().BeApproximately(outSignal.ElementAt(0),
                Constants.EPSILON);
        }

        [Test]
        public void PhoneMessageScrambler_OutputSignalAt_EndPointOfSmallSegments_ReturnsTheSameLikeInputSignalAtNewPos()
        {
            // Arrange 
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 2);

            // Act
            var inSignal = scrambler.InputSignalValueAt(0.5);
            var outSignal = scrambler.OutputSignalValueAt(1);

            // Assert
            outSignal.Should().HaveCount(2);
            inSignal.Should().BeApproximately(outSignal.ElementAt(0),
                Constants.EPSILON);
        }

        [Test]
        public void PhoneMessageScrambler_OutputSignalAt_EndPointOfMessage_ReturnsTheSameLikeInputSignalAtEndPointOfLastSmallSegment()
        {
            // Arrange 
            Scrambler scrambler = new
                PhoneMessageScrambler(settings, 10);

            // Act
            var inSignal = scrambler.InputSignalValueAt(9.5);
            var outSignal = scrambler.OutputSignalValueAt(10);

            // Assert
            outSignal.Should().HaveCount(1);
            inSignal.Should().BeApproximately(outSignal.ElementAt(0),
                Constants.EPSILON);
        }

        [Test]
        public void PhoneMessageScrambler_InputOutputSignalAt_CanUsedToBuildAPlot()
        {
            // Arrange
            var scrambler = new 
                PhoneMessageScrambler(settings, 10);
            var XOftValues = new List<(double, double)>();
            var YOftValues = new List<(double, double)>();

            // Act
            for (double t = 0; t <= scrambler.MessageDuration; t += scrambler.Settings.t)
            {
                double XOftValue = scrambler.InputSignalValueAt(t);
                var YOftValue = scrambler.OutputSignalValueAt(t);

                // Save points

                XOftValues.Add((t, XOftValue));
                foreach (var y in YOftValue)
                    YOftValues.Add((t, y));
            }

            var XPointsCount = int.Parse(
                    Math.Floor(scrambler.MessageDuration / scrambler.Settings.t).ToString()
                    ) + 1;

            var borderPointsCount = int.Parse(
                    Math.Floor(scrambler.MessageDuration / scrambler.Settings.T).ToString()
                    ) - 1;

            // Assert
            XOftValues.Should().HaveCount(XPointsCount);
            YOftValues.Should().HaveCount(XPointsCount + borderPointsCount);
        }
    }
}
