using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codewars_sandbox
{
    class Program
    {
        public static string CustomChristmasTree(string chars, int n)
        {
            Console.WriteLine($"c: {chars} n: {n}");
            StringBuilder sb = new StringBuilder(chars);
            int period = chars.Length;

            List<string> tree = new List<string>();

            // enlarge original string if needed for Take method
            for (int i = 1; i < Math.Ceiling((double)2 * n / period); i++)
            { sb.Append(chars); }

            chars = sb.ToString();

            // tree
            int taken = 0;
            for (int i = 1; i <= n; i++)
            {
                tree.Add(new string(' ', n - i) + string.Join(" ", chars.Skip(taken % period).Take(i)));
                taken += i;
            }

            // trunk
            for (int i = 0; i < n / 3; i++)
            { tree.Add(new string(' ', n - 1) + '|'); }
            return string.Join("\n", tree);
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(CustomChristmasTree("78", 43));
        }
    }
}
