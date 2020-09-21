using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class MorseCodeDecoder
{
    public static string DecodeBits(string bits)
    {
        if (bits.Length == 0) { return ""; }
        bits = bits.Trim('0');
        var rx1 = new Regex(@"1+");
        var rx0 = new Regex(@"0+");
        var timeUnit = Math.Min(rx1.Matches(bits).Select(g => g.Length).Min(),
                                bits.Contains('0') ? rx0.Matches(bits).Select(g => g.Length).Min() : Int32.MaxValue);
        // spaces between words
        bits = bits.Replace(new string('0', 7 * timeUnit), "   ");

        // pause between characters in word
        bits = bits.Replace(new string('0', 3 * timeUnit), " ");

        // pause between dots and dashes
        bits = bits.Replace(new string('0', 1 * timeUnit), "#");

        // get dashes
        bits = bits.Replace(new string('1', 3 * timeUnit), "-");

        // get dots
        bits = bits.Replace(new string('1', 1 * timeUnit), ".");

        // remove placeholders from string
        bits = bits.Replace("#", "");

        return bits;
    }

    public static string DecodeMorse(string morseCode)
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