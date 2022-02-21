using System;
using System.Text;

public static class Base64Utils
{
	public static string ToBase64(string s)
	{
		StringBuilder sb = new StringBuilder();

		var bytes = Encoding.UTF8.GetBytes(s);

		return s;
	}

	public static string FromBase64(string s)
	{
		// Happy coding!
		return s;
	}
}
class Program
{
	static void Main(string[] args)
	{
		System.Console.WriteLine(Base64Utils.ToBase64("appleapple"));
	}
}
