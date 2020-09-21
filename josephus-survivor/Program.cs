using System;

namespace codewars_josephus_survivor
{
    class Program
    {
        public static int JosSurvivor(int n, int k)
        {
            if (n == 1)
            { return 1; }
            return (JosSurvivor(n - 1, k) + k - 1) % n + 1;
        }
        static void Main(string[] args)
        {
            int x = JosSurvivor(14, 2);
            Console.WriteLine("Hello {0}!", x);
        }
    }
}
