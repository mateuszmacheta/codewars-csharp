using System;
using System.Collections.Generic;

namespace build_a_pile_of_cubes
{
    public static class ASum
    {
        static ASum()
        {
            list = new Dictionary<long, long>();
            long n = 1; long sum = 1;
            while (sum < long.MaxValue - Math.Pow(n + 1, 3))
            {
                list.Add(sum, n);
                sum += (long)Math.Pow(++n, 3);
            }
        }
        public static Dictionary<long, long> list { get; set; }

        public static long findNb(long m)
        {
            return list.ContainsKey(m) ? list[m] : -1;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(ASum.findNb(1));
        }
    }
}
