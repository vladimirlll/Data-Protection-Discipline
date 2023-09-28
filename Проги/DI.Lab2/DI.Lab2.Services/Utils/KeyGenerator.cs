using System;
using System.Collections.Generic;
using System.Linq;

namespace DI.Lab2.Services.Utils
{
    public static class KeyGenerator
    {
        public static IEnumerable<int> Generate(double T, double t)
        {
            int n = int.Parse(Math.Truncate(T / t).ToString());
            var result = Enumerable.Range(0, n);
            while (result.OrderBy(x => x).SequenceEqual(result))
            {
                Random rnd = new Random();
                result = Enumerable.Range(0, n)
                    .OrderBy(i => rnd.Next())
                    .ToList();
            }
            return result;
        }
    }
}
