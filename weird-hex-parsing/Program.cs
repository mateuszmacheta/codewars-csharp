using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace weird_hex_parsing
{
    class Program
    {
        public static string ParseIPv6(string iPv6)
        {
            Regex rx = new Regex(@"[^A-F0-9]");
            StringBuilder result = new StringBuilder();

            var chunks = rx.Split(iPv6);

            foreach (var chunk in chunks)
            {
                result.Append(chunk.Sum(d => int.Parse(d.ToString(), System.Globalization.NumberStyles.HexNumber)).ToString());
            }
            return result.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ParseIPv6("1234:5678:9ABC:D00F:1111:2222:3333:4445"));
        }
    }
}
