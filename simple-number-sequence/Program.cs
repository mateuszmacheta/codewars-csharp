using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace simple_number_sequence
{
    class Program
    {
        public static int missing(string s)
        {
            Regex rx = new Regex(@"^9+$", RegexOptions.Compiled);
            Regex rx2 = new Regex(@"^9*8$", RegexOptions.Compiled);
            // get list of delta = differences between between consecutive numbers
            // in a function of character length

            int charLen = 1, i = 0; ;
            string tempStr = "";
            List<List<int>> numbers = new List<List<int>>();
            List<List<int>> delta = new List<List<int>>();

            while (charLen <= 6)
            {
                int upDigit = 0;
                List<int> currNumbers = new List<int>();
                List<int> currDelta = new List<int>();
                var stringDivided = new List<string>();
                for (int j = 0; j <= s.Length - charLen - upDigit;)
                {
                    tempStr = s.Substring(j, charLen + upDigit);
                    j += charLen + upDigit;
                    if (rx.IsMatch(tempStr))
                    { upDigit++; }
                    // below is for cases where we have 9, 99, 999... missing
                    else if (rx2.IsMatch(tempStr) && !rx.IsMatch(s.Substring(j, charLen + upDigit)))
                    { upDigit++; }
                    currNumbers.Add(Int32.Parse(tempStr));

                }
                if (currNumbers.Count() > 1)
                { currDelta = currNumbers.Take(currNumbers.Count() - 1).Select((v, index) => currNumbers[index + 1] - v).ToList(); }
                else
                {
                    currNumbers = new List<int>();
                    currDelta = new List<int>();
                }
                numbers.Add(currNumbers);
                delta.Add(currDelta);
                charLen++;
                i++;
            }
            // find last list of deltas where we have
            // - more than 1 item = proper sequence
            // - exactly number of 1's is 1 less then number of all items = there's only one number not in sequence
            // - exactly one '2' = number not in a sequence is just 1 off another number
            int resIndex = delta.FindLastIndex(x => (x.Count() > 1) && (x.Count(y => y == 1) == x.Count() - 1) && (x.Count(y => y == 2) == 1));
            if (resIndex >= 0)
            {
                int indexOfONeBe4Missing = delta[resIndex].FindIndex(x => x == 2);
                int outcome = numbers[resIndex][indexOfONeBe4Missing] + 1;
                return outcome;
            }
            else { return -1; }
        }
        static void Main(string[] args)
        {
            var test = "9929939949959969979981000100110021003";
            Console.WriteLine(missing(test));
        }
    }
}
