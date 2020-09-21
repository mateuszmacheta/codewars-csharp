using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace binomial_expansion
{
    class Program
    {
        static long factorial(int num)
        {
            if (num == 0 || num == 1)
            { return 1; }
            long fac = 1;
            foreach (int number in Enumerable.Range(2, num - 1))
            {
                fac *= number;
                //Console.WriteLine(number);
            }
            return fac;
        }

        static long binCoeff(int n, int k)
        {
            return factorial(n) / (factorial(k) * factorial(n - k));
        }

        public static string Expand(string expr)
        {
            Console.WriteLine(expr);
            string output = "";
            string pattern = @"^\((\-?\d*)([a-z])([\-\+]\d+)\)\^(\d+)$";
            Regex rx = new Regex(pattern);
            Match match = rx.Match(expr);
            string a = match.Groups[1].Captures[0].Value;
            string var = match.Groups[2].Captures[0].Value;
            string b = match.Groups[3].Captures[0].Value;
            string n = match.Groups[4].Captures[0].Value;
            int aI = 1;
            if (a.Length != 0)
            { aI = Int32.Parse((a == "-") ? "-1" : a); }
            int bI = Int32.Parse(b);
            int nI = Int32.Parse(n);
            for (int k = 0; k <= nI; k++)
            {
                //System.Console.WriteLine("n over k {0} n {1} k {2}", binCoeff(nI, k), nI, k);
                string add = "";
                long multi = binCoeff(nI, k) * Convert.ToInt64(Math.Pow(bI, k)) * Convert.ToInt64(Math.Pow(aI, nI - k));
                int power = nI - k;
                if (multi == 0) { continue; }
                if (multi == -1)
                {
                    if (power == 0)
                    { add += "-1"; }
                    else if (power == 1)
                    { add += $"-{var}"; }
                    else
                    { add += $"-{var}^{power}"; }
                }
                else if (multi == 1)
                {
                    if (power == 0)
                    { add += "+1"; }
                    else if (power == 1)
                    { add += $"+{var}"; }
                    else
                    { add += $"+{var}^{power}"; }
                }
                else
                {
                    string multiS = (multi > 0 ? "+" : "") + multi.ToString();
                    if (power == 0)
                    { add += multiS; }
                    else if (power == 1)
                    { add += $"{multiS}{var}"; }
                    else
                    { add += $"{multiS}{var}^{power}"; }
                }
                output += add;
            }
            return output.TrimStart('+').TrimEnd('-');
        }

        static void Main(string[] args)
        {
            Console.WriteLine("{0}", Expand("(y-5)^15"));
            //System.Console.WriteLine(binCoeff(15, 1));
        }
    }
}
