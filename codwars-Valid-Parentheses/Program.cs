using System;
using System.Linq;

namespace codwars_Valid_Parentheses
{
    class Program
    {
        public static bool ValidParentheses(string input)
        {
            Console.WriteLine(input);
            if (input == null)
            { return false; };
            char open = '(', closed = ')';
            if (input[0] == closed) { return false; };
            if (input[-1] == open) { return false; };
            int openFreq = input.Count(f => (f == open));
            int closedFreq = input.Count(f => (f == closed));
            return (openFreq == closedFreq);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ValidParentheses("()"));
        }
    }
}
