using System;

namespace Rule_of_Divisibility_by_7
{
    public class DivSeven
    {

        public static long[] Seven(long m)
        {
            int steps = 0; long clipped, lastDigit;
            while (Math.Log10(m) >= 2)
            {
                clipped = m / 10;
                lastDigit = m % 10;
                m = clipped - lastDigit * 2;
                steps++;
            }

            return new long[] { steps, m };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            long[] output = DivSeven.Seven(371);
            Console.WriteLine(output[0]);
            Console.WriteLine(output[1]);
        }
    }
}
