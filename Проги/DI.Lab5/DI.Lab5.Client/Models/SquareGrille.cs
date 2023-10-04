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
                var filledSquares = grille.SelectMany(x => x).Where(x => x == ' ').Count();
                var holes = grille.SelectMany(x => x).Where(x => x == 'X').Count();

                if (holes == grille.Count && (filledSquares + holes) == grille.Count * grille.Count)
                    return true;
                return false;
            }

            if (grille.Count == 0 || !IsGrilleSquare())
                throw new InputCharMatrixBadSizeException();

            if (!IsGrilleContainsOnlyGoodSymbols())
                throw new InputCharMatrixUnknownSymbolsException();

            Grille = grille;
        }

        public List<List<char>> RotateOn90DegClockwise()
        {
            int N = Grille.Count;
            var result = new List<List<char>>(Grille);

            // Транспонирование матрицы
            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    char temp = result[i][j];
                    result[i][j] = result[j][i];
                    result[j][i] = temp;
                }
            }

            // Поменять столбцы местами (сначала дальние между собой, потом которые перед дальними и тд)
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N/2; j++)
                {
                    char temp = result[i][j];
                    result[i][j] = result[i][N - j - 1];
                    result[i][N - j - 1] = temp;
                }
            }

            return result;
        }
    }
}
