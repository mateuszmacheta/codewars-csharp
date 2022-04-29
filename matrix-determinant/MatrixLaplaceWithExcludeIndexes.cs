using System;
using System.Linq;
using System.Collections.Generic;

public class MatrixLaplaceWithExcludeIndexes
{
    private static int[][] matrix;

    public static int Determinant(int[][] Matrix)
    {
        drawMatrix(Matrix);
        System.Console.WriteLine("********");
        List<int> columns = new List<int>();
        List<int> rows = new List<int>();
        matrix = (int[][])Matrix.Clone();
        return DeterminantRecursive(rows, columns);
    }
    public static int DeterminantRecursive(List<int> rows, List<int> columns)
    {
        // System.Console.WriteLine(getItemAtYX(0, 0, new List<int>() { 0 }, new List<int>() { 1 }));
        // System.Console.WriteLine(getItemAtYX(0, 0, new List<int>() { 0 }, new List<int>() { 0 }));
        // System.Console.WriteLine(getItemAtYX(0, 1, new List<int>() { 1 }, new List<int>() { 1 }));

        int matrixSize = matrix.GetLength(0) - rows.Count;
        if (matrixSize > 3)
        {
            int determinant = 0;
            for (int y = 0; y < matrixSize; y++)
                for (int x = 0; x < matrixSize; x++)
                {
                    if (matrix[y][x] != 0)
                    {
                        //determinant += (int)Math.Pow(-1, x + y) * getItemAtYX(y, x, rows, columns) *
                        //Matrix.DeterminantRecursive(rows.Concat(new List<int>() { y }).ToList(), columns.Concat(new List<int>() { x }).ToList());
                    }
                }
            return determinant;
        }
        else if (matrixSize == 3) // Sarrus method
        {
            int positiveFactors = matrix[0][0] * matrix[1][1] * matrix[2][2] + matrix[0][1] * matrix[1][2] * matrix[2][0] + matrix[0][2] * matrix[1][0] * matrix[2][1];
            int negativeFactors = -matrix[0][2] * matrix[1][1] * matrix[2][0] - matrix[0][0] * matrix[1][2] * matrix[2][1] - matrix[0][1] * matrix[1][0] * matrix[2][2];
            return positiveFactors + negativeFactors;
        }
        else if (matrixSize == 2)
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        else
            return matrix[0][0];
    }

    private static int getItemAtYX(int y, int x, List<int> rows, List<int> columns)
    {
        return matrix[y + rows.Where(e => e <= y).Count()][x + columns.Where(e => e <= x).Count()];
    }

    private static void drawMatrix(int[][] matrix)
    {
        int matrixSize = matrix.GetLength(0);
        for (int i = 0; i < matrixSize; i++)
            System.Console.WriteLine(string.Join("\t|\t", matrix[i]));
        System.Console.WriteLine();
    }
}