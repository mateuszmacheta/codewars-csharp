using System;
using System.Collections.Generic;
using System.Linq;

namespace morse_code_basic
{

    class Program
    {
        class MorseCodeDecoder
        {
            public static string Decode(string morseCode)
            {
                Dictionary<string, string> morse = new Dictionary<string, string>{
                    {".-","A"},
                    {"-...","B"},
                    {"-.-.","C"},
                    {"-..","D"},
                    {".","E"},
                    {"..-.","F"},
                    {"--.","G"},
                    {"....","H"},
                    {"..","I"},
                    {".---","J"},
                    {"-.-","K"},
                    {".-..","L"},
                    {"--","M"},
                    {"-.","N"},
                    {"---","O"},
                    {".--.","P"},
                    {"--.-","Q"},
                    {".-.","R"},
                    {"...","S"},
                    {"-","T"},
                    {"..-","U"},
                    {"...-","V"},
                    {".--","W"},
                    {"-..-","X"},
                    {"-.--","Y"},
                    {"--..","Z"},
                    {"-----", "0"},
                    {".----", "1"},
                    {"..---", "2"},
                    {"...--", "3"},
                    {"....-", "4"},
                    {".....", "5"},
                    {"-....", "6"},
                    {"--...", "7"},
                    {"---..", "8"},
                    {"----.", "9"},
                    {"-.-.--", "!"},
                    {".-.-.-", "."},
                    {"*", " "},
                    {"...---...", "SOS"}
                };
                morseCode = morseCode.Trim();
                morseCode = morseCode.Replace("   ", " * ");
                return string.Join("", morseCode.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(w => morse[w]));
            }

        }
        static void Main(string[] args)
        {
            // for (int i = 'A'; i <= 'Z'; i++)
            // {
            //     System.Console.WriteLine(@"{"",'" + (char)i + @"'},");
            // }
            Console.WriteLine(MorseCodeDecoder.Decode("...---... -.-.--   - .... .   --.- ..- .. -.-. -.-   -... .-. --- .-- -.   ..-. --- -..-   .--- ..- -- .--. ...   --- ...- . .-.   - .... .   .-.. .- --.. -.--   -.. --- --. .-.-.- "));
        }
    }
}
