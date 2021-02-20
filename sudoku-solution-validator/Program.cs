using System;
using System.Collections.Generic;

public class Sudoku
{
    private const int ROWCOUNT = 9;

    private const int COLCOUNT = 9;

    private const int BLOCKSIZE = 3;

    private static bool validateSection(int[][] board, List<Tuple<int, int>> coords)
    {
        bool[] numbers = new bool[10];
        int currNumber, x, y;
        foreach (var coord in coords)
        {
            y = coord.Item1;
            x = coord.Item2;
            currNumber = board[y][x];
            if (numbers[currNumber] || currNumber == 0)
                return false;
            else
                numbers[currNumber] = true;
        }

        return true;
    }
    public static bool ValidateSolution(int[][] board)
    {
        List<Tuple<int, int>> coords = new List<Tuple<int, int>>();

        // validate rows
        for (int y = 0; y < ROWCOUNT; y++)
        {
            for (int x = 0; x < COLCOUNT; x++)
            {
                coords.Add(new Tuple<int, int>(y, x));
            }
            if (!validateSection(board, coords))
                return false;
            coords.Clear();
        }

        // validate columns
        for (int x = 0; x < COLCOUNT; x++)
        {
            for (int y = 0; y < ROWCOUNT; y++)
            {
                coords.Add(new Tuple<int, int>(y, x));
            }
            if (!validateSection(board, coords))
                return false;
            coords.Clear();
        }

        // validate squares

        for (int x = 0; x < COLCOUNT; x++)
        {
            for (int y = 0; y < ROWCOUNT; y++)
            {
                for (int i = 0; i < BLOCKSIZE; i++)
                {
                    for (int j = 0; j < BLOCKSIZE; j++)
                    {
                        coords.Add(new Tuple<int, int>(3 * y + j, 3 * x + i));
                    }
                }
                if (!validateSection(board, coords))
                    return false;
                coords.Clear();
            }
        }


        return true;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var testTrue = new int[][]
        {
          new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
          new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
          new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
          new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
          new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
          new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
          new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
          new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
          new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
        };
        Console.WriteLine(Sudoku.ValidateSolution(testTrue));
    }
}
