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
            number = decimal.Parse(number).ToString();
            number = ConvertingRealNumbers(number);

            if (number.IndexOf('-') != -1)
            {
                number = '(' + number + ')';
            }

            return number;
        }

        /// <summary>
        /// To check if the current number is a number
        /// </summary>
        public static bool NumberCheck(string currentNumber)
        {
            try
            {
                decimal.Parse(currentNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Private methods

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

            while ((stringBuilderCurNo.ToString().IndexOf(',') != -1) && (stringBuilderCurNo[stringBuilderCurNo.Length - 1] == '0' || stringBuilderCurNo[stringBuilderCurNo.Length - 1] == ','))
            {
                stringBuilderCurNo.Remove(stringBuilderCurNo.Length - 1, 1);
            }

            return stringBuilderCurNo.ToString();
        }
        
        #endregion
    }
}