using System;
using System.Linq;

namespace codewars_sandbox
{
    class Program
    {
        public static bool validBraces(String braces)
        {
            int bLen = braces.Length;
            string[] pairs = new string[] { "()", "{}", "[]" };
            do
            {
                bLen = braces.Length;
                foreach (var pair in pairs)
                {
                    braces = braces.Replace(pair, "");
                }
            } while (bLen != braces.Length);
            return braces == "";
        }
        static void Main(string[] args)
        {

            System.Console.WriteLine(validBraces("[]()"));
        }
    }
}
