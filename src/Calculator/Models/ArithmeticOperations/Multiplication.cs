using Calculator.Models.Base;

namespace Calculator.Models.ArithmeticOperations
{
    class Multiplication : BinaryOperation
    {
        public Multiplication(UniversalOperation leftArg, UniversalOperation rightArg) : base(leftArg, rightArg) { }

        public override double Operation()
        {
            return leftArg.Operation() * rightArg.Operation();
        }
    }
}