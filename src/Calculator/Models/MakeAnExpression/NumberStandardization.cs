namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains methods that bring the passed number to a general form
    /// </summary>
    static class NumberStandardization
    {
        #region Public methods

        /// <summary>
        /// To bring the number to a general form
        /// </summary>
        /// <returns>
        /// Standardized number
        /// </returns>
        public static string Standardization(string number)
        {
            number = double.Parse(number).ToString();

            if (number.IndexOf('-') != -1)
            {
                number = '(' + number + ')';
            }

            return number;
        }

        #endregion
    }
}