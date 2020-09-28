using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace test
{
    class Program
    {
        public static BigInteger Choose(int n, int p)
        {
            if (p > n) { return 0; }
            return fastFactor(n, p) / factorial(n - p);
        }

        public static BigInteger fastFactor(int n, int k)
        {
            // computes n!/k!
            BigInteger product = 1;
            for (int i = k + 1; i <= n; i++)
            {
                product *= i;
            }
            return product;
        }

        public static BigInteger factorial(int n)
        {
            if (n == 0) { return 1; }
            BigInteger product = 1;
            for (int i = 2; i <= n; i++)
            {
                product *= i;
            }
            return product;
        }

        static void Main(string[] args)
        {
            //var test = new List<int> { 15, 11, 10, 7, 8 };
            System.Console.WriteLine(Choose(10, 20));
        }

    }

}
