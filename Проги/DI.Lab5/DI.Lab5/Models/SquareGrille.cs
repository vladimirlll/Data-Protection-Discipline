using DI.Lab5.Base;
using DI.Lab5.Realization.Exceptions;
using DI.Lab5.Realization.Extensions;

namespace DI.Lab5.Realization.Models
{
    public class SquareGrille : IGrille
    {
        public List<List<char>> Grille { get; init; }

        private List<List<char>> _transformed;

        public List<List<char>> TransformedGrille => _transformed;

        /// <summary>
        /// Рандомно создает квадратную решетку со стороной = n
        /// </summary>
        /// <param name="k">Длина стороны четверти решетки</param>
        public SquareGrille(int k)
        {
            Grille = new List<List<char>>(k * 2);

            Random rnd = new Random();

            var quarter = CreateQuarter(k);

            var holes = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var holeIndex = 0;
                do
                {
                    holeIndex = rnd.Next(n);
                } while (holes.Contains(holeIndex));
                Grille.Add(new List<char>());
                for (int j = 0; j < n; j++)
                {
                    if (j == holeIndex)
                        Grille[i].Add('X');
                    else
                        Grille[i].Add(' ');
                }
            }
            _transformed = Grille.Clone();
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
            _transformed = Grille.Clone();
        }

        public List<List<char>> TurnOver()
        {
            int N = _transformed.Count;

            // Поменять столбцы местами (сначала дальние между собой, потом которые перед дальними и тд)
            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < N/2; j++)
                {
                    char temp = _transformed[i][j];
                    _transformed[i][j] = _transformed[i][N - j - 1];
                    _transformed[i][N - j - 1] = temp;
                }
            }

            return _transformed.Clone();
        }

        public List<List<char>> RotateOn90DegClockwise()
        {
            int N = _transformed.Count;

            // Транспонирование матрицы
            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    char temp = _transformed[i][j];
                    _transformed[i][j] = _transformed[j][i];
                    _transformed[j][i] = temp;
                }
            }

            _transformed = TurnOver();

            return _transformed.Clone();
        }


    }
}
