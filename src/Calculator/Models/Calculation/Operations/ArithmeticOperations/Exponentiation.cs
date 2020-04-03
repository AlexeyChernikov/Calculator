using Calculator.Models.Calculation.Operations.Base;

namespace Calculator.Models.Calculation.Operations.ArithmeticOperations
{
    /// <summary>
    /// To raise the specified number to the specified power
    /// </summary>
    class Exponentiation : BinaryOperation
    {
        public Exponentiation(UniversalOperation number, UniversalOperation power) : base(number, power) { }

        public override double Operation()
        {
            return System.Math.Pow(leftArg.Operation(), rightArg.Operation());
        }
    }
}