using System;

public static class Kata
{
    public static int Score(int[] dice)
    {
        var count = new int[6];
        var score = 0;
        foreach (var roll in dice)
        {
            count[roll - 1]++;
        }

        for (int i = 0; i < 6; i++)
        {
            switch (i + 1)
            {
                case 1:
                    score += (count[i] % 3) * 100 + (count[i] / 3) * 1000;
                    break;
                case 5:
                    score += (count[i] % 3) * 50 + (count[i] / 3) * 500;
                    break;
                default:
                    score += (i + 1) * (count[i] / 3) * 100;
                    break;
            }
        }

        return score;
    }
}
class Program
{
    static void Main(string[] args)
    {
        //        var test = new int[] { 4, 4, 4, 3, 3 };
        var test = new int[] { 1, 1, 1, 1, 3 };

        System.Console.WriteLine(Kata.Score(test));
    }
}
