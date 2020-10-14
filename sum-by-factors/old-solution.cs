using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfDivided {
	
        public static string sumOfDivided(int[] lst)
        {
          foreach(var dig in lst)
            {
            Console.Write(dig + ' ');
          }
          Console.WriteLine();
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < lst.Length; i++)
            {
                List<int> primeFactors = new List<int>();
                getPrimeFactors(lst[i], ref primeFactors);
                primeFactors = primeFactors.Distinct().ToList();
                foreach (var factor in primeFactors)
                {
                    if (result.ContainsKey(factor))
                    {
                        result[factor] += lst[i];
                    }
                    else
                    {
                        result.Add(factor, lst[i]);
                    }
                }
            }
            return string.Concat(result.Select(r => "(" + r.Key + " " + r.Value + ")"));
        }

        public static void getPrimeFactors(int n, ref List<int> primeF)
        {
            int divisor = 2;
            while (n != 1)
            {
                if (Math.Floor((double)n / divisor) == ((double)n / divisor))
                {
                    primeF.Add(divisor);
                    n /= divisor;
                }
                else
                { divisor++; }
            }
        }
}