using Calculator.Common;

namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// To clear the entered data
    /// </summary>
    static class ClearData
    {
        /// <summary>
        /// To clear the current number
        /// </summary>
        public static string ClearNumber(string currentNumber)
        {
            return currentNumber != ((int)Digits.Zero).ToString() ? ((int)Digits.Zero).ToString() : currentNumber;
        }

        /// <summary>
        /// To clear the current expression
        /// </summary>
        public static string ClearExpression(string currentExpression)
        {
            return currentExpression != string.Empty ? string.Empty : currentExpression;
        }

        /// <summary>
        /// To clear the last digit in the current number
        /// </summary>
        public static string Backspace(string currentNumber)
        {
            int len = currentNumber.IndexOf('-') == -1 ? 1 : 2;

            return currentNumber.Length != len ? currentNumber.Remove(currentNumber.Length - 1) : ((int)Digits.Zero).ToString();
        }
    }
}