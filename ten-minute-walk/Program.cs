using System;
using System.Collections.Generic;

namespace ten_minute_walk
{
    class Program
    {
        public static bool IsValidWalk(string[] walk)
        {
            if (walk.Length != 10)
            { return false; }
            Dictionary<string, int[]> toXY = new Dictionary<string, int[]>{
                {"e", new int[]{ 1, 0}},
                {"w", new int[]{ -1, 0}},
                {"n", new int[]{ 0, 1}},
                {"s", new int[]{ 0, -1}}
            };
            int x = 0, y = 0;
            foreach (string direction in walk)
            {
                x += toXY[direction][0];
                y += toXY[direction][1];
            }
            return (x == 0 && y == 0);
        }
        static void Main(string[] args)
        {
            var test = new string[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" };
            Console.WriteLine(IsValidWalk(test));
        }
    }
}
