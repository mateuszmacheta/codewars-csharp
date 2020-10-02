using System;
using System.Linq;

namespace simple_square_numbers
{
    class Program
    {
        public static long solve(long n)
        {
            //Console.WriteLine(n);
            if (n <= 1) { return -1; }
            long sqr;

            for (int i = (int)Math.Log(n, 2); i >= 1; i--)
            {
                sqr = (long)Math.Pow(n / Math.Pow(2, i), 2);
                if (Math.Sqrt(n + sqr) % 1 == 0)
                { return sqr; }
            }

            return -1;
        }
        static void Main(string[] args)
        {
            var test = Enumerable.Range(1, 17).Select(x => (long)x).ToArray(); ;

            System.Console.WriteLine(solve(3));
            // Console.WriteLine("n\te");
            // foreach (var item in test)
            // {
            //     Console.WriteLine("{0}\t{1}", item, solve(item));
            // }
            // using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\machetam\Desktop\out.txt"))
            // {
            //     foreach (var item in test)
            //     {
            //         file.WriteLine(string.Format("{0}\t{1}", item, solve(item)));
            //     }
            // }

        }
    }
}
