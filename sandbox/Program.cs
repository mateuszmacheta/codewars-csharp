using System;

namespace codewars_sandbox
{
    class Program
    {
        // public static int[] SortArray(int[] array)
        // {
        //     if (array.Length == 0) { return array; }
        //     var odds = new List<int>();
        //     odds = array.Where(i => i % 2 == 1).OrderBy(i => i).ToList();
        //     int j = 0;
        //     for (int i = 0; i < array.Length; i++)
        //     {
        //         if (array[i] % 2 == 1)
        //         {
        //             array[i] = odds[j++];
        //         }
        //     }
        //     return array;
        // }

        static void Main(string[] args)
        {
            string name = "donald";
            System.Console.WriteLine(char.ToLower(name[0]) == 'r' ? name + " plays banjo" : name + " does not play banjo");
        }
    }
}
