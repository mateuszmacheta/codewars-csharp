using System;
using System.Linq;
using System.Collections.Generic;

public class PickPeaks
{
    public static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        Console.WriteLine("arr: " + string.Join(",", arr));
        var result = new Dictionary<string, List<int>>()
        {
            ["pos"] = new List<int>(),
            ["peaks"] = new List<int>()
        };
        if (arr.Length == 0 || arr.Length == 1 || arr.Length == 2)
            return result;

        var delta = new List<int>();

        for (int i = 1; i < arr.Length; i++)
        {
            delta.Add(arr[i] - arr[i - 1]);
        }

        int peakStart = -1;

        for (int i = 0; i < delta.Count - 1; i++)
        {
            if (peakStart >= 0)
            {
                if (delta[i] != 0)
                    peakStart = -1;
                if (delta[i + 1] < 0)
                {
                    result["pos"].Add(peakStart);
                    result["peaks"].Add(arr[peakStart]);
                    peakStart = -1;
                }
                else
                    continue;

            }
            else if (delta[i] > 0 && delta[i + 1] < 0)
            {
                result["pos"].Add(i + 1);
                result["peaks"].Add(arr[i + 1]);
            }
            else if (delta[i] > 0 && delta[i + 1] == 0)
                peakStart = i;

        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //var test = new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3 };
        var test = new int[] { 1, 2, 5, 4, 3, 2, 3, 6, 4, 1, 2, 3, 3, 4, 5, 3, 2, 1, 2, 3, 5, 5, 4, 3 };
        var result = PickPeaks.GetPeaks(test);
        Console.WriteLine("pos: " + string.Join(",", result["pos"]));
        Console.WriteLine("peaks: " + string.Join(",", result["peaks"]));
    }
}
