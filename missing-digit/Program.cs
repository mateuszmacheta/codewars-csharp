using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace missing_digit
{

    class Program
    {
        public static int solveExpression(string expression)
        {
            Regex splitRx = new Regex(@"(\+)|(?<=\?)(-)|(?<=\d)(-)|(=)|(\*)");
            Regex zeroChk = new Regex(@"^-?0{2,}");
            var operandsArray = splitRx.Split(expression);
            string op1 = operandsArray[0];
            string opType = operandsArray[1];
            string op2 = operandsArray[2];
            string res = operandsArray[4];
            string op1c, op2c, resC; // values for current iteration
            foreach (char i in Enumerable.Range('0', 10))
            {
                if (expression.Contains(i))
                { continue; }
                op1c = op1.Replace('?', i);
                op2c = op2.Replace('?', i);
                resC = res.Replace('?', i);
                // if we have leading zeroes
                if (i == '0' && (zeroChk.IsMatch(op1c) || zeroChk.IsMatch(op2c) || zeroChk.IsMatch(resC)))
                { continue; }
                if (compute(op1c, op2c, opType) == Int32.Parse(resC))
                { return i - '0'; }
            }
            return -1;
        }

        public static int compute(string one, string two, string operation)
        {
            int op1 = Int32.Parse(one);
            int op2 = Int32.Parse(two);
            switch (operation)
            {
                case "+":
                    return op1 + op2;
                case "-":
                    return op1 - op2;
                case "*":
                    return op1 * op2;
                default:
                    throw new InvalidOperationException("Invalid operation");
            }
        }
        static void Main(string[] args)
        {
            var test = new string[] { "1+1=?", "123*45?=5?088", "-5?*-1=5?", "19--45=5?", "??*??=302?", "?*11=??", "??*1=??", "??+??=??" };
            foreach (var item in test)
            {
                System.Console.Write(item);
                Console.WriteLine(" e= {0}", solveExpression(item));
            }
        }
    }
}
