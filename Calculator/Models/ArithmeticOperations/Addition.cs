using Calculator.Models.Base;

namespace Calculator.Models.ArithmeticOperations
{
    class Addition : BinaryOperation
    {
        public Addition(UniversalOperation leftArg, UniversalOperation rightArg) : base(leftArg, rightArg) { }

        public override double Operation()
        {
            return leftArg.Operation() + rightArg.Operation();
        }
    }
}