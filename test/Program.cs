using System;

namespace test
{
    class Program
    {
        public static (int, int) solve(int s, int g)
        {
            int num = g; int num2;
            while (num < s)
            {
                num2 = s - num;
                if ((float)num2 / g % 1 == 0)
                { return num <= num2 ? (num, num2) : (num2, num); }
                num += g;
            }
            return (-1, -1);
        }

        static void Main(string[] args)
        {
            //var test = new List<int> { 15, 11, 10, 7, 8 };
            System.Console.WriteLine(solve(10, 3));
        }

    }

}
