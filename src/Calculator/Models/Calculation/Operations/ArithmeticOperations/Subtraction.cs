using Calculator.Models.Calculation.Operations.Base;

namespace Calculator.Models.Calculation.Operations.ArithmeticOperations
{
    /// <summary>
    /// For subtracting numbers
    /// </summary>
    public class Subtraction : BinaryOperation
    {
        public Subtraction(UniversalOperation leftArg, UniversalOperation rightArg) : base(leftArg, rightArg) { }

        public override double Operation()
        {
            return leftArg.Operation() - rightArg.Operation();
        }
    }
}