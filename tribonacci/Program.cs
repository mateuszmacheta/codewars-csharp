using System;
using System.Collections.Generic;
using System.Linq;

namespace tribonacci
{
    class Program
    {

        class Xbonacci
        {
            public Xbonacci()
            {
                this.signature = new double[3];
                this.result = new List<double>();
            }
            public double[] signature { get; set; }

            public List<double> result { get; set; }
            public double[] Tribonacci(double[] signature, int n)
            {
                this.signature = new double[3];
                this.result = new List<double>();
                if (n == 0) { return new double[] { }; }
                int i = 0;
                foreach (double num in signature)
                {
                    this.signature[i++] = num;
                    this.result.Add(num);
                }
                for (i = 3; i < n; i++)
                {
                    result.Add(result[i - 3] + result[i - 2] + result[i - 1]);
                }
                return result.Take(n).ToArray();
            }
        }
        static void Main(string[] args)
        {
            var tribon = new Xbonacci();
            var inSignature = new double[] { 3, 8, 7 };
            var output = tribon.Tribonacci(inSignature, 32);
        }
    }
}
