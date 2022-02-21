using System;
using System.Linq;

public class Rank
{
    public static string NthRank(string st, int[] we, int n)
    {
        if (n > we.Length)
            return "Not enough participants";
        if (string.IsNullOrEmpty(st))
            return "No participants";
        var weightedResults = st.Split(',', System.StringSplitOptions.RemoveEmptyEntries)
        .Select((e, i) => new { name = e, weight = evaluateScore(e, we[i]) });
        return weightedResults.OrderByDescending(e => e.weight)
        .ThenBy(e => e.name)
        .Skip(n - 1)
        .First().name;
    }
    private static int evaluateScore(string name, int weight)
    {
        int score = name.Length;
        foreach (var letter in name.ToLower())
        {
            score += letter - 96;
        }
        return score * weight;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var names = "COLIN,AMANDBA,AMANDAB,CAROL,PauL,JOSEPH";
        var weights = new int[] { 1, 4, 4, 5, 2, 1 };
        var n = 1;
        Console.WriteLine(Rank.NthRank(names, weights, n));
    }
}
