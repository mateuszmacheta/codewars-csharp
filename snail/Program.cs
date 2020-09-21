using System;
using System.Collections.Generic;

namespace snail
{
    class Program
    {
        public static int[] Snail(int[][] array)
        {
            int n = array[0].Length;
            if (n == 0)
            {
                return new int[0];
            }
            List<int> output = new List<int>();
            int counter = 0; int direction = 0; int x = -1; int y = 0, i;
            ///output.Add(array[0][0]);
            //System.Console.WriteLine(array[0][0]);
            while (n > 0)
            {
                direction = counter % 4;
                System.Console.WriteLine($"=== {direction} {counter} {n} ===");
                switch (direction)
                {
                    // 0 - right
                    case 0:
                        for (i = x + 1; i < x + n + 1; i++)
                        {
                            output.Add(array[y][i]);
                            System.Console.WriteLine(array[y][i]);
                            System.Console.WriteLine($"{y} {i}");
                        }
                        x = i - 1;
                        break;
                    // 1 - down
                    case 1:
                        for (i = y + 1; i < y + n + 1; i++)
                        {
                            output.Add(array[i][x]);
                            System.Console.WriteLine(array[i][x]);
                            System.Console.WriteLine($"{i} {x}");
                        }
                        y = i - 1;
                        break;
                    // 2 - left
                    case 2:
                        for (i = x - 1; i > x - n - 1; i--)
                        {
                            output.Add(array[y][i]);
                            System.Console.WriteLine(array[y][i]);
                            System.Console.WriteLine($"{y} {i}");
                        }
                        x = i + 1;
                        break;
                    // 3 - up
                    case 3:
                        for (i = y - 1; i > y - n - 1; i--)
                        {
                            output.Add(array[i][x]);
                            System.Console.WriteLine(array[i][x]);
                            System.Console.WriteLine($"{i} {x}");
                        }
                        y = i + 1;
                        break;
                }
                if (counter % 2 == 0)
                { n--; }
                counter++;
            };
            return output.ToArray();
        }
        static void Main(string[] args)
        {
            int[][] array ={
           new []{1, 2, 3},
           new []{4, 5, 6},
           new []{7, 8, 9}
       };
            /*var array = new int[][] {
                new []{1, 2, 3, 4},
                new []{4, 5, 6, 7},
                new []{7, 8, 9, 0},
                new []{ 7, 8, 9, 0},
        };*/
            Console.WriteLine("Hello World!{0}", Snail(array));
        }
    }
}
