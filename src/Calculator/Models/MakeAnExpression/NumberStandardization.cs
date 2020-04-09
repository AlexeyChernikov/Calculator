using System.Text;

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
            if (number.IndexOf(',') != -1 && (number[number.Length - 1] == '0' || number[number.Length - 1] == ','))
            {
                number = ConvertingRealNumbers(number);
            }

            if (number[0] == '-')
            {
                number = NegatePutInParentheses(number);
            }

            return number;
        }

        #endregion

        #region Private methods

        //смотри issue #18
        /// <summary>
        /// To convert real number
        /// </summary>
        /// <example>
        /// 16,000000 => 16
        /// 3, => 3
        /// 3,1020000 => 3,102
        /// </example>
        /// <returns>
        /// The edited string of the current number
        /// </returns>
        private static string ConvertingRealNumbers(string number)
        {
            StringBuilder stringBuilderCurNo = new StringBuilder(number);

            while (stringBuilderCurNo.Length > 1 && (stringBuilderCurNo[stringBuilderCurNo.Length - 1] == '0' || stringBuilderCurNo[stringBuilderCurNo.Length - 1] == ','))
            {
                stringBuilderCurNo.Remove(stringBuilderCurNo.Length - 1, 1);
            }

            return stringBuilderCurNo.ToString();
        }

        /// <summary>
        /// To put a negative number in parentheses
        /// </summary>
        private static string NegatePutInParentheses(string number)
        {
            return '(' + number + ')';
        }

        #endregion
    }
}