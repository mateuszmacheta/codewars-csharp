using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace interlaced_spiral_cipher
{
    class Program
    {
        public static string Encode(string s)
        {
            StringBuilder sb = new StringBuilder();
            int[,] cipherKey = getCipherKey(s);
            foreach (var i in cipherKey)
            {
                if (i >= 0)
                { sb.Append(s[i]); }
                else
                { sb.Append(' '); }
            }
            return sb.ToString();
        }
        public static string Decode(string s)
        {
            int[,] cipherKey = getCipherKey(s);
            List<Tuple<int, char>> result = new List<Tuple<int, char>>();

            int count = 0;
            foreach (var i in cipherKey)
            {
                if (i >= 0)
                { result.Add(new Tuple<int, char>(i, s[count])); }
                count++;
            }
            string endS = string.Concat(result.OrderBy(e => e.Item1).Select(e => e.Item2).ToList());
            return endS.TrimEnd(' ');
        }

        public static int[,] getCipherKey(string s)
        {
            int side = (int)Math.Ceiling(Math.Sqrt(s.Length));

            if (side == 0)
            { return new int[0, 0] { }; }
            if (side == 1)
            { return new int[1, 1] { { 0 } }; }

            int[,] cipherKey = new int[side, side];

            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    cipherKey[i, j] = -1;
                }
            }

            int depth = 0;
            int c = 0, x = 0, y = 0;

            List<Tuple<int, int>> moves = new List<Tuple<int, int>>{
                new Tuple<int, int>(0,1),
                new Tuple<int, int>(1,0),
                new Tuple<int, int>(0,-1),
                new Tuple<int, int>(-1,0),
            };

            // mighty algorithm to create interlaced spiral square cipher key

            while (cipherKey[depth, depth] == -1)
            {
                for (int step = 0; step < side - 1 - depth * 2; step++)
                {
                    foreach (var ind in Enumerable.Range(0, 4))
                    {
                        //System.Console.WriteLine($"y: {y + depth + step * moves[ind].Item1} x: {x + depth + step * moves[ind].Item2}");
                        if (c >= s.Length) { goto escape; }
                        cipherKey[y + depth + step * moves[ind].Item1, x + depth + step * moves[ind].Item2] = c++;
                        y += (side - 1 - depth * 2) * moves[ind].Item1;
                        x += (side - 1 - depth * 2) * moves[ind].Item2;
                    }
                }
                depth++;
            }

            // special case, because I didn't know how to fix above algorithm in case of side 9 square
            if (Math.Sqrt(side) % 2 == 1 && c < s.Length)
            { cipherKey[(side - 1) / 2, (side - 1) / 2] = c; }

        escape:


            print2d(cipherKey);
            return cipherKey;
        }

        public static void print2d(int[,] arr)
        {
            int side = arr.GetUpperBound(0) + 1;
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    System.Console.Write(arr[i, j] + "\t");
                }
                System.Console.WriteLine();
            }
        }

        public static void print1d(int[,] arr)
        {
            int side = arr.GetUpperBound(0) + 1;
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    System.Console.Write(arr[i, j] + "\t");
                }
            }
            System.Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(Encode("Sic transit gloria mundi"));
            Console.WriteLine(Decode("I cehsts  dtdt ioselerfa  lesI'amder dhngy aatsosi taovno w wni 'g nrun mImmt eoa"));
        }
    }
}
