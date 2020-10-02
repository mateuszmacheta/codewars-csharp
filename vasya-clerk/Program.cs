using System;
using System.Collections.Generic;

namespace vasya_clerk
{
    class Program
    {
        public static string Tickets(int[] peopleInLine)
        {
            Dictionary<int, int> register = new Dictionary<int, int>
            {
                { 25, 0},
                { 50, 0},
                { 100, 0}
            };

            foreach (var cash in peopleInLine)
            {
                if (cash == 25)
                {
                    register[cash]++;
                    continue;
                }
                if (giveChange(cash - 25, ref register))
                { return "NO"; }
            }
            return "YES";
        }

        private static bool giveChange(int change, ref Dictionary<int, int> register)
        {
            switch (change)
            {
                case 25:
                    if ()
                        break;
                default:
                    throw new NotImplementedException("We only expect 25 and 75 change.");
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
