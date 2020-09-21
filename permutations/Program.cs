using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace permutations
{
    class Program
    {
        public static List<string> result = new List<string>();
        public static List<string> SinglePermutations(string s)
        {
            System.Console.WriteLine(s);
            permutate(s.Length, ref s);
            return result;
        }

        public static void permutate(int k, ref string s)
        {
            if (k == 1)
            {
                //if (!result.Contains(s))
                //{
                result.Add(s);
                //}
            }
            else
            {
                permutate(k - 1, ref s);
                for (int i = 0; i < k - 1; i++)
                {
                    if (k % 2 == 0)
                    {
                        s = swap(s, i, k - 1);
                    }
                    else
                    {
                        s = swap(s, 0, k - 1);
                    }
                    permutate(k - 1, ref s);
                }
            }
        }

        private static string swap(string s, int a, int b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (i != a && i != b)
                { sb.Append(s[i]); }
                else if (i == b)
                { sb.Append(s[a]); }
                else
                { sb.Append(s[b]); }
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            var test = "nbzf";
            //System.Console.WriteLine(swap(test, 1, 3));
            var output = SinglePermutations(test);
            System.Console.WriteLine(string.Join("\n", output.OrderBy(x => x)));
        }
    }
}
