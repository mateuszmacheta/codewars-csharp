using System;
using System.Text;
using System.Linq;

namespace codewars_next_smaller_number
{
    class Program
    {
        public static string swapChars(string inputStr, int posA, int posB)
        {
            char charA = inputStr[posA];
            char charB = inputStr[posB];
            StringBuilder outStr = new StringBuilder();
            for (int i = 0; i < inputStr.Length; i++)
            {
                if (i != posA && i != posB)
                {
                    outStr.Append(inputStr[i]);
                }
                else if (i == posA)
                {
                    outStr.Append(charB);
                }
                else if (i == posB)
                {
                    outStr.Append(charA);
                }
            }
            return outStr.ToString();
        }
        public static long NextSmaller(long n)
        {
            string nSt = n.ToString();
            int nLen = nSt.Length;
            if (nLen == 1)
            { return -1; }
            if (nLen == 2)
            {
                if (nSt[0] > nSt[1]) { return Convert.ToInt64(String.Concat(nSt[1], nSt[0])); }
                return -1;
            }
            for (int i = 0; i < nLen - 2; i++)
            {
                int posA = nLen - 2 - i;
                int posB = nLen - 1 - i;
                if (nSt[posA] > nSt[posB])
                {
                    nSt = swapChars(nSt, posA, posB);
                    return Convert.ToInt64(nSt);
                }
            }
            if (nSt[0] > nSt[1])
            {
                if (nSt[0] == '1' && nSt[1] == '0') { return -1; };
                // find second smallest number to our most significant digit, then sort rest from the highest
                StringBuilder outSt = new StringBuilder();
                char nxMin = '0';
                for (int i = 1; i < nLen; i++)
                {
                    char curr = nSt[i];
                    if (curr < nSt[0] && curr > nxMin)
                    { nxMin = curr; }
                }
                Console.WriteLine(nxMin);
                outSt.Append(nxMin);
                bool skipped = false; int index = nSt.IndexOf(nxMin);
                outSt.Append(nSt.ToCharArray().Skip)

            }
            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(NextSmaller(907));
        }
    }
}
