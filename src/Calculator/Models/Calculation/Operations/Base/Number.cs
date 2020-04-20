namespace Calculator.Models.Calculation.Operations.Base
{
    /// <summary>
    /// To store the number obtained from the current expression
    /// </summary>
    public class Number : UniversalOperation
    {
        private double value;

        public Number(double value)
        {
            this.value = value;
        }

        public override double Operation()
        {
            return value;
        }
    }
}