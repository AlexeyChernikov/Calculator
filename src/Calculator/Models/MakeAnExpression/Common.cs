namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains common methods
    /// </summary>
    static class Common
    {
        /// <summary>
        /// To search for any basic mathematical operation in the current expression
        /// </summary>
        /// <returns>
        /// Returns "true" if a mathematical sign is found
        /// </returns>
        public static bool MathSignCheck(string currentExpression)
        {
            return
                currentExpression.IndexOf('+') != -1 || currentExpression.IndexOf('-') != -1 ||
                currentExpression.IndexOf('×') != -1 || currentExpression.IndexOf('÷') != -1 ? true : false;
        }
    }
}
