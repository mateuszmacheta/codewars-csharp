using System;
using System.Linq;

public class Solution_old
{

    public static int solve(int[] arr)
    {
        Console.WriteLine("{0} {1} {2}", arr[0], arr[1], arr[2]);
        // all equal
        if (arr[0] == arr[1] && arr[1] == arr[2])
        {
            return 3 * arr[0] / 2;
        }

        int xMax = arr.Max();
        int xMin = arr.Min();


        // two maximum values
        if (arr.Count(x => x == xMax) == 2)
        {
            return xMax - xMin + 3 * xMin / 2;
        }

        // two minimum values
        if (arr.Count(x => x == xMin) == 2)
        {
            return 3 * xMin / 2 + 1;
        }

        // all different
        // triangle criteria - no idea why it works here
        if (arr[0] + arr[2] > arr[1] && arr[1] + arr[2] > arr[0] && arr[0] + arr[1] > arr[2])
        { return xMax; }
        // after 
        int xMid = arr.Where(x => x != xMax && x != xMin).First();
        return xMid + xMin;
    }
}