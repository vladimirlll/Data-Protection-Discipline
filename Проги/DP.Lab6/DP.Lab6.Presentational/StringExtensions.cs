using System.Text;

namespace DP.Lab6.Presentational
{
    public static class StringExtensions
    {
        public static string Unique(this string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var sym in str)
            {
                if (!builder.ToString().Contains(sym))
                    builder.Append(sym);
            }
            return builder.ToString();
        }

        public static string Exclude(this string s1, string s2)
        {
            return string.Concat(s1.Except(s2));
        }
    }
}
