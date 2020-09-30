using System;
using System.Linq;

namespace casino_chips
{
    class Program
    {

        public static int solve(int[] arr)
        {
            Console.WriteLine("{0} {1} {2}", arr[0], arr[1], arr[2]);
            // arr = arr.OrderByDescending(x => x).ToArray();
            // int xMax = arr[0]; int xMid = arr[1]; int xMin = arr[2];

            // if (xMin + xMid >= xMax) { return (xMax + xMid + xMin) / 2; }
            // return (xMin + xMid) / 2;
            arr = arr.OrderByDescending((x, y) => x - y).ToArray();
            return 0;
        }
        static void Main(string[] args)
        {
            //var test = new int[] { 1, 1, 1 };
            var test = new int[] { 10, 7, 4 };
            Console.WriteLine(solve(test));
        }
    }
}