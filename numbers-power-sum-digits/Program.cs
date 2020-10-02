using System;
using System.Linq;

namespace numbers_power_sum_digits
{
    class Program
    {
        public static string DuplicateEncode(string word)
        {
            word = word.ToLower();
            return string.Join("",word.Select(c => word.Count(x => x == c) == 1 ? '(' : ')'));
        }

        static void Main(string[] args)
        {
            var test = "Success";
            System.Console.WriteLine(DuplicateEncode(test));
        }
    }
}
