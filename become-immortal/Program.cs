using System;

namespace become_immortal
{
    class Program
    {
        public static long ElderAge(long n, long m, long k, long newp)
        {
            int[,] array = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = j ^ i;
                }
            }
            Program.Print(array);
            return 0; // do it!
        }

        private static void Print(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                //int rowSum = 0;
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{array[i, j]} ");
                    //rowSum += array[i, j];
                }
                System.Console.WriteLine();
                //System.Console.WriteLine($"{rowSum}");
            }
        }

        static void Main(string[] args)
        {
            //var test = (8, 5, 1, 100);
            Console.WriteLine(ElderAge(34, 2, 1, 100));
        }
    }
}
