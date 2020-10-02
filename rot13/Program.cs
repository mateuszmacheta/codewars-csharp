using System;
using System.Linq;

namespace rot13
{
    class Program
    {
        public static string Rot13(string message)
        {
            return string.Join("", message.Select(c => char.IsLetter(c) ? Rotate(c) : c));
        }

        private static char Rotate(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return (char)((c - 'A' + 13) % 26 + 'A');
            }
                return (char)((c - 'a' + 13) % 26 + 'a');

         }

        static void Main(string[] args)
        {
            var test = "test";
            Console.WriteLine(Rot13(test));
        }
    }
}
