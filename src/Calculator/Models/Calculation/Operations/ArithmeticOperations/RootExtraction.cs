using Calculator.Models.Calculation.Operations.Base;

namespace Calculator.Models.Calculation.Operations.ArithmeticOperations
{
    /// <summary>
    /// To extract the square root of a number
    /// </summary>
    class RootExtraction : UnaryOperation
    {
        public RootExtraction(UniversalOperation root) : base(root) { }

        public override double Operation()
        {
            return System.Math.Sqrt(arg.Operation());
        }
    }
}