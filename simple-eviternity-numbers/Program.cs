using System;
using System.Collections.Generic;
using System.Linq;

namespace simple_eviternity_numbers
{
    class Program
    {

        public static int solve(int a, int b)
        {
            int sum = 0, cInt = 0;
            List<char> numbers = new List<char> { '8', '5', '3' };
            List<string> eviternityCandidates = new List<string>();
            int startDig = a.ToString().Length;
            int lastDig = b.ToString().Length;
            for (int i = startDig; i <= lastDig; i++)
            {
                eviternityCandidates.AddRange(CombinationsWithRepetition(numbers, i));
            }

            foreach (var candidate in eviternityCandidates)
            {
                cInt = Int32.Parse(candidate);
                if (cInt >= a && cInt < b && check(candidate))
                {
                    sum++;
                }
            }
            return sum;
        }

        // https://stackoverflow.com/a/25824818/13100603
        static IEnumerable<String> CombinationsWithRepetition(IEnumerable<char> input, int length)
        {
            if (length <= 0)
                yield return "";
            else
            {
                foreach (var i in input)
                    foreach (var c in CombinationsWithRepetition(input, length - 1))
                        yield return i.ToString() + c;
            }
        }
        public static bool check(string c)
        {
            return (c.Count(i => i == '8') >= c.Count(i => i == '5') && c.Count(i => i == '5') >= c.Count(i => i == '3'));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solve(0, 100));
        }
    }
}
