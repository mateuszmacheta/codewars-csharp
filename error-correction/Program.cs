using System;
using System.Linq;

namespace error_correction
{
    class Program
    {

        public static string decode(string bits)
        {
            string binary = "";
            for (int i = 0; i < bits.Length; i += 3)
            {
                var sum = bits.Skip(i).Take(3).Sum(c => c - '0');
                if (sum < 2)
                { binary += '0'; }
                else
                { binary += '1'; }
            }
            string output = "";
            for (int i = 0; i < binary.Length; i += 8)
            {
                var charInBin = Convert.ToInt32(string.Join("", binary.Skip(i).Take(8)), 2);
                output += Convert.ToChar(charInBin);
            }
            return output;
        }
        public static string encode(string text)
        {
            var binary = string.Join("", text.Select(c => Convert.ToString(c, 2).PadLeft(8, '0')));
            return string.Join("", binary.Select(c => c == '0' ? "000" : "111"));
        }
        static void Main(string[] args)
        {
            var encodeTest = "hey";
            var decodeTest = "100111111000111001000010000111111000000111001111000111110110111000010111";
            Console.WriteLine(decode(decodeTest));
        }
    }
}
