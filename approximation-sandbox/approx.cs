using System;
using System.Collections.Generic;
using System.Linq;

class approx
{
    public approx(double startRange, double endRange, double e, double target, int maxApproximations, string methodName)
    {
        this.startRange = startRange;
        this.endRange = endRange;
        this.error = e;
        this.target = target;
        this.maxApproximations = maxApproximations;

        this.step = (endRange - startRange) / 5;
        positives = new List<Tuple<bool, double>>();
    }
    double startRange { get; set; }
    double endRange { get; set; }
    double step { get; set; }
    double error { get; set; }
    double target { get; set; }
    public int maxApproximations { get; set; }

    string methodName { get; set; }

    List<Tuple<bool, double>> positives { get; set; }

    public double result { get; set; }

    public bool getApprox()
    {
        while (!(positives.Count(c => c.Item1) > 0 && positives.Count(c => !c.Item1) > 0))
        {
            positives.Clear();
            step /= 2;
            for (double i = step; i < endRange; i += step)
            {
                double diff = function(i) - target;
                if (Math.Abs(diff) < error)
                {
                    result = i;
                    return true;
                }
                positives.Add(new Tuple<bool, double>(diff > 0, i));
            }
        }
        startRange = positives[positives.Count - 2].Item2;
        endRange = positives.Last().Item2;

        return getApprox();

    }

    double function(double x)
    {
        return x / 50;
    }
}