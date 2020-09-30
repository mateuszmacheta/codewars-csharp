using System;

namespace simple_square_numbers
{
    class Program
    {
        public static long solve(long n)
        {
            if (n <= 1) { return -1; }
            double test = (double)(n - 1) / 2;
            if (test % 1 == 0)
            { return (long)Math.Pow(test, 2); }
            return -1;
        }
        static void Main(string[] args)
        {
            var test = new long[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 13, 17, 88901, 290101 };
            foreach (var item in test)
            {
                Console.WriteLine("{0} e: {1}", item, solve(item));
            }

        }
    }
}
