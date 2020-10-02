using System;
using System.Linq;

namespace coderwars_vovel_count
{
    class Program
    {
        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;
            char[] validLetters = { 'a', 'e', 'i', 'o', 'u' };

            foreach (char letter in str)
            {
                if (validLetters.Count(y => y == letter) > 0)
                { vowelCount++; }
            }
            return vowelCount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("count: {0}", GetVowelCount("Hello World!"));
        }
    }
}
