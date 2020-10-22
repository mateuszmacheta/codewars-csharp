using System;

namespace double_cola
{
    class Program
    {
        public static string WhoIsNext(string[] names, long n)
        {
            Console.Write($"n: {n} ");
            Console.WriteLine(string.Join(',', names).TrimEnd(','));
            int k = 0;
            if (n >= names.Length)
            { k = (int)Math.Log2(n / names.Length + 1); }
            long remaining = n;
            if (k > 0)
            { remaining -= names.Length * (long)Math.Pow(2, k) - names.Length; }
            int c = (int)Math.Ceiling(remaining / Math.Pow(2, k));
            return names[c - 1];
        }

        static void Main(string[] args)
        {
            Console.WriteLine(WhoIsNext(new string[] { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" }, 8));
        }
    }
}
