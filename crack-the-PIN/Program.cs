using System;
using System.Text;
using System.Security.Cryptography;


class Program
{
    public static string CreateMD5(string input)
    {
        // source: https://stackoverflow.com/a/24031467
        // Use input string to calculate MD5 hash
        using (MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    public static string crack(string hash)
    {
        hash = hash.ToUpper();
        string calculated = "";
        for (int i = 0; i <= 99999; i++)
        {
            calculated = CreateMD5(i.ToString("D5"));
            if (hash == calculated)
            { return i.ToString("D5"); }
        }
        return "";
    }
    static void Main(string[] args)
    {
        Console.WriteLine(crack("827ccb0eea8a706c4c34a16891f84e7b"));
    }
}
