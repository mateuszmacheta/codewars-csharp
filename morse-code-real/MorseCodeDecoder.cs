using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class MorseCodeDecoder
{
    public static string decodeBitsAdvanced(string bits)
    {
        if (bits.Length == 0 || !bits.Contains('1')) { return ""; }
        bits = bits.Trim('0');
        Regex rx1 = new Regex(@"1+");
        Regex rx0 = new Regex(@"0+");
        List<int> oneUnits = rx1.Matches(bits).Select(g => g.Length).ToList();
        List<int> zeroUnits = rx0.Matches(bits).Select(g => g.Length).ToList();

        KMeansClustering oneClusters = new KMeansClustering(2, oneUnits);
        KMeansClustering zeroClusters = new KMeansClustering(3, zeroUnits);
        oneClusters.FindClusters();
        zeroClusters.FindClusters();
        System.Console.WriteLine();

        // // spaces between words
        // bits = bits.Replace(new string('0', spaceUnit), "   ");

        // // pause between characters in word
        // bits = bits.Replace(new string('0', pauseUnit), " ");

        // // pause between dots and dashes
        // bits = bits.Replace(new string('0', inWordUnit), "#");

        // // get dashes
        // bits = bits.Replace(new string('1', dashUnit), "-");

        // // get dots
        // bits = bits.Replace(new string('1', dotUnit), ".");

        // // remove placeholders from string
        // bits = bits.Replace("#", "");

        return bits;
    }

    public static string decodeMorse(string morseCode)
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