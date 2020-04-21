using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

namespace CalculatorUnitTests.ArithmeticOperationsTests
{
    [TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void SubtractionAPositiveIntegerFromAPositiveInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20);
            int expected = -10;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionANegativeIntegerFromAPositiveInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20);
            int expected = 30;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionAPositiveIntegerFromANegativeInteger()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(20);
            int expected = -30;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionANegativeIntegerFromANegativeInteger()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(-20);
            int expected = 10;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionAPositiveRealNumberFromAPositiveInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20.5);
            double expected = -10.5;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionANegativeRealNumberFromAPositiveInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20.5);
            double expected = 30.5;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionAPositiveIntegerFromAPositiveRealNumber()
        {
            Number leftArg = new Number(10.5);
            Number rightArg = new Number(20);
            double expected = -9.5;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionAPositiveIntegerFromANegativeRealNumber()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(20);
            double expected = -30.5;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionAPositiveRealNumberFromAPositiveRealNumber()
        {
            Number leftArg = new Number(10.5);
            Number rightArg = new Number(20.5);
            int expected = -10;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionANegativeRealNumberFromANegativeRealNumber()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(-20.5);
            int expected = 10;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }
    }
}