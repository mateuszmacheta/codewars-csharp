using System;

namespace double_cola
{
    class Program
    {
        public static string WhoIsNext(string[] names, long n)
        {
            int doubles = (int)Math.Log2(n / names.Length);
            long remaining = n - (long)Math.Pow(2, doubles) * names.Length;
            int c = 0;
            for (int i = 1; i < remaining; i++)
            {
                c += i % Math.Pow(2, doubles) == 0 ? 1 : 0;
                System.Console.WriteLine(c);
            }
            return names[c];
        }
        static void Main(string[] args)
        {
            Console.WriteLine(WhoIsNext(new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" }, 6));
        }
    }
}
