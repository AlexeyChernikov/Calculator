using Calculator.Models.Calculation.Operations.ArithmeticOperations;
using Calculator.Models.Calculation.Operations.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorUnitTests
{
    [TestClass]
    public class ArithmeticOperationsTests
    {
        #region Addition tests

        [TestMethod]
        public void AdditionTest1()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20);
            double expected = 30;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionTest2()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(0);
            double expected = 10;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionTest3()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(20);
            double expected = 10;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionTest4()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20);
            double expected = -10;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionTest5()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(-20);
            double expected = -30;

            Addition addition = new Addition(leftArg, rightArg);
            double actual = addition.Operation();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Subtraction tests

        [TestMethod]
        public void SubtractionTest1()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20);
            double expected = -10;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionTest2()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(0);
            double expected = 10;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionTest3()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(20);
            double expected = -30;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionTest4()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20);
            double expected = 30;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionTest5()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(-20);
            double expected = 10;

            Subtraction subtraction = new Subtraction(leftArg, rightArg);
            double actual = subtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Multiplication tests

        [TestMethod]
        public void MultiplicationTest1()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(20);
            double expected = 200;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationTest2()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-20);
            double expected = -200;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationTest3()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(0);
            double expected = 0;

            Multiplication multiplication = new Multiplication(leftArg, rightArg);
            double actual = multiplication.Operation();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Division tests

        [TestMethod]
        public void DivisionTest1()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(2);
            double expected = 5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionTest2()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(2);
            double expected = -5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionTest3()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(-2);
            double expected = -5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionTest4()
        {
            Number leftArg = new Number(-10);
            Number rightArg = new Number(-2);
            double expected = 5;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionTest5()
        {
            Number leftArg = new Number(10);
            Number rightArg = new Number(0);
            double expected = double.PositiveInfinity;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionTest6()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(10);
            double expected = 0;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivisionTest7()
        {
            Number leftArg = new Number(0);
            Number rightArg = new Number(0);
            double expected = double.NaN;

            Division division = new Division(leftArg, rightArg);
            double actual = division.Operation();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Exponentiation tests

        [TestMethod]
        public void ExponentiationTest1()
        {
            Number number = new Number(10);
            Number power = new Number(2);
            double expected = 100;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExponentiationTest2()
        {
            Number number = new Number(-10);
            Number power = new Number(2);
            double expected = 100;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExponentiationTest3()
        {
            Number number = new Number(10);
            Number power = new Number(-2);
            double expected = 0.01;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExponentiationTest4()
        {
            Number number = new Number(-10);
            Number power = new Number(-2);
            double expected = 0.01;

            Exponentiation exponentiation = new Exponentiation(number, power);
            double actual = exponentiation.Operation();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region RootExtraction tests

        [TestMethod]
        public void RootExtractionTest1()
        {
            Number root = new Number(9);
            double expected = 3;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RootExtractionTest2()
        {
            Number root = new Number(-9);
            double expected = double.NaN;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RootExtractionTest3()
        {
            Number root = new Number(0);
            double expected = 0;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Negation tests

        [TestMethod]
        public void NegationTest1()
        {
            Number negate = new Number(10);
            double expected = -10;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegationTest2()
        {
            Number negate = new Number(-10);
            double expected = 10;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegationTest3()
        {
            Number negate = new Number(0);
            double expected = 0;

            Negation negation = new Negation(negate);
            double actual = negation.Operation();

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}