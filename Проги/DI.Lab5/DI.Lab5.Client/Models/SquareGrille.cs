using DI.Lab5.Base;
using DI.Lab5.Realization.Extensions;
using DI.Lab5.Realization.Exceptions;

namespace DI.Lab5.Client.Models
{
    public class SquareGrille : IGrille
    {
        public List<List<char>> Grille { get; init; }

        public List<List<char>> TransformedGrille { get; }

        /// <summary>
        /// Рандомно создает квадратную решетку со стороной = n
        /// </summary>
        /// <param name="n">Длина стороны</param>
        public SquareGrille(int n)
        {
            Grille = new List<List<char>>(n);

            Random rnd = new Random();

            /*var holes = new List<int>();
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
            */

            for (int i = 0; i < n; i++)
            {
                var holeIndex = rnd.Next(n + 1);
                Grille.Add(new List<char>());
                for (int j = 0; j < n; j++)
                {
                    if (j == holeIndex)
                        Grille[i].Add('X');
                    else
                        Grille[i].Add(' ');
                }
            }

            TransformedGrille = Grille.Clone();
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
            TransformedGrille = Grille.Clone();
        }

        public List<List<char>> RotateOn90DegClockwise()
        {
            int N = TransformedGrille.Count;

            // Транспонирование матрицы
            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    char temp = TransformedGrille[i][j];
                    TransformedGrille[i][j] = TransformedGrille[j][i];
                    TransformedGrille[j][i] = temp;
                }
            }

            // Поменять столбцы местами (сначала дальние между собой, потом которые перед дальними и тд)
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N/2; j++)
                {
                    char temp = TransformedGrille[i][j];
                    TransformedGrille[i][j] = TransformedGrille[i][N - j - 1];
                    TransformedGrille[i][N - j - 1] = temp;
                }
            }

            return TransformedGrille.Clone();
        }

        public List<List<char>> TurnOver()
        {
            int N = TransformedGrille.Count;

            // Поменять столбцы местами (сначала дальние между собой, потом которые перед дальними и тд)
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N / 2; j++)
                {
                    char temp = TransformedGrille[i][j];
                    TransformedGrille[i][j] = TransformedGrille[i][N - j - 1];
                    TransformedGrille[i][N - j - 1] = temp;
                }
            }

            return TransformedGrille.Clone();
        }
    }
}
