using NUnit.Framework;
using rpn_calc;
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPN_UnitTest
{
    [TestFixture]
    public class Rpn_Test
    {
        [TestCase('+')]
        [TestCase('-')]
        [TestCase('*')]
        [TestCase('/')]
        [TestCase('^')]
        public void TrueIfValidOperator(char oper)
        {
            bool isExpectedOperator = new Rpn().IsOperator(oper);
            Assert.IsTrue(isExpectedOperator);
        }
    }
}
