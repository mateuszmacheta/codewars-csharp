using System;
using System.Linq;

namespace sandbox
{

    public class Kata
    {
        public static object FirstNonConsecutive(int[] arr)
        {
            if (arr == null || arr.Length == 1)
                return null;
            var delta = arr.Zip(arr.Skip(1), (f, s) => s - f);
            int i = 1;
            using (var sequenceEnum = delta.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    if (sequenceEnum.Current != 1)
                        return arr[i];
                    i++;
                }
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new int[] { 1, 2, 3, 4, 6, 7, 8 };
            Console.WriteLine(Kata.FirstNonConsecutive(test));
        }
    }
}
