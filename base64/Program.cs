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
			int word = 0;
			char[] encodedChars = new char[] { '=', '=', '=', '=' };

			// combine three bytes to form a 24-bit word
			word += bytes[i] << 16;
			if (i + 1 < bytes.Length)
				word += bytes[i + 1] << 8;
			if (i + 2 < bytes.Length)
				word += bytes[i + 2];

			// split then into 4 6-bit parts and translate
			encodedChars[0] = base64table[word >> 18];
			encodedChars[1] = base64table[(word & 0b_0000_0000_0000_0011_1111_0000_0000_0000) >> 12];
			if (i + 1 < bytes.Length)
				encodedChars[2] = base64table[(word & 0b_0000_0000_0000_0000_0000_1111_1100_0000) >> 6];
			if (i + 2 < bytes.Length)
				encodedChars[3] = base64table[word & 0b_0000_0000_0000_0000_0000_0000_0011_1111];

			sb.Append(string.Join("", encodedChars));
		}
		return sb.ToString();
	}

	public static string FromBase64(string s)
	{
		if (s.Length % 4 != 0)
			throw new SystemException("Input string has incorrect length.");
		if (s.Length == 0)
			return "";

		StringBuilder sb = new StringBuilder();
		char[] decodedChars = new char[3];
		int i = 0; int word = 0;

		for (; i < s.Length - 4; i += 4)
		{
			word = 0;
			word += Array.IndexOf(base64table, s[i]) << 18;
			word += Array.IndexOf(base64table, s[i + 1]) << 12;
			word += Array.IndexOf(base64table, s[i + 2]) << 6;
			word += Array.IndexOf(base64table, s[i + 3]);

			sb.Append((char)(word >> 16));
			sb.Append((char)((word & 0b_0000_0000_0000_0000_1111_1111_0000_0000) >> 8));
			sb.Append((char)(word & 0b_0000_0000_0000_0000_0000_0000_1111_1111));
		}

		word = 0;
		word += Array.IndexOf(base64table, s[i]) << 18;
		word += Array.IndexOf(base64table, s[i + 1]) << 12;
		sb.Append((char)(word >> 16));

		if (s.EndsWith("=="))
			return sb.ToString();

		word += Array.IndexOf(base64table, s[i + 2]) << 6;
		sb.Append((char)((word & 0b_0000_0000_0000_0000_1111_1111_0000_0000) >> 8));

		if (s.EndsWith("="))
			return sb.ToString();

		word += Array.IndexOf(base64table, s[i + 3]);
		sb.Append((char)(word & 0b_0000_0000_0000_0000_0000_0000_1111_1111));
		return sb.ToString();
	}
}
class Program
{
	static void Main(string[] args)
	{
		System.Console.WriteLine(Base64Utils.ToBase64("M"));
		System.Console.WriteLine(Base64Utils.FromBase64("bGlnaHQgd29y"));
	}
}
