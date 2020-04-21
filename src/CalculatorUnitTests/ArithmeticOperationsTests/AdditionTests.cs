using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

namespace CalculatorUnitTests.ArithmeticOperationsTests
{
    [TestClass]
    public class AdditionTests
    {
        [TestMethod]
        public void AdditionOfTwoPositiveIntegers()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20);
            int expected = 30;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionOfTwoNegativeIntegers()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(-20);
            int expected = -30;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionOfPositiveAndNegativeIntegers()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20);
            int expected = -10;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void AdditionOfNegativeAndPositiveIntegers()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(20);
            int expected = 10;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionOfTwoPositiveRealNumbers()
        {
            Number leftArg = new Number(10.2);
            Number rightArg = new Number(20.4);
            decimal expected = 30.6m;

            Addition addition = new Addition(leftArg, rightArg);
            decimal actual = (decimal)addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionOfTwoNegativeRealNumbers()
        {
            Number leftArg = new Number(-10.2);
            Number rightArg = new Number(-20.4);
            decimal expected = -30.6m;

            Addition addition = new Addition(leftArg, rightArg);
            decimal actual = (decimal)addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionOfPositiveAndNegativeRealNumbers()
        {
            Number leftArg = new Number(10.2);
            Number rightArg = new Number(-20.4);
            double expected = -10.2;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionOfNegativeAndPositiveRealNumbers()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(20.5);
            int expected = 10;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionOfAnIntegerAndARealNumber()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20.4);
            double expected = 30.4;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }
    }
}