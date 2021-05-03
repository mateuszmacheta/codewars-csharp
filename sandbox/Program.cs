
public class Kata
{
    public static bool ValidateWord(string[] dictionary, string word)
    {
        var result = word;
        foreach (var dictionaryEntry in dictionary)
        {
            result = result.Replace(dictionaryEntry, "");
        }
        return result == "";
    }
}

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine(Kata.ValidateWord(new string[] { "code", "wars" }, "codewars"));
    }
}
