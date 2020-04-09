using System.Text;
using Calculator.Common;
using Calculator.Models.Calculation;

namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Logic for forming the current expression
    /// </summary>
    static class CurrentExpressionFormation
    {
        #region Public methods

        /// <summary>
        /// To add the current number and the selected operation to the current expression
        /// </summary>
        public static string SetBasicMathOperation(string currentNumber, string currentExpression, BasicMathOperations selectedOperation, ButtonsState buttonsState)
        {
            //обе нажаты
            //если была нажата цифра и дополнительная операция
            if (buttonsState.NumberPadBtnPressed && buttonsState.AdditionalOperationBtnPressed)
            {
                return currentExpression + SetSelectedBasicMathOperation(selectedOperation);
            }
            //нажата и не нажата
            //если была нажата цифра, но не дополнительная операция
            else if (buttonsState.NumberPadBtnPressed && !buttonsState.AdditionalOperationBtnPressed)
            {
                return currentExpression + NumberStandardization.Standardization(currentNumber) + SetSelectedBasicMathOperation(selectedOperation);
            }
            //смена знака
            else
            {
                return ChangeOperation(currentExpression, SetSelectedBasicMathOperation(selectedOperation));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static string SetAdditionalOperation(string currentNumber, string currentExpression, AdditionalOperations selectedOperation, ButtonsState buttonsState)
        {
            //If an additional operation is not used for the first time
            if (buttonsState.AdditionalOperationBtnPressed)
            {
                return ChangeTheSetOfRecentAdditionalOperations(currentExpression, SetSelectedAdditionalOperation(selectedOperation));
            }
            else
            {
                return currentExpression + SetSelectedAdditionalOperation(selectedOperation) + '(' + NumberStandardization.Standardization(currentNumber) + ')';
            }
        }

        //смотри issue #17
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static string FindPercentage(string currentNumber, string currentExpression, ButtonsState buttonsState)
        {
            Calculate calculate = new Calculate();

            if (currentExpression != "")
            {
                if (buttonsState.AdditionalOperationBtnPressed)
                {
                    return ChangePercentage(currentNumber, currentExpression);
                }
                else
                {
                    return currentExpression + NumberStandardization.Standardization(calculate.CalcPercentage(NumberStandardization.Standardization(currentNumber), currentExpression.Remove(currentExpression.Length - 3, 3)).ToString());
                }
            }
            else
            {
                return currentExpression + NumberStandardization.Standardization(calculate.CalcPercentage(NumberStandardization.Standardization(currentNumber), "0").ToString());
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// To set the symbolic representation of a basic math operation
        /// </summary>
        /// <returns>
        /// A string representing the selected operation
        /// </returns>
        private static string SetSelectedBasicMathOperation(BasicMathOperations selectedOperation)
        {
            switch (selectedOperation)
            {
                case BasicMathOperations.Addition: return " + ";
                case BasicMathOperations.Subtraction: return " - ";
                case BasicMathOperations.Multiplication: return " × ";
                case BasicMathOperations.Division: return " ÷ ";
                case BasicMathOperations.Equal: return " = ";
            }

            return "Operation not found";
        }

        /// <summary>
        /// To set the symbolic representation of an additional operation
        /// </summary>
        /// <returns>
        /// A string representing the selected operation
        /// </returns>
        private static string SetSelectedAdditionalOperation(AdditionalOperations selectedOperation)
        {
            switch (selectedOperation)
            {
                case AdditionalOperations.PartOfTheWhole: return "1/";
                case AdditionalOperations.Exponentiation: return "Sqr";
                case AdditionalOperations.RootExtraction: return "√";
            }

            return "Operation not found";
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
        /// Если процент вычисляется с применением какой-либо дополнительной операцией
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        private static string ChangePercentage(string currentNumber, string currentExpression)
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

            Calculate calculate = new Calculate();

            stringBuilderCurExpr.Insert(pos, calculate.CalcPercentage(copiedFragment, stringBuilderCurExpr.ToString().Remove(stringBuilderCurExpr.Length - 3, 3)));

            return stringBuilderCurExpr.ToString();
        }

        #endregion
    }
}