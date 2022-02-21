
public class Kata
{
    public static int IntDiff(int[] arr, int n)
    {
        System.Console.WriteLine($"n: {n}");
        System.Console.WriteLine($"array: {string.Join(",", arr)}");
        if (n < 0)
            return 0;
        int result = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (System.Math.Abs(arr[i] - arr[j]) == n)
                    result++;
            }
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var test = new int[] { 4, 8, 12, 12, 3, 6, 2 };
        System.Console.WriteLine(Kata.IntDiff(test, 6));
    }
}
