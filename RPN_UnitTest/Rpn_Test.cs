using NUnit.Framework;
using rpn_calc;
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPN_UnitTest
{
    [SetUpFixture]
    public class MySetUpClass
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Console.WriteLine("SetupFixture - OneTimeSetup");
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            Console.WriteLine("SetupFixture - OneTimeTearDown");
        }
    }

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

        [TestCase('(')]
        [TestCase(')')]
        [TestCase('+')]
        [TestCase('-')]
        [TestCase('*')]
        [TestCase('/')]
        [TestCase('^')]
        public void PriorityNumberIfValidOperator(char oper)
        {
            int isExpectedPriorityNumber = new Rpn().GetPriority(oper);
            Assert.IsTrue(isExpectedPriorityNumber <= 5 || isExpectedPriorityNumber >= 0);
        }

        [TestCase(' ', true)]
        public void TrueIfSpaceIsDeliminer(char oper, bool expectedResult)
        {
            bool isExpected = new Rpn().IsSpace(oper);
            Assert.AreEqual(isExpected, expectedResult);
        }

        [TestCase(' ', false)]
        public void FalseIfDeliminerIsNotSpaceSymbol(char oper, bool expectedFalseResult)
        {
            bool isExpectedReversed = new Rpn().IsSpace(oper);
            Assert.AreEqual(!isExpectedReversed, expectedFalseResult);
        }

        [TestCase("3+4*2/(1-5)^2", "3 4 2 * 1 5 - 2 ^ / + ")]
        [TestCase("(1 + 2) * 4 + 3 ", "1 2 + 4 * 3 + ")]
        [TestCase("(10 - 15)*3", "10 15 - 3 * ")]
        public void ReturnRevesePolishNotationString(string input, string expectedNotation)
        {
            string isReversedNotationString = new Rpn().InputToRPNotation(input);
            Assert.AreEqual(isReversedNotationString, expectedNotation);
        }

        [TestCase("3 4 2 * 1 5 - 2 ^ / + ", 3.5)]
        [TestCase("1 2 + 4 * 3 + ", 15)]
        [TestCase("10 15 - 3 * ", -15)]
        public void ReturnResultOfRPNotationDouble(string input, double expectedResult)
        {
            double isResultDouble = new Rpn().CountRPNotation(input);
            Assert.AreEqual(isResultDouble, expectedResult);
        }

        [TestCase("exit", 3.141592653510)]
        public void EndTheProgramInCaseExitInputString(string input, double expectedResult)
        {
            double isUniqueDouble = new Rpn().Calculate(input);
            Assert.AreEqual(isUniqueDouble, expectedResult);
        }
    }
}
