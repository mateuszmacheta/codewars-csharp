using System;
using System.Text;

namespace the_title_case
{
    public class Kata
    {
        public static string TitleCase(string title, string minorWords = "")
        {
            string[] titleArr = title.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            minorWords = minorWords.ToLower();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < titleArr.Length; i++)
            {
                if (i == 0 || !minorWords.Contains(titleArr[i].ToLower()))
                    sb.Append(toTitleCase(titleArr[i]) + ' ');
                else
                    sb.Append((titleArr[i].ToLower()) + ' ');

            }
            return sb.ToString().TrimEnd(' ');
        }

        private static string toTitleCase(string v)
        {
            return v.Substring(0, 1).ToUpper() + v.Substring(1, v.Length - 1).ToLower();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.TitleCase("a clash of KINGS", "a an the of"));
        }
    }
}
