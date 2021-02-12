using System;
using System.Collections.Generic;
using System.Text;

public class Kata
{
    private static List<string> getAllPermuations(List<List<char>> input)
    {
        var output = new List<string>();
        StringBuilder sb = new StringBuilder();
        int[] register = new int[input.Count];
        int counter = 0;
        int carry = 0;
        int limit;
        while (true)
        {
            for (int i = 0; i < input.Count; i++) // iterate through all lists
            {
                limit = input[i].Count;
                if (i == 0) { counter++; }
                sb.Append()


            }
            output.Add(sb.ToString());
            sb.Clear();
        }
    }

    public static List<string> GetPINs(string observed)
    {
        var allDigits = new Dictionary<char, List<char>>(){
            {'0',new List<char>(){'0','8'}},
            {'1', new List<char>(){'1','2','4'}},
            {'2',new List<char>(){'1','2','3','5'}},
            {'3',new List<char>(){'2','3','6'}},
            {'4',new List<char>(){'1','4','5','7'}},
            {'5',new List<char>(){'2','4','5','6','8'}},
            {'6',new List<char>(){'3','5','6','9'}},
            {'7',new List<char>(){'4','7','8'}},
            {'8',new List<char>(){'5','7','8','9','0'}},
            {'9',new List<char>(){'6','8','9'}}
        };
        List<List<char>> input = new List<List<char>>();
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
        var output = Kata.GetPINs("8");
        Console.WriteLine("Hello World!");
    }
}
