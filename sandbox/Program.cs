using System;
using System.Linq;

namespace codewars_sandbox
{
    class Program
    {
        public static bool XO(string input)
        {
            input = input.ToLower();
            if (!input.Contains('o') && !input.Contains('x'))
            { return true; }
            return input.ToCharArray().Count(x => x == 'o') == input.ToCharArray().Count(x => x == 'x');
        }
        static void Main(string[] args)
        {
            var test = "ooxXm";
            System.Console.WriteLine(XO(test));
        }
    }
}
