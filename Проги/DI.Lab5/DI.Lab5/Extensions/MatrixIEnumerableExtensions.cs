using System.Text;

namespace DI.Lab5.Realization.Extensions
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
