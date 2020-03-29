namespace Calculator.Models.Calculation.Operations.Base
{
    /// <summary>
    /// To perform operations with one operand
    /// </summary>
    abstract class UnaryOperation : UniversalOperation
    {
        protected UniversalOperation arg;

        public UnaryOperation(UniversalOperation arg)
        {
            this.arg = arg;
        }
    }
}