using System.Runtime.CompilerServices;
using System.Text;

namespace DP.Lab5.Service.Extensions
{
    public static class MatrixIEnumerableExtensions
    {
        public static List<List<T>> Clone<T>(this IEnumerable<IEnumerable<T>> matrix)
        {
            var result = new List<List<T>>();
            foreach (var row in matrix)
            {
                result.Add(new List<T>());
                foreach (var item in row)
                {
                    result[result.Count - 1].Add(item);
                }
            }
            return result;
        }

        public static IEnumerable<IEnumerable<T>> RotateOn90DegClockwise<T>(this IEnumerable<IEnumerable<T>> matrix)
        {
            var result = matrix.Select(row => row.ToList()).ToList().Clone();
            int N = result.Count;

            result = result.Transpone().Select(row => row.ToList()).ToList();

            result = result.TurnOver().Select(row => row.ToList()).ToList();

            return result;
        }

        public static IEnumerable<IEnumerable<T>> Transpone<T>(this IEnumerable<IEnumerable<T>> matrix)
        {
            var matrixList = matrix.Select(row => row.ToList()).ToList().Clone();
            var result = new List<List<T>>();
            int N = matrixList.Count;

            // Транспонирование матрицы
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var temp = matrixList[i][j];
                    matrixList[i][j] = matrixList[j][i];
                    matrixList[j][i] = temp;
                }
            }

            return matrixList;
        }

        public static IEnumerable<IEnumerable<T>> TurnOver<T>(this IEnumerable<IEnumerable<T>> matrix)
        {
            var result = matrix.Select(row => row.ToList()).ToList().Clone();
            int N = result.Count;

            // Поменять столбцы местами (сначала дальние между собой, потом которые перед дальними и тд)
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N / 2; j++)
                {
                    var temp = result[i][j];
                    result[i][j] = result[i][N - j - 1];
                    result[i][N - j - 1] = temp;
                }
            }

            return result;
        }

        public static string ToStr(this IEnumerable<IEnumerable<char>> matrix)
        {
            var builder = new StringBuilder();
            foreach (var row in matrix)
            {
                builder.Append(Environment.NewLine);
                builder.Append("|");
                foreach (var item in row)
                {
                    if (item == ' ') builder.Append("_");
                    else builder.Append(item);
                }
                builder.Append("|");
            }
            return builder.ToString();
        }
    }
}
