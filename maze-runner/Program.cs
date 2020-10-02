using System;
using System.Linq;

namespace maze_runner
{
    class Program
    {
        public static string mazeRunner(int[,] maze, string[] directions)
        {
            int Lim = maze.GetUpperBound(0);
            int[] currPos = new int[] { -1, -1 };
            int currTile = -1;

            for (int i = 0; i <= Lim; i++)
            {
                for (int j = 0; j <= Lim; j++)
                {
                    if (maze[i, j] == 2)
                    {
                        currPos[0] = j;
                        currPos[1] = i;
                    }
                }
            }
            if (currPos[0] == -1) { return "Lost"; }

            for (int i = 0; i < directions.Length - 1; i++)
            {
                switch (directions[i])
                {
                    case "N":
                        currPos[1]--;
                        break;
                    case "S":
                        currPos[1]++;
                        break;
                    case "E":
                        currPos[0]++;
                        break;
                    case "W":
                        currPos[0]--;
                        break;
                    default:
                        return "Lost";
                }
                if (currPos[0] < 0 || currPos[0] > Lim || currPos[1] < 0 || currPos[1] > Lim)
                { return "Dead"; }
                currTile = maze[currPos[1], currPos[0]];

                if (currTile == 1) { return "Dead"; }
            }
            if (currTile == 3) { return "Finish"; }
            return "Lost";
        }
        static void Main(string[] args)
        {
            var test = new int[,] { { 1, 1, 1, 1, 1, 1, 1 },
                                       { 1, 0, 0, 0, 0, 0, 3 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 0, 0, 1, 0, 0, 0, 1 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 1, 0, 0, 0, 0, 0, 1 },
                                       { 1, 2, 1, 0, 1, 0, 1 } };
            var test2 = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E" };
            Console.WriteLine(mazeRunner(test, test2));
        }
    }
}
