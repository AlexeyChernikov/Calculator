using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

namespace CalculatorUnitTests.ArithmeticOperationsTests
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void DivisionOfAPositiveIntegerByAPositiveInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(2);
            int expected = 5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfANegativeIntegerByANegativeInteger()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(-2);
            int expected = 5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfAPositiveIntegerByANegativeInteger()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-2);
            int expected = -5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfANegativeIntegerByAPositiveInteger()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(2);
            int expected = -5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfAPositiveIntegerByZero()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(0);
            double expected = double.PositiveInfinity;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfANegativeIntegerByZero()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(0);
            double expected = double.NegativeInfinity;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfZeroByAPositiveInteger()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(10);
            int expected = 0;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfZeroByANegativeInteger()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(-10);
            int expected = 0;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfAPositiveRealNumberByAPositiveRealNumber()
        {
            Number leftArg = new Number(10.5);
            Number rightArg = new Number(2.5);
            double expected = 4.2;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfANegativeRealNumberByANegativeRealNumber()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(-2.5);
            double expected = 4.2;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfAPositiveIntegerByANegativeRealNumber()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-2.5);
            int expected = -4;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfANegativeRealNumberByAPositiveInteger()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(2);
            double expected = -5.25;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfAPositiveRealNumberByZero()
        {
            Number leftArg = new Number(10.5);
            Number rightArg = new Number(0);
            double expected = double.PositiveInfinity;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfANegativeRealNumberByZero()
        {
            Number leftArg = new Number(-10.5);
            Number rightArg = new Number(0);
            double expected = double.NegativeInfinity;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfZeroByAPositiveRealNumber()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(10.5);
            int expected = 0;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfZeroByANegativeRealNumber()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(-10.5);
            int expected = 0;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionOfZeroByZero()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(0);
            double expected = double.NaN;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }
    }
}