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
            whichBtnIsPressed = false;

            if (whichBtnIsPressed)
            {
                return NegateCheck(currentNumber) ? (currentExpression + '(' + currentNumber + ')' + selectedOperation) : (currentExpression + currentNumber + selectedOperation);
            }

            return !currentExpression.EndsWith(selectedOperation) && currentExpression != "" ? (currentExpression.Remove(currentExpression.Length - 3, 3) + selectedOperation) : currentExpression;
        }

        #endregion

        #region Private methods

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