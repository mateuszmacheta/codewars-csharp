using System;
using System.Linq;
using System.Collections.Generic;

namespace most_frequent_weekdays
{
    class Program
    {
        public static string[] MostFrequentDays(int year)
        {
            Dictionary<DayOfWeek, int> topDays = new Dictionary<DayOfWeek, int>(){
                { DayOfWeek.Monday,0},
                { DayOfWeek.Tuesday,0},
                { DayOfWeek.Wednesday,0},
                { DayOfWeek.Thursday,0},
                { DayOfWeek.Friday,0},
                { DayOfWeek.Saturday,0},
                { DayOfWeek.Sunday,0}
            };
            DateTime day = new DateTime(year, 1, 1);
            while (day.Year == year)
            {
                topDays[day.DayOfWeek]++;
                day = day.AddDays(1);
            }
            int topDayCount = topDays.OrderByDescending(d => d.Value).First().Value;
            return topDays.Where(d => d.Value == topDayCount).Select(d => d.Key.ToString()).ToArray();
        }
        static void Main(string[] args)
        {
            var output = MostFrequentDays(2016);
            Console.WriteLine("hi");
        }
    }
}
