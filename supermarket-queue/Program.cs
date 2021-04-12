using System;
using System.Collections.Generic;
using System.Linq;


public class Kata
{
    public static long QueueTime(int[] customers, int n)
    {
        if (n == 1)
            return customers.Sum();

        int[] currentlyAtTills = new int[n];
        Queue<int> customersQ = new Queue<int>(customers);
        bool queueHasItems = true;
        int time = 0; int minTime;
        while (queueHasItems)
        {
            minTime = int.MaxValue;
            // populate tills
            for (int i = 0; i < n; i++)
            {
                if (currentlyAtTills[i] == 0)
                    queueHasItems = customersQ.TryDequeue(out currentlyAtTills[i]);
                // get minimum value, but not 0
                if (currentlyAtTills[i] != 0)
                    minTime = (currentlyAtTills[i] < minTime ? currentlyAtTills[i] : minTime);
            }
            time += minTime;

            // decrease all customer's time by what quickest customer was
            for (int i = 0; i < n; i++)
                currentlyAtTills[i] -= minTime;
        }

        time += currentlyAtTills.Max();
        return time;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine(Kata.QueueTime(new int[] { 1, 2, 3, 4 }, 1));

        Console.WriteLine(Kata.QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2));
    }
}
