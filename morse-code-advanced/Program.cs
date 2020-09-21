using System;

namespace morse_code_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = "1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011";
            var out1 = MorseCodeDecoder.DecodeBits(test);
            Console.WriteLine(out1);
            System.Console.WriteLine(MorseCodeDecoder.DecodeMorse(out1));

        }
    }
}
