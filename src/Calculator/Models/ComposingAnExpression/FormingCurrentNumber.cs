using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Models.ComposingAnExpression
{
    /// <summary>
    /// Logic for forming the current number
    /// </summary>
    static class FormingCurrentNumber
    {
        #region Private members

        /// <summary>
        /// The maximum size of the current number
        /// </summary>
        private static int currentNumberMaxSize = 16;

        #endregion

        #region Public methods

        /// <summary>
        /// To add the selected digit to the current number
        /// </summary>
        public static string SetNumber(string currentNumber, char pressedNumber, out bool whichBtnIsPressed)
        {
            whichBtnIsPressed = true;

            if (CurrentNumberSizeCheck(currentNumber))
            {
                return currentNumber != "0" ? (currentNumber + pressedNumber) : pressedNumber.ToString();
            }

            return currentNumber;
        }

        /// <summary>
        /// To add or remove a minus in the current number
        /// </summary>
        public static string InvertNumber(string currentNumber)
        {
            return currentNumber != "0" ? (currentNumber.IndexOf('-') == -1 ? currentNumber.Insert(0, "-") : currentNumber.Remove(0, 1)) : currentNumber;
        }

        /// <summary>
        /// To add a comma to the current number
        /// </summary>
        public static string PutAComma(string currentNumber, out bool whichBtnIsPressed)
        {
            whichBtnIsPressed = true;

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

            return (currentNumber.Length - extraSize) < currentNumberMaxSize ? true : false;
        }

        #endregion
    }
}