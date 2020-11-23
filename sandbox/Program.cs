using System;
using System.Linq;

class Program
{


    static void Main(string[] args)
    {
        var arr = new int[] {1,2,3,4};
        System.Console.WriteLine((arr.Append(5)).ToArray().Average());
    }
}
