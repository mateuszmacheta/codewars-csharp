using System;
using System.Collections.Generic;
using System.Linq;

namespace alphametics_solver
{

    public class Cryptarithm
    {
        public static List<string> Binary { get; set; }
        public Cryptarithm()
        {
            for (int i = 0; i < Math.Pow(2, 10); i++)
            {
                Binary.Add(Convert.ToString(i, 2));
            }
        }
        public static string Alphametics(string s)
        {
            char[] chars = s.Where(c => Char.IsLetter(c)).Distinct().ToArray();
            return "";
        }
        public static List<int> allDigitCombinations(int k)
        {
            return new List<int> { };
        }
    }
    class Program
    {

        public static string Alphametics(string s)
        {
            string tmpS;
            int left, right;

            // remove spaces
            s = s.Replace(" ", "");

            // count how many operands we have
            int operandCount = s.Count(c => c == '+' || c == '=');

            // get only unique characters
            char[] chars = s.Where(c => Char.IsLetter(c)).Distinct().ToArray();

            // get all possible digit combinations for this many characters
            List<List<char>> allComb = allDigitCombinations(chars.Count());

            // for each combination check if this gives us valid equation
            foreach (var combination in allComb)
            {
                System.Console.WriteLine(string.Concat(combination));
                tmpS = s;
                for (int i = 0; i < chars.Count(); i++)
                {
                    tmpS = tmpS.Replace(chars[i], combination[i]);
                }
                left = tmpS.Split(new char[] { '+', '=' }).Take(operandCount).Select(w => Convert.ToInt32(w)).Sum();
                right = Convert.ToInt32(tmpS.Substring(tmpS.LastIndexOf('=') + 1));
                if (left == right)
                { return tmpS; }
            }
            return "LUL";
        }
        // public static List<List<char>> allDigitCombinations(int k)
        // {
        //     List<List<char>> Binary = new List<List<char>>();
        //     string binString = "";

        //     for (int i = 0; i < Math.Pow(2, 10); i++)
        //     {
        //         binString = Convert.ToString(i, 2).PadLeft(10, '0');
        //         if (binString.Count(c => c == '1') == k)
        //         { Binary.Add(binString.Select((c, index) => new { dig = c, ind = index }).Where(e => e.dig == '1').Select(e => (char)(e.ind + '0')).ToList()); }
        //     }
        //     return Binary;
        // }

        public static List<List<char>> allDigitCombinations(int k)
        {
            List<List<char>> Binary = new List<List<char>>();

        }
        static void Main(string[] args)
        {
            Console.WriteLine(Alphametics("SEND + MORE = MONEY"));
        }
    }
}
