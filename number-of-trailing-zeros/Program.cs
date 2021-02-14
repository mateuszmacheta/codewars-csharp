using System;

public static class Kata
{
    public static int TrailingZeros(int n)
    {
        int sum = 0;
        for (int i = 0; i < Math.Log(n, 5); i++)
        {
            sum += (int)(n / Math.Pow(5, i + 1));
        }
        return sum;
    }
}
class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i < 17; i++)
        {
            Console.WriteLine("n: {0}, result: {1}", i, Kata.TrailingZeros(i));
        }
    }
}
