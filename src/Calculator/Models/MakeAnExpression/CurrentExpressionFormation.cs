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
            //Both are pressed 
            //If the number and additional operation were pressed
            if (buttonsState.NumberPadBtnPressed && buttonsState.AdditionalOperationBtnPressed)
            {
                return currentExpression + SetSelectedBasicMathOperation(selectedOperation);
            }
            //Pressed and not pressed
            //If a number was pressed, but not an additional operation
            else if (buttonsState.NumberPadBtnPressed && !buttonsState.AdditionalOperationBtnPressed)
            {
                return currentExpression + NumberStandardization.Standardization(currentNumber) + SetSelectedBasicMathOperation(selectedOperation);
            }
            //Сhanging the operation sign
            else
            {
                return ChangeOperation(currentExpression, SetSelectedBasicMathOperation(selectedOperation));
            }
        }

        /// <summary>
        /// To add the selected operation applied to the current number in the current expression
        /// </summary>
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

        /// <summary>
        /// To find the percentage of the current expression
        /// </summary>
        public static string FindPercentage(string currentNumber, string currentExpression, ButtonsState buttonsState)
        {
            Calculate calculate = new Calculate();

            if (currentExpression != string.Empty)
            {
                if (buttonsState.AdditionalOperationBtnPressed)
                {
                    return ChangeTheSetOfRecentAdditionalOperations(currentExpression);
                }
                else
                {
                    return currentExpression + NumberStandardization.Standardization(calculate.CalcPercentage(NumberStandardization.Standardization(currentNumber), currentExpression.Remove(currentExpression.Length - 3, 3)).ToString());
                }
            }
            else
            {
                return currentExpression + NumberStandardization.Standardization(calculate.CalcPercentage(NumberStandardization.Standardization(currentNumber), ((int)Digits.Zero).ToString()).ToString());
            }
        }

        #endregion

        #region Private methods

        //Methods for symbolizing the selected operation
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

        //Methods for changing an operation
        /// <summary>
        /// To change the sign of the last operation
        /// </summary>
        private static string ChangeOperation(string currentExpression, string selectedOperation)
        {
            if (!currentExpression.EndsWith(selectedOperation))
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
        /// <para>For operations that have a symbolic notation in the expression</para>
        /// <para>The changes are that the last set of additional operations is placed in the last clicked additional operation</para>
        /// </remarks>
        /// <returns>
        /// Modified additional operation
        /// </returns>
        private static string ChangeTheSetOfRecentAdditionalOperations(string currentExpression, string selectedOperation)
        {
            int pos;
            string copiedFragment;
            StringBuilder stringBuilderCurExpr = CurrentExpressionChange(currentExpression, out pos, out copiedFragment);

            return stringBuilderCurExpr.Insert(pos, selectedOperation + '(' + copiedFragment + ')').ToString();
        }

        /// <summary>
        /// To find the percentage, if other additional operations are applied
        /// </summary>
        /// <remarks>
        /// <para>For operations that do not have a character notation in the expression</para>
        /// <para>In the case of the " % " operation, the change is that the last number or sequence of operations is replaced with a specific percentage of the rest of the expression</para>
        /// </remarks>
        /// <returns>
        /// The string of the current expression with the percentage found
        /// </returns>
        private static string ChangeTheSetOfRecentAdditionalOperations(string currentExpression)
        {
            int pos;
            string copiedFragment;
            StringBuilder stringBuilderCurExpr = CurrentExpressionChange(currentExpression, out pos, out copiedFragment);
            Calculate calculate = new Calculate();

            if (MathSignCheck(currentExpression))
            {
                stringBuilderCurExpr.Insert(pos, calculate.CalcPercentage(copiedFragment, stringBuilderCurExpr.ToString().Remove(stringBuilderCurExpr.Length - 3, 3)));
            }
            else
            {
                stringBuilderCurExpr.Insert(pos, calculate.CalcPercentage(copiedFragment, stringBuilderCurExpr.ToString()));
            }

            return stringBuilderCurExpr.ToString();
        }

        //Additional methods
        /// <summary>
        /// To remove the last number or sequence of additional operations for subsequent replacement
        /// </summary>
        /// <returns>
        /// Returns the modified current expression, as well as the copied fragment and position for reuse
        /// </returns>
        private static StringBuilder CurrentExpressionChange(string currentExpression, out int pos, out string copiedFragment)
        {
            StringBuilder stringBuilderCurExpr = new StringBuilder(currentExpression);
            char[] destination;
            int fragmentSize;

            //Search for the fragment size to replace
            //If the expression has at least one basic math operation
            if (MathSignCheck(currentExpression))
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
                fragmentSize = stringBuilderCurExpr.Length;
            }

            //Remove an old fragment
            destination = new char[fragmentSize];
            stringBuilderCurExpr.CopyTo(pos, destination, 0, fragmentSize);
            copiedFragment = new string(destination);
            stringBuilderCurExpr.Remove(pos, fragmentSize);

            return stringBuilderCurExpr;
        }

        /// <summary>
        /// To search for any basic mathematical operation in the current expression
        /// </summary>
        /// <returns>
        /// Returns "true" if a mathematical sign is found
        /// </returns>
        private static bool MathSignCheck(string currentExpression)
        {
            return 
                currentExpression.IndexOf('+') != -1 || currentExpression.IndexOf('-') != -1 ||
                currentExpression.IndexOf('×') != -1 || currentExpression.IndexOf('÷') != -1 ? true : false;
        }
        #endregion
    }
}