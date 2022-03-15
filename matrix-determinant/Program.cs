﻿// 4 kyu Matrix Determinant
// https://www.codewars.com/kata/52a382ee44408cea2500074c

using System;

public class Matrix
{
    public static int Determinant(int[][] matrix)
    {
        int matrixSize = matrix.GetLength(0);
        if (matrixSize > 3)
        {
            int determinant = 0;
            for (int y = 0; y < matrixSize; y++)
                for (int x = 0; x < matrixSize; x++)
                {
                    if (matrix[y][x] != 0)
                        determinant += (int)Math.Pow(-1, x + y) * matrix[y][x] * Matrix.Determinant(minorMatrix(matrix, y, x));
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

    public static int[][] minorMatrix(int[][] matrix, int rowIndex, int colIndex)
    {
        int originalSize = matrix.GetLength(0);
        int minorSize = originalSize - 1;
        int[][] minorMatrix = new int[minorSize][];
        for (int y = 0; y < minorSize; y++)
            minorMatrix[y] = new int[minorSize];
        // populate minor matrix
        int i = 0, j = 0;
        for (int y = 0; y < originalSize; y++)
        {
            if (y == rowIndex)
                continue;
            j = 0;
            for (int x = 0; x < originalSize; x++)
            {
                if (x == colIndex)
                    continue;
                minorMatrix[i][j] = matrix[y][x];
                j++;
            }
            i++;
        }
        return minorMatrix;
    }

    private static void drawMatrix(int[][] matrix)
    {
        int matrixSize = matrix.GetLength(0);
        for (int i = 0; i < matrixSize; i++)
            System.Console.WriteLine(string.Join("\t|\t", matrix[i]));
        System.Console.WriteLine();
    }
}

namespace matrix_determinant
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] test3x3 = new int[][] { new[] { 2, 5, 3 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } };
            int[][] test2x2 = new int[][] { new[] { 1, 3 }, new[] { 2, 5 } };
            var output = Matrix.Determinant(test3x3);
            Console.WriteLine(output);
        }
    }
}
