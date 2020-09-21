using System;
using System.Collections.Generic;
using System.Linq;

namespace morse_code_real
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = "0000000011011010011100000110000001111110100111110011111100000000000111011111111011111011111000000101100011111100000111110011101100000100000";
            Console.WriteLine(MorseCodeDecoder.decodeBitsAdvanced(test));

        }
    }
}
