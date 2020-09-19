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
            if ( c == ' ' ) return true;
            return false;
        }
        public bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1)) return true;
            return false;
        }
    }
}
