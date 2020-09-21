using System;
using System.Collections.Generic;

namespace upside_down_challenge
{

    class Program
    {
        static public double UpsideDown(string x, string y)
        {
            int valid = 0;
            for (int i = Int32.Parse(x); i <= Int32.Parse(y); i++)
            {
                if (validate(i.ToString()))
                { valid++; }
            }
            return valid;
        }

        static private bool validate(string v)
        {
            Dictionary<char, char> rotation = new Dictionary<char, char>{
                {'0','0'}, {'1', '1'}, {'6', '9'},{'8', '8'},{'9','6'}};
            char[] invalidRotation = new char[] { '2', '3', '4', '5', '7' };
            string midRotation = "018";
            if (v.Length % 2 == 0)
            {
                // even number of letters
                if (v.IndexOfAny(invalidRotation) > -1)
                { return false; }
                for (int i = 0; i < v.Length / 2; i++)
                {
                    if (rotation[v[i]] != v[v.Length - 1 - i])
                    { return false; }
                }
            }
            else
            {
                // uneven number of letters
                if (v.IndexOfAny(invalidRotation) > -1 || !midRotation.Contains(v[v.Length / 2]))
                { return false; }
                for (int i = 0; i < v.Length / 2; i++)
                {
                    if (rotation[v[i]] != v[v.Length - 1 - i])
                    { return false; }
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(UpsideDown("100", "1000"));
        }
    }
}
