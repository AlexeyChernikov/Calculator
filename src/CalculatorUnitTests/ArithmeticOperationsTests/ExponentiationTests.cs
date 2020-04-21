using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

namespace CalculatorUnitTests.ArithmeticOperationsTests
{
    [TestClass]
    public class ExponentiationTests
    {
        [TestMethod]
        public void TenSquared()
        {
            Number number = new Number(10);
            Number power = new Number(2);
            int expected = 100;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TenToThePowerOfFour()
        {
            Number number = new Number(10);
            Number power = new Number(4);
            int expected = 10000;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinusTenToThePowerOfTwo()
        {
            Number number = new Number(-10);
            Number power = new Number(2);
            int expected = 100;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TenToThePowerOfMinusTwo()
        {
            Number number = new Number(10);
            Number power = new Number(-2);
            double expected = 0.01;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinusTenToThePowerOfMinusTwo()
        {
            Number number = new Number(-10);
            Number power = new Number(-2);
            double expected = 0.01;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZeroToThePowerOfTen()
        {
            Number number = new Number(0);
            Number power = new Number(10);
            int expected = 0;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZeroToThePowerOfMinusTen()
        {
            Number number = new Number(0);
            Number power = new Number(-10);
            double expected = double.PositiveInfinity;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TenToThePowerOfZero()
        {
            Number number = new Number(10);
            Number power = new Number(0);
            int expected = 1;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinusTenToThePowerOfZero()
        {
            Number number = new Number(-10);
            Number power = new Number(0);
            int expected = 1;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZeroToThePowerOfZero()
        {
            Number number = new Number(0);
            Number power = new Number(0);
            int expected = 1;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }
    }
}