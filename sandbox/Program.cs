using System;
using System.Text;

public static class Kata
{
    public static string ExpandedForm(long num)
    {
        int magnitude = (int)Math.Log10(num);
        long chunk;
        int digit;
        StringBuilder sb = new StringBuilder();

        for (int i = magnitude; i > -1; i--)
        {
            digit = (int)(num / (int)Math.Pow(10, i));
            if (digit == 0) { continue; }
            chunk = (long)(digit * Math.Pow(10, i));
            sb.Append(chunk.ToString() + " + ");
            num -= chunk;
        }
        sb.Remove(sb.Length - 3, 3);
        return sb.ToString();
    }
}
class Program
{


    static void Main(string[] args)
    {
        System.Console.WriteLine(Kata.ExpandedForm(70304));
    }
}
