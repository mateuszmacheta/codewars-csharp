using System;
using System.Collections.Generic;
using System.Numerics;

namespace mixbonacci
{
    class Program
    {
        public static BigInteger[] Mixbonacci(string[] pattern, int length)
        {
            Dictionary<string, int> counts = new Dictionary<string, int> {
                {"fib",0},
                {"pad",0},
                {"jac",0},
                {"pel",0},
                {"tri",0},
                {"tet",0}
            };
            List<BigInteger> output = new List<BigInteger> { };
            string seqName = "";
            for (int i = 0; i < length; i++)
            {
                seqName = pattern[i % pattern.Length];
                output.Add((BigInteger)typeof(Program).GetMethod(seqName).Invoke(null, new object[] { counts[seqName]++ }));
            }
            return output.ToArray();
        }

        public static BigInteger fib(int n)
        {
            if (n == 0)
            { return 0; }
            if (n == 1)
            { return 1; }
            return fib(n - 2) + fib(n - 1);
        }

        public static BigInteger pad(int n)
        {
            if (n == 0)
            { return 1; }
            if (n == 1)
            { return 0; }
            if (n == 2)
            { return 0; }
            return pad(n - 3) + pad(n - 2);
        }

        public static BigInteger jac(int n)
        {
            if (n == 0)
            { return 0; }
            if (n == 1)
            { return 1; }
            return 2 * jac(n - 2) + jac(n - 1);
        }

        public static BigInteger pel(int n)
        {
            if (n == 0)
            { return 0; }
            if (n == 1)
            { return 1; }
            return pel(n - 2) + 2 * pel(n - 1);
        }

        public static BigInteger tri(int n)
        {
            if (n == 0)
            { return 0; }
            if (n == 1)
            { return 0; }
            if (n == 2)
            { return 1; }
            return tri(n - 3) + tri(n - 2) + tri(n - 1);
        }

        public static BigInteger tet(int n)
        {
            if (n == 0)
            { return 0; }
            if (n == 1)
            { return 0; }
            if (n == 2)
            { return 0; }
            if (n == 3)
            { return 1; }
            return tet(n - 4) + tet(n - 3) + tet(n - 2) + tet(n - 1);
        }
        static void Main(string[] args)
        {
            var test = "";
            Console.WriteLine(Mixbonacci(new string[] { "fib", "fib", "pel" }, 6));
        }
    }
}
