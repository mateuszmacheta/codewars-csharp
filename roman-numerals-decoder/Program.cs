using System;
using System.Collections.Generic;

namespace roman_numerals_decoder
{

    public class RomanDecode
    {
        public static int Solution(string roman)
        {
            var numerals = new Dictionary<string, int>()
            {
                {"M",1000},
                {"CM", 900},
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1}
            };

            int result = 0;
            while (roman.Length > 0)
            {
                foreach (var item in numerals)
                {
                    if (roman.StartsWith(item.Key))
                    {
                        result += numerals[item.Key];
                        roman = roman.Substring(item.Key.Length);
                    }
                }
            }

            return result;
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine(RomanDecode.Solution("XXI"));
        }
    }
}
