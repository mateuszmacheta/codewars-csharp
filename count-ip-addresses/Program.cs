using System;
using System.Linq;

namespace count_ip_addresses
{
    class Program
    {
        public static long IpsBetween(string start, string end)
        {
            var startArr = start.Split('.');
            var endArr = end.Split('.');
            var startStr = String.Join("", startArr.Select(o => Convert.ToString(Int16.Parse(o), 2).PadLeft(8, '0')));
            var endStr = String.Join("", endArr.Select(o => Convert.ToString(Int16.Parse(o), 2).PadLeft(8, '0')));
            return Convert.ToInt32(endStr, 2) - Convert.ToInt32(startStr, 2);
        }
        static void Main(string[] args)
        {
            //var test = new string[] {  };
            Console.WriteLine(IpsBetween("10.0.0.0", "10.0.0.50"));
        }
    }
}
