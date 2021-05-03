using System;
using System.Collections.Generic;
using System.Linq;
using Interval = System.ValueTuple<int, int>;

public class Intervals
{
    public static int SumIntervals((int, int)[] intervals)
    {
        var integers = new HashSet<int>();
        foreach (var interval in intervals)
        {
            var range = Enumerable.Range(interval.Item1, interval.Item2 - interval.Item1);
            foreach (var integer in range)
            {
                //System.Console.WriteLine(integer);
                integers.Add(integer);
            }

        }
        return integers.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Intervals.SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
    }
}
