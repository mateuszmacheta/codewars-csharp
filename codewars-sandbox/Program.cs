using System;
using System.Text.RegularExpressions;

namespace codewars_sandbox
{

    class Program
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            string regexString = "([" + String.Join("", commentSymbols) + "].*)$";
            Regex rx = new Regex(regexString, RegexOptions.Multiline);
            string outputS = rx.Replace(text, "");
            regexString = "( +)$";
            rx = new Regex(regexString, RegexOptions.Multiline);
            outputS = rx.Replace(outputS, "");
            return outputS;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
        }
    }
}
