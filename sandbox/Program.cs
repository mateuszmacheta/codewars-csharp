using System;
using System.Text;

public class Kata
{
	public static string UpdateLight(string current)
	{
		var sequence = new string[3] { "green", "yellow", "red" };
		return sequence[(Array.IndexOf(sequence, current) + 1) % 3];
	}
}
class Program
{
	static void Main(string[] args)
	{
		System.Console.WriteLine(Base64Utils.ToBase64("appleapple"));
	}
}
