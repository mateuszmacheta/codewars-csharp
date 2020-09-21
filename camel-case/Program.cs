using System;

namespace codewars
{
    class Program
    {
        public static string ToCamelCase(string str)
        {
            char[] sep = { '-', '_' };
            string[] strArr = str.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < strArr.Length; i++)
            {
                System.Globalization.CultureInfo cult = System.Globalization.CultureInfo.CurrentCulture;
                strArr[i] = cult.TextInfo.ToTitleCase(strArr[i]);
            }
            str = String.Join("", strArr);
            return str;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ToCamelCase(""));
        }
    }
}
