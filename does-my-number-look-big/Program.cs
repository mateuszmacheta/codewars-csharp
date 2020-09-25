using System;

namespace does_my_number_look_big
{
    class Program
    {
        public static bool Narcissistic(int value)
        {
            if (value == 0)
            { return true; }
            int numDigits = (int)Math.Log10(value) + 1;
            int sum = 0;
            foreach (var dig in value.ToString())
            {
                sum += (int)Math.Pow(dig - '0', numDigits);
                if (sum > value) { System.Console.WriteLine("over"); return false; }
            }
            return value == sum;
        }

        static void Main(string[] args)
        {
            var test = 0;
            Console.WriteLine(Narcissistic(test));
        }
    }
}
