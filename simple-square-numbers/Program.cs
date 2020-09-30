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

            // for (long i = n; ; i /= 2)
            // {
            //     System.Console.WriteLine(n / i);
            // }

            // for (int i = 2; n / i >= 1; i *= 2)
            // {
            //     sqr = (long)Math.Pow(n / i, 2);
            //     System.Console.WriteLine($"i\t{i}\tsqr\t{sqr}");
            //     if (Math.Sqrt(n + sqr) % 1 == 0)

            //     { return sqr; }
            // }

            // for (int i = 1; i < n / 4 + 1; i++)
            // {
            //     sqr = (long)Math.Pow(i, 2);
            //     System.Console.WriteLine($"i\t{i}\tsqr\t{sqr}");
            //     if (Math.Sqrt(n + sqr) % 1 == 0)
            //     { return sqr; }
            // }
            // if (Math.Sqrt(n + (long)Math.Pow(n / 2, 2)) % 1 == 0)
            // { return (long)Math.Pow(n / 2, 2); }
            // if (Math.Sqrt(n + (long)Math.Pow(n / 2 + 1, 2)) % 1 == 0)
            // { return (long)Math.Pow(n / 2 + 1, 2); }
            return -1;
        }
        static void Main(string[] args)
        {
            var test = Enumerable.Range(1, 17).Select(x => (long)x).ToArray(); ;

            System.Console.WriteLine(solve(5));
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
