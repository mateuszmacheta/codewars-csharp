using System;
using System.Linq;
using System.Collections.Generic;

public class Kata
{
    public static Dictionary<char, int> Count(string str)
    {
        return str.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Kata.Count("Hello World!"));
    }
}

