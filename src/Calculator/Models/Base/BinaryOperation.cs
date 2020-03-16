namespace Calculator.Models.Base
{
    abstract class BinaryOperation : UniversalOperation
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
