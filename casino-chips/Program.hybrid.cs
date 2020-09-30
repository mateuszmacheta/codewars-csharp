using System;
using System.Linq;

namespace casino_chips2
{
    class Program2
    {
        public static int solve(int[] arr)
        {
            Console.WriteLine("{0} {1} {2}", arr[0], arr[1], arr[2]);
            int days = 0;
            int[] reduceI = new int[2];
            while (arr.Count(x => x <= 0) < 2)
            {
                if (arr[0] == arr[1] && arr[1] == arr[2])
                {
                    return days + 3 * arr[0] / 2;
                }
                else
                {
                    int xMax = arr.Max();
                    int xMin = arr.Min();
                    // two maximum values
                    if (arr.Count(x => x == xMax) == 2)
                    {
                        return days + xMax - xMin + 3 * xMin / 2;
                    }

                    // two minimum values
                    else if (arr.Count(x => x == xMin) == 2)
                    {
                        return days + 3 * xMin / 2 + 1;
                    }
                }
                reduceI = arr.Select((x, i) => new { val = x, ind = i }).OrderByDescending(x => x.val).Select(x => x.ind).Take(2).ToArray();
                arr[reduceI[0]]--;
                arr[reduceI[1]]--;
                days++;
            }
            return days;
        }
        static void Main2(string[] args)
        {
            //var test = new int[] { 1, 1, 1 };
            var test = new int[] { 9, 8, 6 };
            Console.WriteLine(solve(test));
        }
    }
}
