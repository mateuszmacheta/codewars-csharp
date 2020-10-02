using System;
using System.Collections.Generic;
using System.Linq;

namespace simple_time_difference
{
    class Program
    {
        public static string solve(string[] arr)
        {
            var dates = new List<DateTime>();
            foreach (string s in arr)
            {
                dates.Add(new DateTime(DateTime.Today.Year,
                DateTime.Today.Month,
                DateTime.Today.Day,
                Int32.Parse(s.Substring(0, 2)),
                Int32.Parse(s.Substring(3, 2)),
                0));
            }
            dates = dates.OrderBy(x => x).ToList();
            dates.Add(dates[0].AddDays(1));
            var differences = new List<TimeSpan>();
            differences = dates.Take(dates.Count() - 1).Select((v, index) => dates[index + 1] - v).ToList();
            TimeSpan longestBreak = differences.OrderByDescending(x => x).First().Add(TimeSpan.FromMinutes(-1));
            return longestBreak.ToString().Substring(0, 5);
        }
        static void Main(string[] args)
        {
            var test = new string[] { "14:51" };
            Console.WriteLine(solve(test));
        }
    }
}
