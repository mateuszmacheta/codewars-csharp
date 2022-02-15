using System;
using System.Text;

public static class Base64Utils
{
	private static char[] base64table = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };
	public static string ToBase64(string s)
	{
		StringBuilder sb = new StringBuilder();

		var bytes = Encoding.UTF8.GetBytes(s);

		for (int i = 0; i < bytes.Length; i += 3)
		{
			System.Console.Write($"i: {i} ");
			System.Console.Write($"bytes[{i}]: {Convert.ToString(bytes[i], 2).PadLeft(8, '0')}");
			if (i + 1 < bytes.Length)
				System.Console.Write($" bytes[{i + 1}]: {Convert.ToString(bytes[i + 1], 2).PadLeft(8, '0')}");
			if (i + 2 < bytes.Length)
				System.Console.Write($" bytes[{i + 2}]: {Convert.ToString(bytes[i + 2], 2).PadLeft(8, '0')}");
			System.Console.WriteLine();

			int word = 0b_0000_000_0000_0000_0000_0000_0000_0000;

			// combine three bytes to form a 24-bit word

			word += bytes[i] << 16;
			word += bytes[i + 1] << 8;
			word += bytes[i + 2];

			// split then into 4 6-bit parts and translate

			sb.Append(base64table[word >> 18]);
			sb.Append(base64table[word & 0b_0000_000_0000_0011_1111_0000_0000_0000 >> 12]);
			sb.Append(base64table[word & 0b_0000_000_0000_0000_0000_1111_1100_0000 >> 6]);
			sb.Append(base64table[word & 0b_0000_000_0000_0000_0000_0000_0011_1111]);
		}

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
		System.Console.WriteLine(Base64Utils.ToBase64("Many hands make light work."));
	}
}
