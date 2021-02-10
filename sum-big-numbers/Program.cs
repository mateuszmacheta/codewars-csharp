using System;
using System.Numerics;


public class Kata
{
    public static string Add(string a, string b)
    {
        BigInteger x = 0;
        BigInteger y = 0;
        x = BigInteger.Parse(a);
        y = BigInteger.Parse(b);

        return Convert.ToString(x + y).TrimStart('0');
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}
