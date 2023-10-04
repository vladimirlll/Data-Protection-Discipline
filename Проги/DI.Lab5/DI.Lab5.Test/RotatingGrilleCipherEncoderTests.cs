using DI.Lab5.Realization.Encoders;
using DI.Lab5.Realization.Exceptions;
using DI.Lab5.Realization.Models;
using FluentAssertions;

namespace DI.Lab5.Tests
{
    public class RotatingGrilleCipherEncoderTests
    {
        [Fact]
        public void RotatingGrilleCipherEncoder_Encode_WithMultipleInitMessageLengthToGrilleSquare_ShouldReturnEncodedLengthEqualToInitMessage()
        {
            var grille = new SquareGrille(new List<List<char>>()
            {
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
            });
            var enc = new RotatingGrilleCipherEncoder(grille);

            var encoded = enc.Encode("0123456789ABCDEF");

            encoded.Should().HaveLength(16);
        }

        [Fact]
        public void RotatingGrilleCipherEncoder_Encode_WithInitMessageLengthLessThanGrilleSquare_ShouldReturnEncodedLengthEqualToMultipleToGrilleSquare()
        {
            var grille = new SquareGrille(new List<List<char>>()
            {
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
            });
            var enc = new RotatingGrilleCipherEncoder(grille);

            var encoded = enc.Encode("0123");

            encoded.Should().HaveLength(16);
        }

        [Fact]
        public void RotatingGrilleCipherEncoder_Encode_WithInitMessageLengthMoreThanGrilleSquareAndNotEqualToMultipleToGrilleSquare_ShouldReturnEncodedLengthEqualToMultipleToGrilleSquare()
        {
            var grille = new SquareGrille(new List<List<char>>()
            {
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
            });
            var enc = new RotatingGrilleCipherEncoder(grille);

            var encoded = enc.Encode("0123456789ABCDEFG");

            encoded.Should().HaveLength(32);
        }

        [Fact]
        public void RotatingGrilleCipherEncoder_Decode_WithMultipleInitMessageLengthToGrilleSquareFromEncode_ShouldReturnInitMessage()
        {
            var grille = new SquareGrille(4);
            var enc = new RotatingGrilleCipherEncoder(grille);
            var msg = "0123456789ABCDEF";

            var encoded = enc.Encode(msg);
            var decoded = enc.Decode(encoded);

            decoded.Should().HaveLength(decoded.Length);
            decoded.Should().BeEquivalentTo(msg);
        }

        [Fact]
        public void RotatingGrilleCipherEncoder_Decode_WithNotMultipleInitMessageLengthToGrilleSquareFromEncode_ShouldThrowException()
        {
            var grille = new SquareGrille(4);
            var enc = new RotatingGrilleCipherEncoder(grille);
            var encoded = "0123";

            Action genEx = () =>
            {
                var decoded = enc.Decode(encoded);
            };

            genEx.Should().Throw<BadEncodedMessageException>();
        }

        [Fact]
        public void RotatingGrilleCipherEncoder_Decode_WithInitMessageLengthSmallerThanGrilleSquareFromEncode_ShouldReturnSquareLengthDecoded()
        {
            var grille = new SquareGrille(4);
            var enc = new RotatingGrilleCipherEncoder(grille);
            var msg = "0123";

            var encoded = enc.Encode(msg);
            var decoded = enc.Decode(encoded);

            encoded.Should().HaveLength(16);
            decoded.Should().HaveLength(encoded.Length);
        }
    }
}
