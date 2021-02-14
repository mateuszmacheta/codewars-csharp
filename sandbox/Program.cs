using System;
using System.Text;

public class Kata
{
  public static string ToWeirdCase(string s)
  {
    int i = 0;
    StringBuilder result = new StringBuilder();
    foreach (char c in s)
    {
        if (c != ' ')
        {
            result.Append((i++ % 2 == 0) ? char.ToUpper(c) : char.ToLower(c));
        }
        else
        {
            result.Append(' ');
            i = 0;
        }
    }
    return result.ToString();
  }
}

class Program
{


    static void Main(string[] args)
    {
        Kata.ToWeirdCase("This is a test");
    }
}
