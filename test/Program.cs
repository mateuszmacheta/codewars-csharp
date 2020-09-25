using System.Linq;
using System.Collections.Generic;
using System;

namespace test
{
    class Program
    {
        public static int Repeats(List<int> source)
        {
            int sum = 0;
            foreach (var group in source.GroupBy(x => x))
            {
                if (group.Count() == 1)
                { sum += group.Key; }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            var test = new List<int> { 4, 5, 7, 5, 4, 8 };
            System.Console.WriteLine(Repeats(test));
        }

    }
}