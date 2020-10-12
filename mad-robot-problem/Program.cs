using System;
using System.Linq;
using System.Collections.Generic;

namespace mad_robot_problem
{
    class Program
    {

        public static char[] BoxVisibleDirections(string loadingHistory, int madRobotIndex)
        {
            List<char> result = new List<char>();

            // extract coordinates of each box from string to list of int tuples
            List<(int, int)> coords = new List<(int, int)>();
            string x, y;
            foreach (var coord in loadingHistory.Split(' '))
            {
                x = coord.Substring(0, coord.IndexOf(';'));
                y = coord.Substring(coord.IndexOf(';') + 1);
                coords.Add((int.Parse(x), int.Parse(y)));
            }

            int boxX, boxY;
            try
            {
                boxX = coords[madRobotIndex].Item1;
                boxY = coords[madRobotIndex].Item2;
            }
            catch
            {
                return new char[] { };
            }

            int boxHeight = coords.Take(madRobotIndex + 1).Count(e => e.Item1 == boxX && e.Item2 == boxY);

            // get highest value from maximum x or y for warehouse array dimentions
            int maxDimension = coords.Select(i => Math.Max(i.Item1, i.Item2)).Max() + 1;

            // make warhouse square, why not
            int[,] warehouse = new int[maxDimension, maxDimension];

            foreach (var coord in coords)
            {
                // add +1 to stack height where box is located
                warehouse[coord.Item1, coord.Item2]++;
            }

            printArr(warehouse);

            // check north
            if (boxY == 0) { result.Add('n'); }
            else
            {
                int max = -1;
                for (int i = 0; i < boxY; i++)
                {
                    max = Math.Max(max, warehouse[boxX, i]);
                }
                if (max < boxHeight && max >= 0) { result.Add('n'); }
            }

            // check west
            if (boxX == 0) { result.Add('w'); }
            else
            {
                int max = -1;
                for (int i = 0; i < boxX; i++)
                {
                    max = Math.Max(max, warehouse[i, boxY]);
                }
                if (max < boxHeight && max >= 0) { result.Add('w'); }
            }

            // check south
            if (boxY == maxDimension - 1) { result.Add('s'); }
            else
            {
                int max = -1;
                for (int i = maxDimension - 1; i > boxY; i--)
                {
                    max = Math.Max(max, warehouse[boxX, i]);
                }
                if (max < boxHeight && max >= 0) { result.Add('s'); }
            }

            if (boxX == maxDimension - 1) { result.Add('e'); }
            else
            {
                // check east
                int max = -1;
                for (int i = maxDimension - 1; i > boxX; i--)
                {
                    max = Math.Max(max, warehouse[i, boxY]);
                }
                if (max < boxHeight && max >= 0) { result.Add('e'); }
            }

            return result.ToArray();
        }

        public static void printArr(int[,] ware)
        {
            int maxD = ware.GetUpperBound(0);
            for (int i = 0; i < maxD; i++)
            {
                for (int j = 0; j < maxD; j++)
                {
                    System.Console.Write(ware[j, i] + " ");
                }
                System.Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(BoxVisibleDirections("0;0 5;5 5;0 5;5 5;3 5;3 5;5 4;5 4;3 4;5 5;7 5;6 5;7 5;7", 3));
        }
    }
}
