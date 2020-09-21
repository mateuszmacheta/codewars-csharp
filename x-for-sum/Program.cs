using System;
using System.Collections.Generic;
using System.Linq;

namespace x_for_sum
{
    class Program
    {
        public static double Solve(double m)
        {
            double step = 0.2;
            double e = 1e-12;
            double diff = 0.0;
            int n = 50;
            double sum;

            approx approximator = new approx(0, 1, e, m, n);

            if (approximator.getApprox())
            { return approximator.result; }
            else
            { return -1; }
        }

        //         private static object[3] getRange(int start, int end, double step)
        //         {
        //             List<Tuple<bool, double>> positive = new List<Tuple<bool, double>> { };

        //             while (true)
        //             {
        //                 positive.Clear();
        //                 step /= 2;
        //                 for (double i = step; i < 1; i += step)
        //                 {
        //                     diff = getM(i, n) - m;
        //                     if (Math.Abs(diff) < e)
        //                     { return i; }
        //                     positive.Add(new Tuple<bool, double>(diff > 0, i));

        //                     if (positive.Count(c => c.Item1) > 0 && positive.Count(c => !c.Item1) > 0)
        //                     {
        //                         return positive[positive.Count - 2].Item2, positive.Last().Item2);
        //             }
        //         }
        //     }
        // }

        // }

        //         }

        //         private static double getM(double x, int n)
        // {
        //     return x * (1 - (n + 1) * Math.Pow(x, n) + n * Math.Pow(x, n + 1)) / Math.Pow(1 - x, 2);
        // }

        static void Main(string[] args)
        {
            Console.WriteLine(Solve(4.0));
        }
    }
}
