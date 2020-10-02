using System;

namespace codewars_get_middle_character
{
    class Program
    {
        public static string GetMiddle(string s)
        {
            if (s.Length == 0)
            { return null; }
            if (s.Length % 2 == 1)
            {
                return s[s.Length / 2].ToString();
            }
            return s[s.Length / 2 - 1].ToString() + s[s.Length / 2].ToString();

        }
        static void Main(string[] args)
        {
            Console.WriteLine("{0}", GetMiddle("boat"));
        }
    }
}
