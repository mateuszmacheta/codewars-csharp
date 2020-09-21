using System;

namespace parabolic_arc_length
{

    class Program
    {
        public static double lenCurve(int n)
        {
            double step = 1.0 / n;
            double len = 0.0;
            for (int i = 0; i < n; i++)
            {
                //System.Console.WriteLine("{0:f}", step * i);
                double x0 = step * i;
                double y0 = x0 * x0;
                double x1 = step * (i + 1);
                double y1 = x1 * x1;

                len += Math.Sqrt(Math.Pow(step, 2) + Math.Pow(y1 - y0, 2));
            }
            return Math.Round(len, 9);
        }
        static void Main(string[] args)
        {
            var test = 1;
            Console.WriteLine(lenCurve(test));
        }
    }
}
