using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

namespace CalculatorUnitTests.ArithmeticOperationsTests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void MultiplicationOfAPositiveIntegerByAPositiveInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20);
            int expected = 200;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void MultiplicationOfANegativeIntegerByANegativeInteger()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(-20);
            int expected = 200;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfAPositiveIntegerByANegativeInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20);
            int expected = -200;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfANegativeIntegerByAPositiveInteger()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(20);
            int expected = -200;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfAPositiveIntegerByANegativeRealNumber()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20.5);
            int expected = -205;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfANegativeIntegerByAPositiveRealNumber()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(20.5);
            int expected = -205;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfAPositiveRealNumberByAPositiveRealNumber()
        {
            Number leftArg = new Number(10.5);
            Number rightArg = new Number(20.5);
            double expected = 215.25;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfANegativeRealNumberByANegativeRealNumber()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(-20.5);
            double expected = 215.25;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfAPositiveRealNumberByANegativeRealNumber()
        {
            Number leftArg = new Number(10.5);
            Number rightArg = new Number(-20.5);
            double expected = -215.25;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfANegativeRealNumberByAPositiveRealNumber()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(20.5);
            double expected = -215.25;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfZeroByAPositiveInteger()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(20);
            int expected = 0;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfAPositiveIntegerByZero()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(0);
            int expected = 0;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationOfZeroByZero()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(0);
            int expected = 0;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }
    }
}