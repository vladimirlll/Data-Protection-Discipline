using DI.Lab5.Realization.Encoders;
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
        public void RotatingGrilleCipherEncoder_Decode_WithMultipleInitMessageLengthToGrilleSquareFromEncode_ShouldReturnInitMessage()
        {
            var grille = new SquareGrille(4);
            var enc = new RotatingGrilleCipherEncoder(grille);
            var msg = "0123456789ABCDEF";

            var encoded = enc.Encode(msg);
            var decoded = enc.Decode(encoded);

            decoded.Should().BeEquivalentTo(msg);
        }
    }
}
