using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpn_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Rpn rpn = new Rpn();
            Console.WriteLine("Welcome to the RPN Calculator!");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("This is a calculator with reverse \npolish notation algorithm");
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("To close the program just type \"exit\" \ninto the \"Enter expression:\" field");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------");
            string input = string.Empty;
            double result = 0;
            while (true)
            {
                Console.Write("Enter expression: ");
                input = Console.ReadLine();
                if (input != "exit")
                {
                    result = rpn.Calculate(input);
                    Console.WriteLine(result);
                }
                else break;
            }

        }
    }
}
