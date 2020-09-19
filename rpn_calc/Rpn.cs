using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpn_calc
{
    public class Rpn
    {
        // method returns character priority
        public int GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }
        public bool IsSpace(char c)
        {
            if (c == ' ') return true;
            return false;
        }
        public bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1)) return true;
            return false;
        }
        public string InputToRPNotation(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (IsSpace(input[i])) continue;
                if (Char.IsDigit(input[i]))
                {
                    while (!IsSpace(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    output += " ";
                    i--;
                }
                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                    {
                        operStack.Push(input[i]);
                    }
                    else if (input[i] == ')')
                    {
                        char s = operStack.Pop();
                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                        {
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                            {
                                output += operStack.Pop().ToString() + " ";
                            }
                        }
                        operStack.Push(char.Parse(input[i].ToString()));

                    }
                }
            }
            while (operStack.Count > 0)
            {
                output += operStack.Pop() + " ";
            }

            return output;
        }
        public double CountRPNotation(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string numberStr = string.Empty;
                    while (!IsSpace(input[i]) && !IsOperator(input[i]))
                    {
                        numberStr += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(numberStr));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    double firstNumber = temp.Pop();
                    double secondNumber = temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = secondNumber + firstNumber; break;
                        case '-': result = secondNumber - firstNumber; break;
                        case '*': result = secondNumber * firstNumber; break;
                        case '/': result = secondNumber / firstNumber; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(secondNumber.ToString()), double.Parse(firstNumber.ToString())).ToString()); break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }
    }
}
