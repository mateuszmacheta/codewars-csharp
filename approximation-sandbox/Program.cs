using System;
using System.Linq;
using System.Collections.Generic;

namespace approximation_sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            double target = 9.0 / 25;
            approx approximator = new approx(0, 20, 1e-12, target, 50, "");
            if (approximator.getApprox())
            {
                Console.WriteLine("Found value: {0:E12}", approximator.result);
            }
            else
            {
                Console.WriteLine("Approximate value not found after 50 tries.");
            }
        }
    }
}
