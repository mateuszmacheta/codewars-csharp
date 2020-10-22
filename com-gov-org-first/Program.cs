using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace com_gov_org_first
{
    public static class SortingTask
    {
        public static IEnumerable<string> OrderByDomain(this IEnumerable<string> source)
        {
            Regex rx = new Regex(@"\.(\w+)\/");
            string[] topDomains = new string[] { "com", "gov", "org" };
            var res = source.Select(e => new
            {
                url = e,
                domain = rx.Match(e).Groups[1].Value,
                top = !topDomains.Contains(rx.Match(e).Groups[1].Value)
            });
            var res2 = res.OrderBy(e => e.top)
            .ThenBy(e => e.domain)
            .Select(e => e.url);
            return res2;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", SortingTask.OrderByDomain(new List<string>{"http://www.google.en/?x=jsdfkj",
"http://www.google.de/?x=jsdfkj",
"http://www.google.com/?x=jsdfkj",
"http://www.google.com/?x=jsdfkj",
"http://www.google.org/?x=jsdfkj",
"http://www.google.gov/?x=jsdfkj"})));
        }
    }
}
