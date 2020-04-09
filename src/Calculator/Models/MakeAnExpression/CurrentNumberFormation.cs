using Calculator.Common;

namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Logic for forming the current number
    /// </summary>
    static class CurrentNumberFormation
    {
        #region Private members

        /// <summary>
        /// The maximum size of the current number
        /// </summary>
        private static readonly int currentNumberMaxSize = 16;

        #endregion

        #region Public methods

        /// <summary>
        /// To add the pressed digit to the current number
        /// </summary>
        public static string SetNumber(string currentNumber, Digits pressedDigit, ButtonsState buttonsState)
        {
            if (CurrentNumberSizeCheck(currentNumber))
            {
                return currentNumber != "0" ? (currentNumber + (int)pressedDigit) : ((int)pressedDigit).ToString();
            }
            else
            {
                return currentNumber;
            }
        }

        /// <summary>
        /// To add or remove a minus in the current number
        /// </summary>
        public static string InvertNumber(string currentNumber)
        {
            if (currentNumber != "0")
            {
                return currentNumber.IndexOf('-') == -1 ? currentNumber.Insert(0, "-") : currentNumber.Remove(0, 1);
            }
            else
            {
                return currentNumber;
            }
        }

        /// <summary>
        /// To add a comma to the current number
        /// </summary>
        public static string PutAComma(string currentNumber)
        {
            return currentNumber.IndexOf(',') == -1 ? currentNumber + ',' : currentNumber;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// To check the size of the current number
        /// </summary>
        private static bool CurrentNumberSizeCheck(string currentNumber)
        {
            int extraSize = 0;

            //If there is a '-' sign in the number
            if (currentNumber.IndexOf('-') != -1)
            {
                extraSize++;
            }

            //If there is a ',' sign in the number
            if (currentNumber.IndexOf(',') != -1)
            {
                extraSize++;
            }

            return currentNumber.Length < (currentNumberMaxSize + extraSize) ? true : false;
        }

        #endregion
    }
}