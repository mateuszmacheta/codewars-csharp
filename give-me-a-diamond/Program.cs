using System;
using System.Text;

public class Diamond
{
    public static string print(int n)
    {
        if (n % 2 == 0 || n < 0)
            return null;
        short step = 1;
        int spaces = n / 2;
        char diamondChar = '*';
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i > -1;)
        {
           sb.Append(new String(' ', spaces));
            sb.AppendLine(new String(diamondChar, 2 * i + 1));
            if (i == n / 2)
                step = -1;
            spaces -= step;
            i += step;
        }
        return sb.ToString().Substring(0, sb.Length - 1);
    }

}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Diamond.print(5));
    }
}
