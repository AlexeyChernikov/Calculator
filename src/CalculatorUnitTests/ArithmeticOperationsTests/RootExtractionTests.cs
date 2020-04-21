using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

namespace CalculatorUnitTests.ArithmeticOperationsTests
{
    [TestClass]
    public class RootExtractionTests
    {
        [TestMethod]
        public void TheSquareRootOfAPositiveInteger()
        {
            Number root = new Number(9);
            int expected = 3;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheSquareRootOfANegativeInteger()
        {
            Number root = new Number(-9);
            double expected = double.NaN;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheSquareRootOfAPositiveRealNumber()
        {
            Number root = new Number(9.5);
            double expected = 3.082207001484488;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheSquareRootOfANegativeRealNumber()
        {
            Number root = new Number(-9.5);
            double expected = double.NaN;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheSquareRootOfZero()
        {
            Number root = new Number(0);
            int expected = 0;

            RootExtraction rootExtraction = new RootExtraction(root);
            double actual = rootExtraction.Operation();

            Assert.AreEqual(expected, actual);
        }
    }
}