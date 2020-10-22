using System;
using System.Linq;

namespace cut_the_ropes
{
    class Program
    {
        public static int[] CutTheRopes(int[] a)
        {
            var result = a.Distinct()
                .Select(e => new { len = e, count = a.Count(f => f == e) })
                .OrderBy(e => e.len);
            int count = a.Length;
            return result.Select(e => count -= e.count).SkipLast(1).Prepend(a.Length).ToArray();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CutTheRopes(new int[] { 3, 3, 2, 9, 7 }));
        }
    }
}
