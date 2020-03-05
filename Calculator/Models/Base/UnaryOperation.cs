namespace Calculator.Models.Base
{
    abstract class UnaryOperation : UniversalOperation
    {
        protected UniversalOperation operation;

        public UnaryOperation(UniversalOperation operation)
        {
            this.operation = operation;
        }
    }
}
