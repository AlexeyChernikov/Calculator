namespace Calculator.Models
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