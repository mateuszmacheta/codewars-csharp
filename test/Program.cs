using System;
using System.Linq;

namespace test
{
    class Program
    {
        public string ReverseLetter(string str)
        {
              return string.Join("",str.Select(c => Char.IsLetter(c)).Reverse());
        }

        static void Main(string[] args)
        {
            //var test = new List<int> { 15, 11, 10, 7, 8 };
            System.Console.WriteLine(MatrixAddition(new int[][] {new int[] {1, 2},
                                                                                       new int[] {1, 2}},
                                                                                       new int[][] {new int[] {2, 3},
                                                                                                    new int[] {2, 3}}));
        }

    }

}
