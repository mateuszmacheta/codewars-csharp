using System;
using System.Collections.Generic;
using System.Linq;

namespace burrows_wheeler
{
    class Program
    {
        public static Tuple<string, int> Encode(string s)
        {
            if (s.Length == 0)
            { return new Tuple<string, int>("", 0); }
            var list = new List<string>() { s };
            var ss = s + s;
            for (int i = 1; i < s.Length; i++)
            {
                list.Add(ss.Substring(i, s.Length));
            }
            list.Sort(StringComparer.Ordinal);
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
            return new Tuple<string, int>(string.Join("", list.Select(w => w[s.Length - 1])), list.IndexOf(s));
        }

        public static string Decode(string s, int i)
        {
            if (s.Length == 0)
            { return ""; }
            var list = new List<string>();
            foreach (char c in s)
            {
                list.Add(c.ToString());
            }
            list.Sort(StringComparer.Ordinal);

            for (int x = 1; x < s.Length; x++)
            {
                for (int y = 0; y < s.Length; y++)
                {
                    list[y] = s[y] + list[y];
                }
                list.Sort(StringComparer.Ordinal);
            }
            // foreach (var item in list)
            // {
            //     System.Console.WriteLine(item);
            // }
            return list[i];
        }
        static void Main(string[] args)
        {
            //var test = "Humble Bundle";
            var test2 = "e emnllbduuHB";
            Console.WriteLine(Decode(test2, 2));
            //Console.WriteLine(Encode(test));
        }
    }
}
