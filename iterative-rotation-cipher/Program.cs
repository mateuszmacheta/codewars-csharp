using System;
using System.Collections.Generic;

namespace iterative_rotation_cipher
{
    class Program
    {

        public static string Encode(int n, string s, int max)
        {
            List<int> spaces = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                { spaces.Add(i); }
            }

            for (int i = 0; i < max; i++)
            {
                s = encodeIter(n, s, spaces);
            }
            return n.ToString() + ' ' + s;
        }

        public static string encodeIter(int n, string s, List<int> spaces)
        {
            // remove spaces
            s = s.Replace(" ", "");

            s = rotateR(n, s);

            // reinsert spaces
            foreach (var num in spaces)
            {
                s = s.Insert(num, " ");
            }

            List<string> reconstruct = new List<string>();

            foreach (var word in s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                reconstruct.Add(rotateR(n % word.Length, word));
            }

            return string.Join(" ", reconstruct);
        }

        public static string Decode(string s)
        {
            int n = int.Parse(s.Split(' ')[0]);

            s = s.Substring(s.IndexOf(' ') + 1);

            System.Console.WriteLine("Decode:\nn: {0}\ns: {1}", n, s);

            List<int> spaces = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                { spaces.Add(i); }
            }

            for (int i = 0; i < 10; i++)
            {
                s = decodeIter(n, s, spaces);
            }

            return s;
        }

        public static string decodeIter(int n, string s, List<int> spaces)
        {
            List<string> reconstruct = new List<string>();

            foreach (var word in s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                reconstruct.Add(rotateL(n % word.Length, word));
            }

            s = string.Join(" ", reconstruct);

            // remove spaces
            s = s.Replace(" ", "");

            s = rotateL(n, s);

            // reinsert spaces
            foreach (var num in spaces)
            {
                s = s.Insert(num, " ");
            }

            return s;
        }

        public static string rotateL(int n, string s)
        {
            return s.Substring(n) + s.Substring(0, n);
        }

        public static string rotateR(int n, string s)
        {
            return rotateL(s.Length - n, s);
        }
        static void Main(string[] args)
        {
            string encoded = "";
            for (int i = 1; i < 15; i++)
            {
                System.Console.WriteLine(i + " " + Encode(14, "True evil is a mundane bureaucracy.", i);
            }
            Console.WriteLine(encoded);
            //System.Console.WriteLine(Decode(encoded));

        }
    }
}
