using System;
using System.Collections.Generic;
using System.Linq;

namespace twice_linear
{
	public class DoubleLinear
	{
		private static HashSet<int> a = new HashSet<int>() { 1 };

		static DoubleLinear()
		{
			const int max = 60000;

			int x = 0, y = 0;

			for (int i = 0; i < max; i++)
			{
				int nextX = 2 * a.ElementAt(i) + 1;
				int nextY = 3 * a.ElementAt(i) + 1;
				if (nextX <= nextY)
				{
					a.Add(nextX);
					x++;
					if (nextX == nextY) y++;
				}
				else
				{
					a.Add(nextY);
					y++;
				}
			}
		}

		public static int DblLinear(int n)
		{
			System.Console.WriteLine($"n: {n}");
			return a.ElementAt(n);
		}
	}
	class Program
	{

		static void Main(string[] args)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();
			Console.WriteLine(DoubleLinear.DblLinear(10));
			System.Console.WriteLine($"Time: {watch.ElapsedMilliseconds / 1000:D2} s");
		}
	}
}