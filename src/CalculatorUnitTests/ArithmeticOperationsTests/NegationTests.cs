using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

namespace CalculatorUnitTests.ArithmeticOperationsTests
{
    [TestClass]
    public class NegationTests
    {
        [TestMethod]
        public void NegationPositiveInteger()
        {
            Number negate = new Number(10);
            int expected = -10;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegationNegativeInteger()
        {
            Number negate = new Number(-10);
            int expected = 10;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegationPositiveRealNumber()
        {
            Number negate = new Number(10.5);
            double expected = -10.5;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegationNegativeRealNumber()
        {
            Number negate = new Number(-10.5);
            double expected = 10.5;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegationZero()
        {
            Number negate = new Number(0);
            int expected = 0;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }
    }
}