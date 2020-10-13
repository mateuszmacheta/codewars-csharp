using System;
using System.Linq;

namespace codewars_sandbox
{
    class Program
    {
        public static int solve(int a, int b)
        {
            int sum = 0;
            Variations<char> variations= new Variations<char>(inputSet, 2);
            return sum;
        }

        public static bool check(int c)
        {
            string cS = c.ToString();
            return (cS.Count(i => i == '8') >= cS.Count(i => i == '5') && cS.Count(i => i == '5') >= cS.Count(i => i == '3'));
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(solve(1, 100));
        }
    }
}
