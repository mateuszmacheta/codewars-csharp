using System;
using System.Collections.Generic;

public class Kata
{
    public void drawMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                System.Console.Write(matrix[j, i].ToString() + ',');
            }
            System.Console.WriteLine();
        }
    }
    private IEnumerable<string> words;

    public Kata(IEnumerable<string> words)
    {
        this.words = words;
    }

    public int LevenshteinDistance(string s, string t)
    {
        int m = s.Length;
        int n = t.Length;
        int substitutionCost;
        int[,] d = new int[m + 1, n + 1];


        for (int i = 1; i <= m; i++)
            d[i, 0] = i;

        for (int i = 1; i <= n; i++)
            d[0, i] = i;

        for (int j = 1; j <= n; j++)
        {
            for (int i = 1; i <= m; i++)
            {
                substitutionCost = (s[i - 1] == t[j - 1] ? 0 : 1);
                d[i, j] = Math.Min(
                    d[i - 1, j] + 1,
                    Math.Min(d[i, j - 1] + 1,
                    d[i - 1, j - 1] + substitutionCost)
                );
            }
        }

        return d[m, n];
    }

    public string FindMostSimilar(string term)
    {
        string result = "";
        int minDistance = Int32.MaxValue; int distance;

        using (var sequenceEnum = words.GetEnumerator())
        {
            while (sequenceEnum.MoveNext())
            {
                distance = LevenshteinDistance(term, sequenceEnum.Current);
                if (distance < minDistance)
                {
                    result = sequenceEnum.Current;
                    minDistance = distance;
                }
            }
        }
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Kata kata = new Kata(new List<string> { "cherry", "pineapple", "melon", "strawberry", "raspberry" });
        Console.WriteLine(kata.FindMostSimilar("strawbery"));

    }
}

