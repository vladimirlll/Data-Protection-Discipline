using DP.Lab5.Service.Encoders;
using DP.Lab5.Service.Extensions;
using DP.Lab5.Service.Models;
using DP.Lab5.Service.Repository;
using FluentAssertions;

namespace DP.Lab5.Tests
{
    public class RotatingGrilleCipherEncoderTests
    {
        [Fact]
        public void MessageWithLengthEqualToGrilleSquare_ShoudHaveEncodedMessageLengthEqualToInitMessage()
        {
            var grille = new SquareGrilleRepository(new List<List<char>>()
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
        public void MessageWithLengthLessThanGrilleSquare_ShouldHaveEncodedMessageLengthEqualToGrilleSquare()
        {
            var grille = new SquareGrilleRepository(new List<List<char>>()
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
        public void MessageWithLengthMoreThanGrilleSquareMultiple_ShouldHaveEncodedMessageLengthEqualToMultipleToGrilleSquare()
        {
            var grille = new SquareGrilleRepository(new List<List<char>>()
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
        public void EncodedMessageWithLengthMultipleToGrilleSquare_ShouldHaveDecodedInitialMessage()
        {
            var grille = new SquareGrilleRepository(new List<List<char>>()
            {
                new List<char>() {' ', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', 'X', ' '},
                new List<char>() {'X', ' ', ' ', ' ', 'X', ' '},
                new List<char>() {' ', 'X', ' ', ' ', ' ', ' '}
            });
            var enc = new RotatingGrilleCipherEncoder(grille);
            var msg = "";
            for (int i = 0; i < 26; i++)
            {
                msg += (char)('A' + i);
            }
            for (int i = 26; i < 36; i++)
            {
                msg += (i - 26).ToString()[0];
            }

            var encoded = enc.Encode(msg);
            var decoded = enc.Decode(encoded);

            encoded.Should().StartWithEquivalentOf("1J2KSALTB34");
            decoded.Should().HaveLength(encoded.Length);
            decoded.Should().BeEquivalentTo(msg);
        }

        [Fact]
        public void OnlyAfterEncoding_FilledMatrixVariationsAreAvailable()
        {
            var grille = new SquareGrilleRepository(new List<List<char>>()
            {
                new List<char>() {' ', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', 'X', ' '},
                new List<char>() {'X', ' ', ' ', ' ', 'X', ' '},
                new List<char>() {' ', 'X', ' ', ' ', ' ', ' '}
            });
            var enc = new RotatingGrilleCipherEncoder(grille);
            var msg = "";
            for (int i = 0; i < 26; i++)
            {
                msg += (char)('A' + i);
            }
            for (int i = 26; i < 36; i++)
            {
                msg += (i - 26).ToString()[0];
            }

            var before = new List<List<List<char>>>();
            foreach (var filled in enc.FilledMatrixVariations)
            {
                before.Add(filled.Clone());
            }

            var encoded = enc.Encode(msg);

            var after = new List<List<List<char>>>();
            foreach (var filled in enc.FilledMatrixVariations)
            {
                after.Add(filled.Clone());
            }

            before.Should().BeEmpty();
            after.Should().HaveCount(4);
        }
    }
}
