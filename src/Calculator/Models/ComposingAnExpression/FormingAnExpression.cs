using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models.ComposingAnExpression
{
    /// <summary>
    /// Logic for forming the current expression
    /// </summary>
    static class FormingAnExpression
    {
        #region Public methods

        /// <summary>
        /// To add the current number and the selected operation to the current expression
        /// </summary>
        public static string SetOperation(string currentNumber, string currentExpression, string selectedOperation, ref bool whichBtnIsPressed)
        {
            bool _whichBtnIsPressed = whichBtnIsPressed;

            whichBtnIsPressed = false;

            if (_whichBtnIsPressed)
            {
                if (currentNumber.IndexOf(',') != -1 && (currentNumber[currentNumber.Length-1]=='0' || currentNumber[currentNumber.Length - 1] == ','))
                {
                    currentNumber = ConvertingRealNumbers(currentNumber);
                }

                return NegateCheck(currentNumber) ? (currentExpression + '(' + currentNumber + ')' + selectedOperation) : (currentExpression + currentNumber + selectedOperation);
            }

            return !currentExpression.EndsWith(selectedOperation) && currentExpression != "" ? (currentExpression.Remove(currentExpression.Length - 3, 3) + selectedOperation) : currentExpression;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// To convert real numbers
        /// </summary>
        /// <example>
        /// 16,000000 => 16
        /// 3, => 3
        /// 3,1020000 => 3,102
        /// </example>
        /// <returns>
        /// The edited string of the current number
        /// </returns>
        private static string ConvertingRealNumbers(string currentNumber)
        {
            StringBuilder stringBuilderCurNo = new StringBuilder(currentNumber);

            while (stringBuilderCurNo.Length > 1 && (stringBuilderCurNo[stringBuilderCurNo.Length-1] == '0' || stringBuilderCurNo[stringBuilderCurNo.Length - 1] == ','))
            {
                stringBuilderCurNo.Remove(stringBuilderCurNo.Length-1, 1);
            }

            return stringBuilderCurNo.ToString();
        }

        /// <summary>
        /// To check if a current number is negative
        /// </summary>
        private static bool NegateCheck(string currentNumber)
        {
            return currentNumber[0] == '-' ? true : false;
        }

        #endregion
    }
}