namespace Calculator.Models
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
