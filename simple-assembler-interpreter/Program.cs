using System;
using System.Linq;
using System.Collections.Generic;

namespace simple_assembler_interpreter
{
    class Program
    {

        public static Dictionary<string, int> Interpret(string[] program)
        {
            Console.WriteLine("in: { " + string.Join(", ", program) + " }");
            var register = new Dictionary<string, int>();
            int i = 0; string instruction = "";
            while (i < program.Length)
            {
                string line = program[i];
                instruction = line.Substring(0, 3);
                switch (instruction)
                {
                    case "mov":
                        string variableName = line.Split(' ')[1];
                        string sourceName = line.Split(' ')[2];
                        int sourceInt = -1;
                        if (!register.ContainsKey(variableName))
                        {
                            register.Add(variableName, sourceInt);
                        }
                        if (Int32.TryParse(sourceName, out sourceInt))
                        {
                            register[variableName] = sourceInt;
                        }
                        else
                        {
                            register[variableName] = register[sourceName];
                        }
                        break;
                    case "inc":
                        string incVarName = line.Split(' ')[1];
                        register[incVarName]++;
                        break;
                    case "dec":
                        string decVarName = line.Split(' ')[1];
                        register[decVarName]--;
                        break;
                    case "jnz":
                        string jumpStepVar = line.Split(' ')[2];
                        string checkVar = line.Split(' ')[1];
                        int jumpStepInt = 0;
                        int checkInt = 0;
                        if (!Int32.TryParse(jumpStepVar, out jumpStepInt))
                        {
                            jumpStepInt = register[jumpStepVar];
                        }
                        if (!Int32.TryParse(checkVar, out checkInt))
                        {
                            checkInt = register[checkVar];
                        }
                        if (checkInt != 0)
                        {
                            i += jumpStepInt;
                            continue;
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid instruction: {instruction}");
                }
                i++;
            }
            return register;
        }

        static void Main(string[] args)
        {
            var test = new[] { "mov a 1", "mov b 1", "mov c 0", "mov d 26", "jnz c 2", "jnz 1 5", "mov c 7", "inc d", "dec c", "jnz c -2", "mov c a", "inc a", "dec b", "jnz b -2", "mov b c", "dec d", "jnz d -6", "mov c 18", "mov d 11", "inc a", "dec d", "jnz d -2", "dec c", "jnz c -5" };
            var output = Interpret(test);
            Console.WriteLine("{ " + string.Join(", ", output.Select(i => $"{i.Key}: {i.Value}")) + " }");
        }
    }
}
