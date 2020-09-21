using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interpreted Regex:");
            var input = "The quick brown fox jumps over lazy dog.";
            var timer = new Stopwatch();
            timer.Start();
            var interpretedRegex = new Regex("(fox|dog)*");
            for (int i = 0; i < 1000000; i++)
                interpretedRegex.Match(input);
            timer.Stop();
            Console.WriteLine("\tElapsed time: {0}ms", timer.ElapsedMilliseconds);
            Console.WriteLine("\tCache size: {0}", Regex.CacheSize);
            // Compiled regex below
            timer.Reset();
            Console.WriteLine("Compiled Regex:");
            timer.Start();
            var compiledRegex = new Regex("(fox|dog)*", RegexOptions.Compiled);
            for (int i = 0; i < 1000000; i++)
                compiledRegex.Match(input);
            timer.Stop();
            Console.WriteLine("\tElapsed time: {0}ms", timer.ElapsedMilliseconds);
            Console.WriteLine("\tCache size: {0}", Regex.CacheSize);

        }
    }

}


