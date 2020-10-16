using System;
using System.Linq;
using System.Text;

namespace simple_number_divisibility
{
    class Program
    {
        public static int solve(long n)
        {
            System.Console.WriteLine($"n: {n}");
            if ((double)n / 25 % 1 == 0)
            { return 0; }

            string nS = n.ToString();

            if (nS.Length == 1) { return -1; }
            if (nS.Length == 2)
            {
                return (double)Int32.Parse(string.Concat(nS[1], nS[0])) / 25 % 1 == 0 ? 1 : -1;
            }

            int minMoves = int.MaxValue;

            int zeroCount = nS.Count(d => d == '0');
            int twoCount = nS.Count(d => d == '2');
            int fiveCount = nS.Count(d => d == '5');
            int sevenCount = nS.Count(d => d == '7');

            if (zeroCount >= 2)
            { findMinMoves("00", nS, ref minMoves); }

            if (twoCount >= 1 && fiveCount >= 1)
            { findMinMoves("25", nS, ref minMoves); }

            if (fiveCount >= 1 && zeroCount >= 1)
            { findMinMoves("50", nS, ref minMoves); }

            if (sevenCount >= 1 && fiveCount >= 1)
            { findMinMoves("75", nS, ref minMoves); }

            return minMoves == int.MaxValue ? -1 : minMoves;
        }

        private static void findMinMoves(string s, string original, ref int minMoves)
        {
            bool firstInPlace;
            bool secondInPlace;
            StringBuilder sb = new StringBuilder(original);
            int moves = 0; int i;

            char first = s[0]; char second = s[1];
            secondInPlace = original[original.Length - 1] == second;

            if (!secondInPlace)
            {
                i = original.LastIndexOf(second);
                // move to the right until at place
                while (i < original.Length - 1)
                {
                    sb = moveRight(sb, i++);
                    moves++;
                    System.Console.WriteLine(sb);
                }
            }

            firstInPlace = sb[original.Length - 2] == first;
            if (!firstInPlace)
            {
                if (first == '0')
                { i = sb.ToString().Substring(0, sb.ToString().LastIndexOf('0')).LastIndexOf('0'); }
                else
                { i = sb.ToString().LastIndexOf(first); }
                // move to the right until at place
                while (i < original.Length - 2)
                {
                    sb = moveRight(sb, i++);
                    moves++;
                    System.Console.WriteLine(sb);
                }
            }

            if (!sb.ToString().StartsWith('0'))
            { minMoves = Math.Min(minMoves, moves); }
        }
        private static StringBuilder moveRight(StringBuilder sb, int i)
        {
            char rm = sb[i];
            sb.Remove(i, 1).Insert(i + 1, rm);
            return sb;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(solve(50011111112));
        }
    }
}
