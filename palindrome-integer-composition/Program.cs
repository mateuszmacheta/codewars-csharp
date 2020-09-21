using System;
using System.Linq;
using System.Collections.Generic;

namespace codewars_palindrome_integer_composition
{
    class Program
    {
        public static string Reverse(string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        public static List<int> assertSquareSums(int[] squares, int n)
        {
            List<int> outList = new List<int>();
            int squareCount = squares.Count() - 1;
            //Console.WriteLine("squareCount: {0}", squareCount);
            // all ranges of consecutive numbers from 2 up to count - 1
            for (int range = 2; range < squareCount - 1; range++)
            {
                // all shift
                for (int shift = 1; shift < squareCount - range + 1; shift++)
                {
                    //Console.WriteLine("range: {0}, shift: {1}", range, shift);
                    int sum = 0;
                    // sum all consec numbers
                    for (int i = 0; i < range; i++)
                    {
                        //Console.WriteLine(shift + i);
                        sum += squares[shift + i];
                    }
                    if (sum <= n && (sum.ToString() == Reverse(sum.ToString())))
                    {
                        //Console.WriteLine(sum);
                        outList.Add(sum);
                    }
                    else if (sum > n)
                    { break; }
                }

            }

            return outList;
        }
        public static int values(int n)
        {

            List<int> result = new List<int>();
            int maxSquareBase = Convert.ToInt32(Math.Floor(Math.Sqrt(n)));
            int[] squares = new int[maxSquareBase + 1];
            for (int i = 1; i <= maxSquareBase; i++)
            { squares[i] = Convert.ToInt32(Math.Pow(i, 2)); }

            result = assertSquareSums(squares, n);
            return result.Distinct().Count();
        }
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("answer: {0}", values(100));
            Console.WriteLine("answer: {0}", values(200));
            Console.WriteLine("answer: {0}", values(300));
            Console.WriteLine("answer: {0}", values(400));
            Console.WriteLine("answer: {0}", values(1000));
            Console.WriteLine("answer: {0}", values(10000000));
            watch.Stop();
            Console.WriteLine("time: {0}ms", watch.ElapsedMilliseconds);
        }
    }
}
