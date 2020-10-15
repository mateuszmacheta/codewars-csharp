using System;
using System.Linq;

namespace dig_cypher_missing_key
{
    class Program
    {
        public static int FindTheKey(string message, int[] code)
        {
            int[] original = message.Select(c => c - 96).ToArray();
            int[] key = code.Select((e, i) => e - original[i]).ToArray();
            for (int i = key.Distinct().Count(); i < key.Count(); i++)
            {

            }
            return key.Count();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(FindTheKey("scout", new int[] { 20, 12, 18, 30, 21 }));
        }
    }
}
