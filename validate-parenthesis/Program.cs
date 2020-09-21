using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace codewars_validate_parenthesis
{
    class Program
    {

        public static bool ValidParentheses(string input)
        {
            Console.WriteLine(input);
            char open = '(', closed = ')';
            int openFreq = input.Count(f => (f == open));
            int closedFreq = input.Count(f => (f == closed));
            if (openFreq == closedFreq)
            {
                input = Regex.Replace(input, "[^()]+", "");
                string newInput = "";
                while (true)
                {
                    newInput = input.Replace("()", "");
                    if (newInput.Length == 0)
                    { return true; }
                    else if (newInput.Length == input.Length)
                    { return false; }
                    input = newInput;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
