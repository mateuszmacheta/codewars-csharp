using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static class Primes
{
    static Primes()
    {
        Dictionary<int, bool> numbers = new Dictionary<int, bool>();

        int n = 20000000;

        foreach (var num in Enumerable.Range(2, n))
        {
            numbers.Add(num, true);
        }

        // commencing sieve

        for (int p = 2; p * p <= n; p++)
        {
            if (numbers[p])
            {
                for (int i = p * p; i <= n; i += p)
                {
                    numbers[i] = false;
                }
            }
        }

        PrimeNums = new List<int>(numbers.Where(e => e.Value == true).Select(e => e.Key));
    }
    public static List<int> PrimeNums { get; set; }
    public static IEnumerable<int> Stream()
    {
        return PrimeNums;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Console.WriteLine(string.Join("\n", Primes.Stream().TakeLast(10)));
        sw.Stop();
        System.Console.WriteLine($"elapsed time: {sw.ElapsedMilliseconds}");
    }
}