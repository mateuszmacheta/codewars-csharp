using System;
using System.Collections.Generic;

namespace roman_numerals
{
    public static class RomanConvert
    {
        public static string Solution(int n)
        {
            int remaining = n;
            string result = "";
            Dictionary<int, string> numerals = new Dictionary<int, string>()
        {
           {1000,"M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100,"C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };
            while (remaining > 0)
            {
                foreach (var key in numerals.Keys)
                {
                    System.Console.WriteLine($"key: {key}");
                    if (key <= remaining)
                    {
                        remaining -= key;
                        result += numerals[key];
                        break;
                    }
                }
            };
            return result;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanConvert.Solution(1954));
        }
    }
}
