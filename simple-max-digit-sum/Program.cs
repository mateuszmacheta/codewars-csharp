using System.IO;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        public static long countSum(long n)
        {
            return n.ToString().Select(c => (int)c - 48).Sum();
        }
        public static long solve(long n)
        {
            int start = 0;
            Regex rx = new Regex(@"^9+");
            Match match = rx.Match(n.ToString());
            if (match.Success)
            { start = match.Index + match.Length; }
            string s = (n + 1).ToString();
            long candidate = long.Parse((Int32.Parse(s.Substring(start, 1)) - 1).ToString() + new String('9', s.Length - 1));
            return countSum(n) >= countSum(candidate) ? n : candidate;
        }
        static void Main(string[] args)
        {
            // var test = 999999999992;
            // System.Console.WriteLine(solve(test));
            StreamWriter sw = new StreamWriter(@"C:\Users\machetam\Desktop\test.csv");

            for (int i = 1000; i >= 0; i--)
            {
                var maxDig = Enumerable.Range(0, i + 1).Select(c => new { val = c, sum = countSum(c) }).OrderByDescending(c => c.sum).First();
                //System.Console.WriteLine("{0},{1},{2}", i, maxDig.val, maxDig.sum);
                if (i % 10 == 0)
                { System.Console.Write('='); }
                sw.WriteLine("{0},{1},{2}", i, maxDig.val, maxDig.sum);
            }
            sw.Close();
        }
    }

}