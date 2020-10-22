using System;
using System.Linq;

namespace alphabetic_anagrams
{
    class Program
    {
        public static long ListPosition(string value)
        {
            if (value.Length <= 1) { return 1; }
            var letters = value.GroupBy(e => e);
            long maxComb = factorial(letters.Count());
            foreach (var letter in letters)
            {
                maxComb /= letter.Count();
            }
            // check if sorted:
            var sorted = value.SkipLast(1).Zip(value.Skip(1), (a, b) => a - b);
            if (sorted.All(e => e <= 0))
            { return 1; }
            if (sorted.All(e => e >= 0))
            { return maxComb; }


        }

        public static long factorial(long x)
        {
            if (x == 1 || x == 0) { return 1; }
            return x * factorial(x - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ListPosition("EDCBA"));
        }
    }
}
