using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Common;

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
        public static string SetBasicMathOperation(string currentNumber, string currentExpression, Operations selectedOperation, ref bool whichBtnIsPressed, ref bool firstUsedCheck)
        {
            bool _whichBtnIsPressed = whichBtnIsPressed;
            bool _firstUsedCheck = firstUsedCheck;

            whichBtnIsPressed = false;
            firstUsedCheck = true;

            //нажата и не нажата
            //если была нажата цифра, но не дополнительная операция
            if (_whichBtnIsPressed && _firstUsedCheck)
            {
                return currentExpression + NumberStandardization(currentNumber) + test(selectedOperation);
            }
            //обе нажаты
            //если была нажата цифра и дополнительная операция
            else if (_whichBtnIsPressed && !_firstUsedCheck)
            {
                return currentExpression + test(selectedOperation);
            }
            //смена знака
            else
            {
                return ChangeOperation(currentExpression, test(selectedOperation));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="firstUsedCheck">To check if this is the first time an additional operation is used in this part of the expression?</param>
        /// <returns>
        /// 
        /// </returns>
        public static string SetAdditionalOperation(string currentNumber, string currentExpression, string selectedOperation, ref bool firstUsedCheck, out bool whichBtnIsPressed)
        {
            whichBtnIsPressed = true;

            //If the additional operation is used for the first time
            if (firstUsedCheck)
            {
                firstUsedCheck = false;

                //currentNumber = NumberStandardization(currentNumber);

                return currentExpression + selectedOperation + '(' + NumberStandardization(currentNumber) + ')';
            }
            else
            {
                return ChangeTheSetOfRecentAdditionalOperations(currentExpression, selectedOperation);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// 
        /// </summary>
        private static string test(Operations selectedOperation)
        {
            switch (selectedOperation)
            {
                case Operations.Addition: return " + ";
                case Operations.Subtraction: return " - ";
                case Operations.Multiplication: return " × ";
                case Operations.Division: return " ÷ ";
                case Operations.Equally: return " = ";
                case Operations.Exponentiation: return "";
                case Operations.RootExtraction: return "";
            }

            return "";
        }

        /// <summary>
        /// To change an additional operation in the current expression
        /// </summary>
        /// <remarks>
        /// The changes are that the last set of additional operations is placed in the last clicked additional operation
        /// </remarks>
        /// <returns>
        /// Modified additional operation
        /// </returns>
        private static string ChangeTheSetOfRecentAdditionalOperations(string currentExpression, string selectedOperation)
        {
            StringBuilder stringBuilderCurExpr = new StringBuilder(currentExpression);
            char[] destination;
            int pos;
            int fragmentSize;
            string copiedFragment;

            //Search for the fragment size to replace
            //If the expression has at least one basic math operation
            if (currentExpression.IndexOf('+') != -1 || currentExpression.IndexOf('-') != -1 ||
                currentExpression.IndexOf('×') != -1 || currentExpression.IndexOf('÷') != -1)
            {
                for (int i = stringBuilderCurExpr.Length - 1; ; i--)
                {
                    if (stringBuilderCurExpr[i] == ' ')
                    {
                        pos = i + 1;
                        fragmentSize = stringBuilderCurExpr.Length - pos;
                        break;
                    }
                }
            }
            else
            {
                pos = 0;
                fragmentSize = stringBuilderCurExpr.Length - 1;
            }

            //Fragment replacement
            destination = new char[fragmentSize];
            stringBuilderCurExpr.CopyTo(pos, destination, 0, fragmentSize);
            copiedFragment = new string(destination);
            stringBuilderCurExpr.Remove(pos, fragmentSize);
            stringBuilderCurExpr.Insert(pos, selectedOperation + '(' + copiedFragment + ')');

            return stringBuilderCurExpr.ToString();
        }

        /// <summary>
        /// To change the sign of the last operation
        /// </summary>
        private static string ChangeOperation(string currentExpression, string selectedOperation)
        {
            if (!currentExpression.EndsWith(selectedOperation) && currentExpression != "")
            {
                return currentExpression.Remove(currentExpression.Length - 3, 3) + selectedOperation;
            }
            else
            {
                return currentExpression;
            }
        }

        /// <summary>
        /// To bring a number to a general form
        /// </summary>
        /// <returns>
        /// Standardized number
        /// </returns>
        private static string NumberStandardization(string currentNumber)
        {
            //
            if (currentNumber.IndexOf(',') != -1 && (currentNumber[currentNumber.Length - 1] == '0' || currentNumber[currentNumber.Length - 1] == ','))
            {
                currentNumber = ConvertingRealNumbers(currentNumber);
            }

            if (currentNumber[0] == '-')
            {
                currentNumber = NegatePutInParentheses(currentNumber);
            }

            return currentNumber;
        }

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
        private static string ConvertingRealNumbers(string currentNumber)
        {
            StringBuilder stringBuilderCurNo = new StringBuilder(currentNumber);

            while (stringBuilderCurNo.Length > 1 && (stringBuilderCurNo[stringBuilderCurNo.Length-1] == '0' || stringBuilderCurNo[stringBuilderCurNo.Length - 1] == ','))
            {
                stringBuilderCurNo.Remove(stringBuilderCurNo.Length - 1, 1);
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

        /// <summary>
        /// To put a negative number in parentheses
        /// </summary>
        private static string NegatePutInParentheses(string currentNumber)
        {
            return '(' + currentNumber + ')';
        }

        #endregion
    }
}