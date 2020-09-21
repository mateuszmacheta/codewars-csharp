using System;
using System.Linq;

namespace jewel_thief
{
    class Program
    {
        public static int Crack(Safe safe)
        {
            string[] combination = new string[3] { "L00", "L00", "L00" };
            int responeLen = 0;
            int i = 0;
            while (true)
            {
                foreach (var number in Enumerable.Range(0, 200))
                {
                    combination[i] = getSpin(number);
                    string combinationS = String.Join("-", combination);
                    System.Console.WriteLine(combinationS);
                    int len;
                    if ((len = safe.Unlock(combinationS).Length) > responeLen)
                    {
                        Console.WriteLine(safe.Unlock(combinationS));
                        i += (len - responeLen) / 5;
                        responeLen = len;
                        if (responeLen == 17)
                        { return safe.Open(); }
                        goto mainLoop;
                    }
                }
            mainLoop:
                if (i > 2) { break; }
            }
            return -1;
        }

        private static string getSpin(int number)
        {
            string spin;

            if (number > 99)
            {
                spin = "R";
            }
            else
            {
                spin = "L";
            }
            spin += $"{(number % 100):D2}";
            return spin;
        }

        static void Main(string[] args)
        {
            var test = new Safe();
            Console.WriteLine(Crack(test));
        }
    }

    public class Safe
    {
        public string Unlock(string combination)
        {
            string secret = "R00-R00-R00";
            if (secret == combination)
                return "click-click-click";
            if (secret.Substring(0, 7) == combination.Substring(0, 7))
                return "click-click";
            if (secret.Substring(0, 3) == combination.Substring(0, 3))
                return "click";
            return "";
        }
        public int Open()
        {
            return -1;
        }
    }
}
