using System;

namespace codewars_sandbox
{
    class Program
    {
        public static int solve(int[][] arr)
        {
            int max = int.MinValue, all = 1, prod, len;
            for (int y = 0; y < arr.GetUpperBound(0) + 1; y++)
            {
                all *= arr[y].GetUpperBound(0) + 1;
            }
            for (int i = 0; i < all; i++)
            {
                prod = 1; len = 1;
                for (int y = 0; y < arr.GetUpperBound(0) + 1; y++)
                {
                    //System.Console.Write($"{i / len % arr[y].Length}");
                    prod *= arr[y][i / len % arr[y].Length];
                    len *= arr[y].Length;
                }
                max = Math.Max(max, prod);
            }
            return max;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(solve(new int[][] { new int[] { -2, -15, -12, -8, -16 }, new int[] { -4, -15, -7 }, new int[] { -10, -5 } }));
        }
    }
}
