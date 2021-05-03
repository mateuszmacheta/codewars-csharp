using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

public class Kata
{
    public static List<(string, string, string)> ShoppingCalculation(List<string> input)
    {
        var balance = new Dictionary<string, int>();
        var purchases = new List<(string, string, int)>();
        var prices = new Dictionary<string, int>();
        var result = new List<(string, string, string)>();

        foreach (var item in input)
        {
            var entry = item.TrimEnd('.');
            if (entry.Contains(" has "))
            {
                string person = entry.Substring(0, entry.IndexOf(" "));
                int cash = Int32.Parse(entry.Substring(entry.IndexOf("$") + 1));
                balance.Add(person.ToLower(), cash);
            }
            else if (entry.Contains(" buys "))
            {
                string person = entry.Substring(0, entry.IndexOf(" "));
                int amount = Int32.Parse(entry.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                string product = entry.Substring(entry.LastIndexOf(" ") + 1).TrimEnd('s');
                purchases.Add((person.ToLower(), product.ToLower(), amount));
            }
            else if (entry.Contains(" is "))
            {
                string product = entry.Substring(0, entry.IndexOf(" "));
                int price = Int32.Parse(entry.Substring(entry.IndexOf('$') + 1));
                prices.Add(product.ToLower(), price);
            }
        }

        // count remaining money
        foreach (var purchase in purchases)
        {
            string person = purchase.Item1;
            string product = purchase.Item2;
            int quantity = purchase.Item3;

            balance[person] -= quantity * prices[product];
        }

        foreach (var entry in balance)
        {
            string person = entry.Key;

            string productsText = string.Join(", ", purchases
                .Where(i => i.Item1 == person)
                .Select(e => e.Item3 + " " + e.Item2 + (e.Item3 > 1 ? "s" : "")));


            result.Add((
                CultureInfo.InvariantCulture.TextInfo.ToTitleCase(person),
                '$' + balance[person].ToString(),
                productsText
                ));
        }

        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        //Arrange 
        var input = new List<string>() {
            "Apple is $5.",
            "Banana is $7.",
            "Orange is $2.",
            "Alice has $26.",
            "John has $41.",
            "Alice buys 2 apples.",
            "John buys 1 banana.",
            "Alice buys 5 oranges."
            };
        Console.WriteLine(Kata.ShoppingCalculation(input));
    }
}
