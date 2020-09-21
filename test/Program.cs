using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        public static string sayMeOperations(string stringNumbers)
        {
            var array = stringNumbers.Split(" ").Select(int.Parse).ToArray();
            int a = array[0];
            int b = array[1];
            var dict = new Dictionary<int, string> {
              {a+b, "addition"},
              {a-b, "substraction"},
              {a*b, "multiplicaiton"},
              {a/b, "division"}
            };
            return string.Join(", ", array.Skip(2).Select(i => dict[i]));
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(sayMeOperations("1 2 3 5 8"));
        }

    }
}