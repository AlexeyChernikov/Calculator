namespace Calculator.Models.Calculation.Operations.Base
{
    /// <summary>
    /// To perform operations with two operands
    /// </summary>
    public abstract class BinaryOperation : UniversalOperation
    {
        protected UniversalOperation leftArg;
        protected UniversalOperation rightArg;

        public BinaryOperation(UniversalOperation leftArg, UniversalOperation rightArg)
        {
            this.leftArg = leftArg;
            this.rightArg = rightArg;
        }
    }
}