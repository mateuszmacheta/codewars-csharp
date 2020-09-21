using System;

namespace color_choose
{
    class Program
    {
        static int fact(int x)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot compute factorial of negative number.");
            }
            if (x == 0 || x == 1)
            {
                return 1;
            }
            return x * fact(x - 1);
        }
        public static long Checkchoose(long m, int n)
        {
            long numerator = fact(n);
            for (int x = 0; x <= n / 2; x++)
            {
                long denominator = fact(n - x) * fact(x);
                if (m == Math.Round((Double)(numerator / denominator)))
                { return x; }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Checkchoose(1716, 13));
        }
    }
}
