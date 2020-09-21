using System;
using System.Linq;
using System.Collections.Generic;

namespace human_readable_duration
{
    class Program
    {
        public static string formatDuration(int seconds)
        {
            if (seconds == 0) { return "now"; }
            TimeSpan ts = new TimeSpan(0, 0, seconds);
            Dictionary<string, int> result = new Dictionary<string, int>();
            int years = seconds / 31536000;
            if (years != 0)
            {
                ts = ts.Add(new TimeSpan(0, 0, -years * 31536000));
                result.Add("year" + (years > 1 ? "s" : ""), years);
            }
            if (ts.Days != 0)
            { result.Add("day" + (ts.Days > 1 ? "s" : ""), ts.Days); }
            if (ts.Hours != 0)
            { result.Add("hour" + (ts.Hours > 1 ? "s" : ""), ts.Hours); }
            if (ts.Minutes != 0)
            { result.Add("minute" + (ts.Minutes > 1 ? "s" : ""), ts.Minutes); }
            if (ts.Seconds != 0)
            { result.Add("second" + (ts.Seconds > 1 ? "s" : ""), ts.Seconds); }
            string andLastOne = string.Format("{0} {1}", result.Last().Value, result.Last().Key);
            if (result.Count() == 1)
            { return andLastOne; }
            string commaSeparated = string.Join(", ", result.Take(result.Count() - 1).Select(x => $"{x.Value} {x.Key}"));
            return string.Join(" and ", new string[] { commaSeparated, andLastOne });
        }
        static void Main(string[] args)
        {
            Console.WriteLine(formatDuration(120));
        }
    }
}
