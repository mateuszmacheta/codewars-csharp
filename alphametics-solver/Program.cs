using System;
using System.Linq;

namespace alphametics_solver
{
    class Program
    {

        public static string Alphametics(string s)
        {
            char[] chars = s.Where(c => Char.IsLetter(c)).Distinct().ToArray();
            return "";
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Alphametics("SEND + MORE = MONEY"));
        }
    }
}
