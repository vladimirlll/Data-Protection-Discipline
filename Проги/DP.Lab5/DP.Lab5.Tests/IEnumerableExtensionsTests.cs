using DP.Lab5.Service.Encoders;
using DP.Lab5.Service.Extensions;
using DP.Lab5.Service.Repository;
using FluentAssertions;

namespace DP.Lab5.Tests
{
    public class IEnumerableExtensionsTests
    {
        private bool AreMatrixesEquivalent(List<List<char>> m1, List<List<char>> m2)
        {
            var m1Copy = m1.Clone();
            var m2Copy = m2.Clone();

            if (m1Copy.Count != m2Copy.Count) return false;

            for (int i = 0; i < m1Copy.Count; i++)
            {
                if (m1Copy[i].Count != m2Copy.Count) return false;
                for (int j = 0; j < m1Copy[i].Count; j++)
                {
                    if (m1Copy[i][j] != m2Copy[i][j])
                        return false;
                }
            }

            return true;
        }

        [Fact]
        public void SquareRotatingGrilleWithSixSide_ShouldHaveTheseVariations()
        {
            var grille = new List<List<char>>()
            {
                new List<char>() {' ', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', 'X', ' '},
                new List<char>() {'X', ' ', ' ', ' ', 'X', ' '},
                new List<char>() {' ', 'X', ' ', ' ', ' ', ' '}
            };

            var rotation1 = new List<List<char>>()
            {
                new List<char>() {' ', 'X', ' ', 'X', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' ', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' ', 'X', ' '},
                new List<char>() {' ', ' ', ' ', ' ', ' ', ' '},
                new List<char>() {' ', 'X', 'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X', ' ', 'X'}
            };

            var rotation2 = new List<List<char>>()
            {
                new List<char>() {' ', ' ', ' ', ' ', 'X', ' '},
                new List<char>() {' ', 'X', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', 'X', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', ' ', 'X', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' ', ' ', ' '}
            };

            var rotation3 = new List<List<char>>()
            {
                new List<char>() {'X', ' ', 'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X', 'X', ' '},
                new List<char>() {' ', ' ', ' ', ' ', ' ', ' '},
                new List<char>() {' ', 'X', ' ', 'X', ' ', ' '},
                new List<char>() {' ', ' ', ' ', ' ', ' ', 'X'},
                new List<char>() {' ', ' ', 'X', ' ', 'X', ' '}
            };

            var rot = grille.RotateOn90DegClockwise().Select(row => row.ToList()).ToList();

            AreMatrixesEquivalent(grille.RotateOn90DegClockwise().Select(row => row.ToList()).ToList(), rotation1).Should().BeTrue();
            AreMatrixesEquivalent(rotation1.RotateOn90DegClockwise().Select(row => row.ToList()).ToList(), rotation2).Should().BeTrue();
            AreMatrixesEquivalent(rotation2.RotateOn90DegClockwise().Select(row => row.ToList()).ToList(), rotation3).Should().BeTrue();
            AreMatrixesEquivalent(rotation3.RotateOn90DegClockwise().Select(row => row.ToList()).ToList(), grille).Should().BeTrue();
        }
    }
}
