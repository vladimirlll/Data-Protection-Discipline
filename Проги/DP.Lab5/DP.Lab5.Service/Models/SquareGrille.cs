using DP.Lab5.Service.Exceptions;
using DP.Lab5.Service.Extensions;

namespace DP.Lab5.Service.Models
{
    public class SquareGrille
    {
        public List<List<char>> Grille { get; set; }

        public List<List<char>> TransformedGrille { get; set; }
        public List<List<int>> NumGrille { get; set; }

        /// <summary>
        /// Рандомно создает квадратную решетку со стороной = n
        /// </summary>
        /// <param name="k">Длина стороны четверти решетки</param>
        public SquareGrille(int k)
        {
            Grille = new List<List<char>>(k * 2);

            Random rnd = new Random();

            var firstQuarter = CreateQuarter(k);
            var secondQuarter = firstQuarter.Clone().RotateOn90DegClockwise()
                .Select(row => row.ToList()).ToList();
            var thirdQuarter = secondQuarter.Clone().RotateOn90DegClockwise()
                .Select(row => row.ToList()).ToList();
            var fourthQuarter = thirdQuarter.Clone().RotateOn90DegClockwise()
                .Select(row => row.ToList()).ToList();

            NumGrille = CreateNumGrilleFromQuarters(
                firstQuarter,
                secondQuarter,
                thirdQuarter,
                fourthQuarter);

            var marked = MarkNumbers(NumGrille);

            for (int i = 0; i < k * 2; i++)
            {
                Grille.Add(new List<char>());
                for (int j = 0; j < k * 2; j++)
                {
                    Grille[i].Add(marked[i][j] == -1 ? 'X' : ' ');
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

                if (holes == (grille.Count * grille.Count / 4) && 
                    (filledSquares + holes) == grille.Count * grille.Count)
                    return true;
                return false;
            }

            if (grille.Count == 0 || !IsGrilleSquare())
                throw new InputMatrixBadSizeException();

            if (!IsGrilleContainsOnlyGoodSymbols())
                throw new InputMatrixUnknownSymbolsException();

            Grille = grille;
            TransformedGrille = Grille.Clone();
        }


        private List<List<int>> CreateQuarter(int k)
        {
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < k; i++)
            {
                result.Add(new List<int>());
                for (int j = 0; j < k; j++)
                {
                    result[i].Add(i * k + j + 1);
                }
            }

            return result;
        }

        private List<List<int>> CreateNumGrilleFromQuarters(
            List<List<int>> firstQuarter,
            List<List<int>> secondQuarter,
            List<List<int>> thirdQuarter,
            List<List<int>> fourthQuarter)
        {
            var k = firstQuarter.Count;
            var numGrille = new List<List<int>>(k * 2);

            for (int i = 0; i < k; i++)
            {
                numGrille.Add(new List<int>());
                for (int j = 0; j < k; j++)
                {
                    numGrille[i].Add(firstQuarter[i][j]);
                }
            }

            for (int i = 0; i < k; i++)
            {
                for (int j = k; j < k * 2; j++)
                {
                    numGrille[i].Add(secondQuarter[i][j - k]);
                }

            }

            for (int i = k; i < k * 2; i++)
            {
                numGrille.Add(new List<int>());
                for (int j = k; j < k * 2; j++)
                {
                    numGrille[i].Add(thirdQuarter[i - k][j - k]);
                }
            }

            for (int i = k; i < k * 2; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    numGrille[i].Add(fourthQuarter[i - k][j]);
                }
            }

            return numGrille;
        }

        private List<List<int>> MarkNumbers(List<List<int>> numGrille)
        {
            var result = numGrille.Clone();
            int N = result.Count;
            for (int n = 1; n <= (N * N); n++)
            {
                bool markingPlaceFound = false;
                var rnd = new Random();
                int quarterNumMark = rnd.Next(0, 4);
                int foundNum = -1;
                int i = 0;
                int j = 0;
                while (i < N && !markingPlaceFound)
                {
                    j = 0;
                    while (j < N && !markingPlaceFound)
                    {
                        if (result[i][j] == n)
                        {
                            foundNum++;
                            if (foundNum == quarterNumMark)
                                markingPlaceFound = true;
                        }
                        if (!markingPlaceFound)
                            j++;
                    }
                    if (!markingPlaceFound)
                        i++;
                }

                if (markingPlaceFound)
                    result[i][j] = -1;
            }
            return result;
        }
    }
}
