using DI.Lab5.Realization.Extensions;
using DI.Lab5.Realization.Models;
using FluentAssertions;

namespace DI.Lab5.Tests
{
    public class SquareGrilleTests
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
        public void SquareGrille_RandomlyConstructor_GeneratesOneRowXMatrix()
        {
            var grille = new SquareGrille(4);
            foreach (var row in grille.Grille)
            {
                var rowWithXOnly = row.Where(x => x == 'X').ToList();
                rowWithXOnly.Should().HaveCount(1);
            }
        }

        [Fact]
        public void RandomlyContructedGrille_ShouldHaveSideTimesTwoQuadrantSideParameter()
        {
            var grille = new SquareGrille(2);

            grille.Grille.Count.Should().Be(4);
        }

        [Fact]
        public void SquareGrille_RotateOn90DegClockwise_WithOneCycle_ShouldReturnRotatedMatrix()
        {
            var initial = new List<List<char>>
            {
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
            };
            var grille = new SquareGrille(initial.Clone());
            var expectedRotated = new List<List<char>>
            {
                new List<char>() {' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
            };

            var rotated = grille.RotateOn90DegClockwise();

            AreMatrixesEquivalent(rotated, expectedRotated).Should().BeTrue();
            AreMatrixesEquivalent(grille.Grille, initial).Should().BeTrue();
        }

        [Fact]
        public void SquareGrille_RotateOn90DegClockwise_WithTwoCycles_ShouldReturnRotatedMatrixes()
        {
            var initial = new List<List<char>>
            {
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
            };
            var grille = new SquareGrille(initial.Clone());
            var expectedRotatedFirstCycle = new List<List<char>>
            {
                new List<char>() {' ', ' ', ' ', 'X'},
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
            };
            var expectedRotatedSecondCycle = new List<List<char>>
            {
                new List<char>() {' ', 'X', ' ', ' '},
                new List<char>() {' ', ' ', 'X', ' '},
                new List<char>() {'X', ' ', ' ', ' '},
                new List<char>() {' ', ' ', ' ', 'X'},
            };

            var rotatedFirstCycle = grille.RotateOn90DegClockwise();
            var rotatedSecondCycle = grille.RotateOn90DegClockwise();

            AreMatrixesEquivalent(rotatedFirstCycle, expectedRotatedFirstCycle).Should().BeTrue();
            AreMatrixesEquivalent(rotatedSecondCycle, expectedRotatedSecondCycle).Should().BeTrue();
            AreMatrixesEquivalent(grille.Grille, initial).Should().BeTrue();
        }
    }
}
