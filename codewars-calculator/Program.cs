using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace codewars_calculator
{
    class Program
    {
        public static string executeOpreation(string expression, int index)
        {
            char[] operations = { '/', '*', '+', '-' };
            double result = 0;
            char operation = expression[index];
            string op1 = expression.Substring(0, index).Split(operations, StringSplitOptions.None).Last();
            string op2 = expression.Substring(index + 1).Split(operations, StringSplitOptions.None).First();
            switch (operation)
            {
                case '/':
                    result = Convert.ToDouble(op1) / Convert.ToDouble(op2);
                    break;
                case '*':
                    result = Convert.ToDouble(op1) * Convert.ToDouble(op2);
                    break;
                case '+':
                    result = Convert.ToDouble(op1) + Convert.ToDouble(op2);
                    break;
                case '-':
                    result = Convert.ToDouble(op1) - Convert.ToDouble(op2);
                    break;

            }
            expression = expression.Remove(index - op1.Length, op1.Length + op2.Length + 1).Insert(index - op1.Length, result.ToString());
            return expression;
            //return expression;
        }
        public static double Evaluate(string expression)
        {
            expression = expression.Replace(" ", "");
            Regex rx = new Regex(@"[+\-\/*]", RegexOptions.Compiled);
            while (rx.IsMatch(expression))
            {
                int index = expression.IndexOfAny(new char[] { '/', '*' });
                if (index > 0)
                {
                    expression = executeOpreation(expression, index);
                }
                else
                {
                    index = expression.IndexOfAny(new char[] { '+', '-' });
                    expression = executeOpreation(expression, index);
                }

            }
            return Convert.ToDouble(expression);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Evaluate("2 / 2 + 3 * 4 - 6"));
        }
    }
}
