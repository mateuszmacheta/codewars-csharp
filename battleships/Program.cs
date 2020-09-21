using System;
using System.Collections.Generic;

namespace battleships
{
    class Program
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            // set number of valid ships
            // index = number of segments, for example 
            int[] validCounts = new int[5] { 0, 4, 3, 2, 1 };
            int[] actualCounts = new int[5] { 0, 0, 0, 0, 0 };

            BattleshipField.Draw(field);

            int rows = 10;
            int cols = 10;

            bool[,] checkArray = new bool[10, 10] {
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
                {false,false,false,false,false,false,false,false,false,false},
            };

            // check if all ships are properly placed by validating if no ship segments touch diagonally
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j] == 0)
                    { continue; }
                    // validate diagonally up
                    if (i - 1 > 0)
                    {
                        if (j - 1 > 0 && field[i - 1, j - 1] == 1)
                        {
                            return false;
                        }
                        if (j + 1 < cols && field[i - 1, j + 1] == 1)
                        {
                            return false;
                        }
                    }
                    // validate diagonally down
                    if (i + 1 < rows)
                    {
                        if (j - 1 > 0 && field[i + 1, j - 1] == 1)
                        {
                            return false;
                        }
                        if (j + 1 < cols && field[i + 1, j + 1] == 1)
                        {
                            return false;
                        }
                    }
                }
            }

            // count ships vertically going through each column

            for (int j = 0; j < cols; j++)
            {
                int shipLen = 0;
                for (int i = 0; i < rows - 1; i++)
                {
                    // if empty we skip
                    if (field[i, j] == 0) { continue; }
                    // if horizontally aligned - we have segment on the left OR on the right - we also skip
                    else if (((j - 1 > 0) && field[i, j - 1] == 1) || ((j + 1 < cols) && field[i, j + 1] == 1))
                    { continue; }

                    if (field[i + 1, j] == 1)
                    { shipLen++; }
                    else
                    {
                        checkArray[i, j] = true;
                        shipLen++;
                        actualCounts[shipLen]++;
                        if (!BattleshipField.validCounts(validCounts, actualCounts, false))
                        { return false; };
                        shipLen = 0;
                        i++;
                    }
                }
            }

            // count ships horizontally - this time we also check if segment has been checked previously

            for (int i = 0; i < rows; i++)
            {
                int shipLen = 0;
                for (int j = 0; j < cols - 1; j++)
                {
                    // if empty or checked we skip
                    if (field[i, j] == 0 || checkArray[i, j]) { continue; }
                    // if vertically aligned - we have segment at the top OR at the bottom - we also skip
                    else if (((i - 1 > 0) && field[i - 1, j] == 1) || ((i + 1 < rows) && field[i + 1, j] == 1))
                    { continue; }

                    if (field[i, j + 1] == 1)
                    { shipLen++; }
                    else
                    {
                        shipLen++;
                        actualCounts[shipLen]++;
                        if (!BattleshipField.validCounts(validCounts, actualCounts, false))
                        { return false; };
                        shipLen = 0;
                        j++;
                    }
                }
            }

            return BattleshipField.validCounts(validCounts, actualCounts, true);
        }

        private static bool validCounts(int[] validCounts, int[] actualCounts, bool exact)
        {
            // validates if we do not exceed required count of ships
            if (!exact)
            {
                for (int i = 0; i < validCounts.Length; i++)
                {
                    if (actualCounts[i] > validCounts[i])
                    { return false; }
                }
            }
            // validates if we have exact count of ships in the end
            else
            {
                for (int i = 0; i < validCounts.Length; i++)
                {
                    if (actualCounts[i] != validCounts[i])
                    { return false; }
                }
            }
            return true;
        }

        public static void Draw(int[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);
            Dictionary<int, string> drawDict = new Dictionary<int, string>{
                {0, "░ "},
                {1,"█ "}
            };
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    System.Console.Write(drawDict[field[i, j]]);
                }
                System.Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {
            var test = new int[10, 10]
                {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Console.WriteLine(ValidateBattlefield(test));
        }

    }
}