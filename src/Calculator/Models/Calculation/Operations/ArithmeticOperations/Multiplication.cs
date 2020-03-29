using Calculator.Models.Calculation.Operations.Base;

namespace Calculator.Models.Calculation.Operations.ArithmeticOperations
{
    /// <summary>
    /// For multiplying numbers
    /// </summary>
    class Multiplication : BinaryOperation
    {
        public Multiplication(UniversalOperation leftArg, UniversalOperation rightArg) : base(leftArg, rightArg) { }

        public override double Operation()
        {
            return leftArg.Operation() * rightArg.Operation();
        }
    }
}