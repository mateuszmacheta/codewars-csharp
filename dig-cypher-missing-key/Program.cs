using System;
using System.Linq;

namespace dig_cypher_missing_key
{
    class Program
    {
        public static int FindTheKey(string message, int[] code)
        {
            // calculate missing key
            int[] key = code.Select((c, i) => c - message[i] + 96).ToArray();

            // search for smallest period key
            bool even = true;
            for (int i = key.Distinct().Count(); i < key.Count(); i++)
            {
                even = true;
                for (int j = 0; j < key.Count(); j++)
                {
                    var everyIthItem = key.Where((c, ind) => (ind - j) % i == 0);
                    even = everyIthItem.Aggregate(true, (s, c) => s && c == everyIthItem.First());
                    if (!even) { break; }
                }
                if (even) { return Int32.Parse(string.Concat(key.Take(i))); }
            }
            // if not found they the full key length is the period
            return Int32.Parse(string.Concat(key));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(FindTheKey("np", new int[] { 18, 23 }));
        }
    }
}
