using System;
class Program
{
    public static bool SleepIn(bool weekday, bool vacation)
    {
        return !weekday || vacation;
    }
    static void Main(string[] args)
    {
        System.Console.WriteLine(Program.SleepIn(false, false));
        System.Console.WriteLine(Program.SleepIn(true, false));
        System.Console.WriteLine(Program.SleepIn(false, true));
    }
}
