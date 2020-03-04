namespace Calculator.Models
{
    class Subtraction : BinaryOperation
    {
        public Subtraction(UniversalOperation leftArg, UniversalOperation rightArg) : base(leftArg, rightArg) { }

        public override double Operation()
        {
            return leftArg.Operation() - rightArg.Operation();
        }
    }
}