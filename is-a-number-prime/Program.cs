using System;

namespace codewars_is_a_number_prime
{
    class Program
    {
        public static bool IsPrime(int n)
        {
            if (n == 1 || n == 0)
            { return false; }
            int divisor = 2;
            double root = Math.Sqrt(n);
            while (divisor <= root)
            {
                double quotient = n / divisor;
                if (Math.Floor(quotient) == quotient)
                {
                    return false;
                }
                else { divisor++; }
            }
            return true;
        }
        static void Main(string[] args)
        {
            bool result = IsPrime(5);
            Console.WriteLine("{0}", result);
        }
    }
}
