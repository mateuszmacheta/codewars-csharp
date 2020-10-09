using System;

namespace pony_express
{
    class Program
    {

        public static int Riders(int[] stations)
        {
            if (stations.Length < 1)
            { throw new ArgumentException("Not enough stations."); }
            int count = 1;
            int sum = 0;
            for (int i = 0; i < stations.Length; i++)
            {
                if (sum + stations[i] > 100)
                {
                    count++;
                    sum = 0;
                }
                sum += stations[i];
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Riders(new int[] { 43, 23, 40, 13 }));
        }
    }
}
