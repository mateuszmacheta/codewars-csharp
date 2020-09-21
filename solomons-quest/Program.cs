using System;
using System.Linq;

namespace solomons_quest
{
    class Program
    {
        public static int[] SolomonsQuest(int[][] ar)
        {
            int[] coords = new int[] { 0, 0 };
            int level = 0;
            foreach (int[] coordinate in ar)
            {
                level += coordinate[0];
                switch (coordinate[1])
                {
                    case 0: // North
                        coords[1] += coordinate[2] * (int)Math.Pow(2.0, level);
                        break;
                    case 2: // South
                        coords[1] -= coordinate[2] * (int)Math.Pow(2.0, level);
                        break;
                    case 1: // East
                        coords[0] += coordinate[2] * (int)Math.Pow(2.0, level);
                        break;
                    case 3:
                        coords[0] -= coordinate[2] * (int)Math.Pow(2.0, level);
                        break;
                    default:
                        throw new Exception("Incorrect coordinate code.");
                }
            }
            return coords;
        }

        static void Main(string[] args)
        {
            var test = new int[][] { new[] { 1, 3, 5 }, new[] { 2, 0, 10 }, new[] { -3, 1, 4 }, new[] { 4, 2, 4 }, new[] { 1, 1, 5 }, new[] { -3, 0, 12 }, new[] { 2, 1, 12 }, new[] { -2, 2, 6 } };
            var result = SolomonsQuest(test);
        }
    }
}
