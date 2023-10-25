using System.Text;

namespace DP.Lab6.Presentational
{
    public static class MatrixExtensions
    {
        public static string GetStringRepresentation(this List<List<char>> table)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < table.Count; i++)
            {
                for (int j = 0; j < table[i].Count; j++)
                {
                    builder.Append(table[i][j] + "\t");
                }
                builder.Append("\n");
            }

            return builder.ToString();
        }
    }
}
