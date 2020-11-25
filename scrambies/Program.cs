using System;

public class Scramblies
{

    public static bool Scramble(string str1, string str2)
    {
        var mainList = str1.ToList();
        var subList = str2.ToList();
        bool isRemoved;

        foreach (var item in subList)
        {
            isRemoved = mainList.Remove(item);
            if (!isRemoved)
                return false;
        }

        return true;
    }

}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Scramblies.Scramble("katas", "steak"));
    }
}

