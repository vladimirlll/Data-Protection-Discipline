using DI.Lab5.Base;
using DI.Lab5.Realization.Exceptions;
using System.Linq;

namespace DI.Lab5.Client.Models
{
    public class SquareGrille : IGrille
    {
        public List<List<char>> Grille { get; init; }

        /// <summary>
        /// Рандомно создает квадратную решетку со стороной = n
        /// </summary>
        /// <param name="n">Длина стороны</param>
        public SquareGrille(int n)
        {
            Grille = new List<List<char>>(n);

            Random rnd = new Random();

            var holes = new List<int>();
            while (holes.Count != n)
            {
                var newVal = 0;
                do
                {
                    newVal = rnd.Next(1, n * n);
                } while (holes.Contains(newVal));
                holes.Add(newVal);
            }

            for(int i = 0; i < n; i++)
            {
                Grille.Add(new List<char>());
                for(int j = 1; j <= n; j++)
                {
                    if (holes.Contains(i * n + j))
                        Grille[i].Add('X');
                    else
                        Grille[i].Add(' ');
                }
            }
        }

        /// <summary>
        /// Присваивает аргумент свойству <see cref="Grille"/>
        /// </summary>
        /// <param name="grille">Квадратная символьная матрица, должна содержать n 'X', остальные элементы - ' '</param>
        /// <exception cref="InputCharMatrixBadSizeException">Матрица должна быть квадратной и непустой</exception>
        /// <exception cref="InputCharMatrixUnknownSymbolsException">Матрица должна содержать n 'X', остальные - ' '</exception>
        public SquareGrille(List<List<char>> grille)
        {
            bool IsGrilleSquare()
            {
                var rows = grille.Count;
                foreach (var row in grille)
                {
                    if (row.Count != rows)
                        return false;
                }
                return true;
            }

            bool IsGrilleContainsOnlyGoodSymbols()
            {
                foreach (var row in grille)
                {
                    foreach (var item in row)
                    {
                        if (item != ' ' && item != 'X')
                            return false;
                    }
                }
                return true;
            }

            int HolesCount() => grille.SelectMany(x => x).ToList().Select(h => h == 'X').Count();

            if (grille.Count == 0 || !IsGrilleSquare())
                throw new InputCharMatrixBadSizeException();

            if (!IsGrilleContainsOnlyGoodSymbols() && !(HolesCount() == grille.Count))
                throw new InputCharMatrixUnknownSymbolsException();

            Grille = grille;
        }
    }
}
