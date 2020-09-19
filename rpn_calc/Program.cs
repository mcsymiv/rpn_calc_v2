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

            while (true)
            {
                Console.Write("Enter expression: ");
                Console.WriteLine(rpn.Calculate(Console.ReadLine()));
            }
            
        }
    }
}
