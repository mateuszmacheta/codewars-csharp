using System;
using System.Linq;

namespace your_order
{
    class Program
    {
        public static bool ValidatePin(string pin)
        {
            return pin.Length == 4 && pin.Sum(c => Char.IsDigit(c) ? 1 : 0) == 4;
        }
        static void Main(string[] args)
        {
            var test = "Thi4s is2 3a T1est";
            Console.WriteLine(ValidatePin("000a"));
        }
    }
}
