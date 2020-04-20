using Calculator.Models.Calculation.Operations.Base;

namespace Calculator.Models.Calculation.Operations.ArithmeticOperations
{
    /// <summary>
    /// Makes numbers negative
    /// </summary>
    public class Negation : UnaryOperation
    {
        public Negation(UniversalOperation negate) : base(negate) { }

        public override double Operation() 
        { 
            return -arg.Operation();
        }
    }
}