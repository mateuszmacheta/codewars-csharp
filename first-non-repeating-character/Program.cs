using System;
using System.Linq;

public class Kata
{
    public static string FirstNonRepeatingLetter(string s)
    {
        string sLower = s.ToLower();
        var nonRepeating = sLower.GroupBy(c => c).Where(g => g.Count() == 1);
        if (nonRepeating.Count() == 0)
            return "";
        return s[sLower.IndexOf(nonRepeating.First().Key)].ToString();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Kata.FirstNonRepeatingLetter("Hello World!"));
    }
}