using System;
using System.Collections.Generic;
using System.Linq;

class approx
{
    public approx(double startRange, double endRange, double e, double target, int maxApproximations)
    {
        this.startRange = startRange;
        this.endRange = endRange;
        this.error = e;
        this.target = target;
        this.maxApproximations = maxApproximations;
        this.approximationCount = 0;
        this.includeEdges = true;

        positives = new List<Tuple<bool, double>>();
    }
    double startRange { get; set; }
    double endRange { get; set; }
    double error { get; set; }
    double target { get; set; }
    public int maxApproximations { get; set; }

    public int approximationCount { get; set; }

    bool includeEdges { get; set; }

    List<Tuple<bool, double>> positives { get; set; }

    public double result { get; set; }

    public bool getApprox()
    {
        double step = (endRange - startRange) / 10;
        System.Console.WriteLine("startR: {0}, endR: {1}", startRange, endRange);
        while (true)
        {
            if (approximationCount++ > maxApproximations)
            { return false; }

            positives.Clear();
            for (double i = startRange + (includeEdges ? 0 : step); i < endRange + (includeEdges ? step : 0); i += step)
            {
                System.Console.WriteLine("a: {0} i: {1}", approximationCount, i);
                double diff = function(i) - target;
                if (Math.Abs(diff) < error)
                {
                    result = i;
                    return true;
                }
                positives.Add(new Tuple<bool, double>(diff > 0, i));

                if (positives.Count(c => c.Item1) > 0 && positives.Count(c => !c.Item1) > 0)
                { goto escape; }
            }
        }
    escape:
        startRange = positives[positives.Count - 2].Item2;
        endRange = positives.Last().Item2;
        includeEdges = true;

        return getApprox();

    }

    double function(double x)
    {
        int n = 100;
        return x * (1 - (n + 1) * Math.Pow(x, n) + n * Math.Pow(x, n + 1)) / Math.Pow(1 - x, 2);
    }
}