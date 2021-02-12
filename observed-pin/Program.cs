using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Kata
{
    private static List<string> getAllPermuations(List<string> input)
    {
        var output = new List<string>();
        StringBuilder sb = new StringBuilder();
        int[] register = new int[input.Count];
        int permutationCount = input.Aggregate(1, (x, y) => x * y.Length);
        int carry;
        int limit;
        for (int i = 0; i < permutationCount; i++) // make all required permutations
        {
            carry = 1;
            for (int j = 0; j < input.Count; j++) // iterate through all lists
            {
                sb.Append(input[j][register[j]]);
                limit = input[j].Length;
                register[j] += carry;
                if (register[j] >= limit)
                {
                    carry = 1;
                    register[j] = 0;
                }
                else
                {
                    carry = 0;
                }
            }
            System.Console.WriteLine(sb.ToString());
            output.Add(sb.ToString());
            sb.Clear();
        }

        return output;
    }

    public static List<string> GetPINs(string observed)
    {
        var allDigits = new Dictionary<char, string>(){
            {'0', "08"},
            {'1', "124"},
            {'2',"1235"},
            {'3',"236"},
            {'4',"1457"},
            {'5',"24568"},
            {'6',"3569"},
            {'7',"478"},
            {'8',"05789"},
            {'9',"689"}
        };
        List<string> input = new List<string>();
        foreach (var c in observed)
        {
            input.Add(allDigits[c]);
        }
        return getAllPermuations(input);
    }
}
class Program
{

    static void Main(string[] args)
    {
        var output = Kata.GetPINs("11");
        Console.WriteLine("Hello World!");
    }
}
