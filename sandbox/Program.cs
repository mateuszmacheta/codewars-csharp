using System;
using System.Linq;

namespace codewars_sandbox
{
    class Program
    {
        public static bool isTriangleNumber(long x)
        {
            if (x == 0 || x == 1) { return true; }

            // need to find solution of this equation: n^2 + n -2x = 0
            // and the solution has to be a whole number
            // notice that there is only one positive solution, so we ignore the second one
            // the solution we search for is n_1 = [-1 - (1+8x)^1/2]/2 where 1+8x is our delta

            // let's check if root delta is a whole number
            long delta = 1 + 8 * x;
            double deltaSqrt = Math.Sqrt(delta);

            if (!(deltaSqrt % 1 == 0)) { return false; }

            // now we check if n_1 is a whole number
            return ((-1 - (long)deltaSqrt) / 2 % 1 == 0);

        }
        static void Main(string[] args)
        {

            System.Console.WriteLine(isTriangleNumber(125250));
        }
    }
}
