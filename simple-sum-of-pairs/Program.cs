using System;
using System.IO;

namespace simple_sum_of_pairs
{
    class Program
    {
        public static int solve(long n)
        {
            return (int)(n - 19) % 10 + 10 + (int)(n - 19) / 10 - (int)(Math.Floor((double)n + 1) / 100 - 1) * 9;
        }
        // public static int solve(long n)
        // {
        //     int sum, max = int.MinValue;
        //     long nearHalf = (long)Math.Ceiling((double)n / 2);
        //     long start = 0;
        //     for (long i = start; i <= nearHalf; i++)
        //     {
        //         sum = digitSum(i) + digitSum(n - i);
        //         max = Math.Max(max, sum);
        //     }
        //     return max;
        // }
        // public static int digitSum(long a)
        // {
        //     int sum = 0;
        //     foreach (var c in a.ToString())
        //     {
        //         sum += c - '0';
        //     }
        //     return sum;
        // }
        static void Main(string[] args)
        {
            System.Console.WriteLine(solve(50000000));
            // StreamWriter sw = new StreamWriter(@"C:\Users\machetam\Desktop\out.txt");
            // for (int i = 0; i < 1001; i++)
            // {
            //     sw.WriteLine($"{i} {solve(i)}");
            //     //Console.WriteLine($"{i} {solve(i)}");
            // }
            // sw.Close();
        }
    }
}
