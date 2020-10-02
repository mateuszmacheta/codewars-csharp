using System;
using System.Collections.Generic;

namespace buddy_pairs
{
    class Program
    {
        public class Number
        {
            public Number(long number)
            {
                this.number = number;
                this.sum = getDivisorSum(number);
            }
            public long number { get; set; }
            public long sum { get; set; }
        }

        public static long getDivisorSum(long num)
        {
            long sum = 1;
            double sqrt = Math.Sqrt(num);
            for (int i = 2; i < sqrt; i++)
            {
                if (num % i == 0)
                {
                    sum += (num / i);
                    sum += i;
                }
            }
            if (sqrt == Math.Floor(sqrt))
            { sum += (long)sqrt; }
            return sum;
        }

        public static Number findSecond(long second, long limit)
        {
            if (second > limit)
            { return new Number(0); }
            for (int i = 0; i < allNumbers.Count; i++)
            {
                if (allNumbers[i].number == second)
                { return allNumbers[i]; }
            }
            return new Number(0);
        }
        public static List<Number> allNumbers { get; set; }
        public static long limit { get; set; }

        public static string Buddy(long start, long limit)
        {
            allNumbers = new List<Number>();
            for (long i = start; i <= limit; i++)
            {
                Number entry = new Number(i);
                if (entry.sum > (start + 1))
                { allNumbers.Add(entry); }
            }

            for (int i = 0; i <= allNumbers.Count - 1; i++)
            {
                Number first = allNumbers[i];
                Number second = findSecond(first.sum - 1, limit);
                if (second.number != 0 && second.sum == first.number + 1)
                { return $"({first.number}, {second.number})"; }

                second = new Number(first.sum - 1);
                if (second.sum == first.number + 1)
                { return $"({first.number}, {second.number})"; }
            }
            return "Nothing";
        }
        static void Main(string[] args)
        {
            //var test = 
            Console.WriteLine(Buddy(10, 50));
        }
    }
}
