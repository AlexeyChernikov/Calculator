using System.Text;
using Calculator.Common;
using Calculator.Models.Calculation;

namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains methods for forming the current expression
    /// </summary>
    class CurrentExpressionFormation
    {
        #region Private members

        private CurrentData currentData;
        private ButtonsState buttonsState;
        private ClearData clearData;
        private Calculate calculate;

        #endregion

        #region Public methods

        /// <summary>
        /// To add the current number and the selected operation to the current expression
        /// </summary>
        public void SetBasicMathOperation(BasicMathOperations pressedOperation)
        {
            if (buttonsState.EqualBtnPressed && (pressedOperation != BasicMathOperations.Equal))
            {
                currentData.CurrentExpression = clearData.ClearExpression(currentData.CurrentExpression);
                buttonsState.NumberPadBtnPressed_Change(true);
                buttonsState.AdditionalOperationBtnPressed_Change(false);
                buttonsState.EqualBtnPressed_Change(false);
            }

            //When you click "=" again
            if (buttonsState.EqualBtnPressed && (pressedOperation == BasicMathOperations.Equal) && MathSignCheck(currentData.CurrentExpression))
            {
                currentData.CurrentExpression = NumberStandardization.Standardization(currentData.CurrentNumber) + CopyLastOperation(currentData.CurrentExpression.Remove(currentData.CurrentExpression.Length - 3, 3)) + SetSelectedBasicMathOperation(pressedOperation);
            }
            //Both are pressed 
            //If the number and additional operation were pressed
            else if (buttonsState.NumberPadBtnPressed && buttonsState.AdditionalOperationBtnPressed)
            {
                currentData.CurrentExpression = currentData.CurrentExpression + SetSelectedBasicMathOperation(pressedOperation);
            }
            //Pressed and not pressed
            //If a number was pressed, but not an additional operation
            else if (buttonsState.NumberPadBtnPressed && !buttonsState.AdditionalOperationBtnPressed)
            {
                currentData.CurrentExpression = currentData.CurrentExpression + NumberStandardization.Standardization(currentData.CurrentNumber) + SetSelectedBasicMathOperation(pressedOperation);
            }
            //Сhanging the operation sign
            else
            {
                currentData.CurrentExpression = ChangeOperation(currentData.CurrentExpression, SetSelectedBasicMathOperation(pressedOperation));
            }

            currentData.CurrentNumber = pressedOperation == BasicMathOperations.Equal ? calculate.Calc(currentData.CurrentExpression).ToString() : clearData.ClearNumber(currentData.CurrentNumber);

            if (pressedOperation == BasicMathOperations.Equal)
            {
                buttonsState.EqualBtnPressed_Change(true);
            }

            buttonsState.NumberPadBtnPressed_Change(false);
            buttonsState.AdditionalOperationBtnPressed_Change(false);
        }

        /// <summary>
        /// To add the selected operation applied to the current number in the current expression
        /// </summary>
        public void SetAdditionalOperation(AdditionalOperations pressedOperation)
        {
            if (buttonsState.EqualBtnPressed)
            {
                currentData.CurrentExpression = clearData.ClearExpression(currentData.CurrentExpression);
                buttonsState.NumberPadBtnPressed_Change(true);
                buttonsState.AdditionalOperationBtnPressed_Change(false);
                buttonsState.EqualBtnPressed_Change(false);
            }

            //If an additional operation is not used for the first time
            if (buttonsState.AdditionalOperationBtnPressed)
            {
                currentData.CurrentExpression = ChangeTheSetOfRecentAdditionalOperations(currentData.CurrentExpression, SetSelectedAdditionalOperation(pressedOperation));
            }
            else
            {
                currentData.CurrentExpression = currentData.CurrentExpression + SetSelectedAdditionalOperation(pressedOperation) + '(' + NumberStandardization.Standardization(currentData.CurrentNumber) + ')';
            }

            currentData.CurrentNumber = clearData.ClearNumber(currentData.CurrentNumber);
            buttonsState.NumberPadBtnPressed_Change(true);
            buttonsState.AdditionalOperationBtnPressed_Change(true);
        }

        /// <summary>
        /// To find the percentage of the current expression
        /// </summary>
        public void FindPercentage()
        {
            if (buttonsState.EqualBtnPressed)
            {
                currentData.CurrentExpression = NumberStandardization.Standardization(calculate.CalcPercentage(NumberStandardization.Standardization(currentData.CurrentNumber), currentData.CurrentExpression.Remove(currentData.CurrentExpression.Length - 3, 3)).ToString());
                buttonsState.NumberPadBtnPressed_Change(true);
                buttonsState.AdditionalOperationBtnPressed_Change(false);
                buttonsState.EqualBtnPressed_Change(false);
            }
            else
            {
                if (currentData.CurrentExpression != string.Empty)
                {
                    if (buttonsState.AdditionalOperationBtnPressed)
                    {
                        currentData.CurrentExpression = ChangeTheSetOfRecentAdditionalOperations(currentData.CurrentExpression);
                    }
                    else
                    {
                        currentData.CurrentExpression = currentData.CurrentExpression + NumberStandardization.Standardization(calculate.CalcPercentage(NumberStandardization.Standardization(currentData.CurrentNumber), currentData.CurrentExpression.Remove(currentData.CurrentExpression.Length - 3, 3)).ToString());
                    }
                }
                else
                {
                    currentData.CurrentExpression = currentData.CurrentExpression + NumberStandardization.Standardization(calculate.CalcPercentage(NumberStandardization.Standardization(currentData.CurrentNumber), ((int)Digits.Zero).ToString()).ToString());
                }
            }

            currentData.CurrentNumber = clearData.ClearNumber(currentData.CurrentNumber);
            buttonsState.NumberPadBtnPressed_Change(true);
            buttonsState.AdditionalOperationBtnPressed_Change(true);
        }

        /// <summary>
        /// Удаляет последнюю дополнительную операцию если нажата цифра или CE
        /// Для CE логика ещё не написана
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public string CurrentExpressionChange(string currentExpression)
        {
            int fragmentSize;
            int pos;

            //Search for the fragment size to replace
            //If the expression has at least one basic math operation
            if (MathSignCheck(currentExpression))
            {
                for (int i = currentExpression.Length - 1; ; i--)
                {
                    if (currentExpression[i] == ' ')
                    {
                        pos = i + 1;
                        fragmentSize = currentExpression.Length - pos;
                        break;
                    }
                }
            }
            else
            {
                pos = 0;
                fragmentSize = currentExpression.Length;
            }

            return currentExpression.Remove(pos, fragmentSize);
        }

        #endregion

        #region Private methods

        #region Methods for symbolizing the selected operation

        /// <summary>
        /// To set the symbolic representation of a basic math operation
        /// </summary>
        /// <returns>
        /// A string representing the selected operation
        /// </returns>
        private string SetSelectedBasicMathOperation(BasicMathOperations pressedOperation)
        {
            switch (pressedOperation)
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
        private string SetSelectedAdditionalOperation(AdditionalOperations pressedOperation)
        {
            switch (pressedOperation)
            {
                case AdditionalOperations.PartOfTheWhole: return "1/";
                case AdditionalOperations.Exponentiation: return "Sqr";
                case AdditionalOperations.RootExtraction: return "√";
            }

            return "Operation not found";
        }

        #endregion

        #region Methods for changing an operation

        /// <summary>
        /// To change the sign of the last operation
        /// </summary>
        private string ChangeOperation(string currentExpression, string pressedOperation)
        {
            if (!currentExpression.EndsWith(pressedOperation))
            {
                return currentExpression.Remove(currentExpression.Length - 3, 3) + pressedOperation;
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
        private string ChangeTheSetOfRecentAdditionalOperations(string currentExpression, string pressedOperation)
        {
            int pos;
            string copiedFragment;
            StringBuilder stringBuilderCurExpr = CurrentExpressionChange(currentExpression, out pos, out copiedFragment);

            return stringBuilderCurExpr.Insert(pos, pressedOperation + '(' + copiedFragment + ')').ToString();
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
        private string ChangeTheSetOfRecentAdditionalOperations(string currentExpression)
        {
            int pos;
            string copiedFragment;
            StringBuilder stringBuilderCurExpr = CurrentExpressionChange(currentExpression, out pos, out copiedFragment);
            Calculate calculate = new Calculate();
            double number;

            if (MathSignCheck(currentExpression))
            {
                number = calculate.CalcPercentage(copiedFragment, stringBuilderCurExpr.ToString().Remove(stringBuilderCurExpr.Length - 3, 3));
            }
            else
            {
                number = calculate.CalcPercentage(copiedFragment, stringBuilderCurExpr.ToString());
            }

            if (NumberStandardization.NumberCheck(number.ToString()))
            {
                stringBuilderCurExpr.Insert(pos, number.ToString());
            }
            else
            {
                stringBuilderCurExpr.Insert(pos, ((int)Digits.Zero).ToString());
            }

            return stringBuilderCurExpr.ToString();
        }

        /// <summary>
        /// To copy the last operation for recount
        /// </summary>
        /// <returns>
        /// Returns the copied fragment
        /// </returns>
        private string CopyLastOperation(string currentExpression)
        {
            int pos = 0;
            char[] destination;
            int fragmentSize = currentExpression.Length;
            int spaceCounter = 0;

            //Search for the fragment size to copy
            //If the expression has at least one basic math operation
            if (MathSignCheck(currentExpression))
            {
                for (int i = currentExpression.Length - 1; ; i--)
                {
                    if (currentExpression[i] == ' ')
                    {
                        spaceCounter++;

                        if (spaceCounter == 2)
                        {
                            pos = i;
                            fragmentSize = currentExpression.Length - pos;
                            break;
                        }
                    }
                }
            }

            //Copy the required fragment
            destination = new char[fragmentSize];
            currentExpression.CopyTo(pos, destination, 0, fragmentSize);

            return new string(destination);
        }

        #endregion

        #region Additional methods

        /// <summary>
        /// To remove the last number or sequence of additional operations for subsequent replacement
        /// </summary>
        /// <returns>
        /// Returns the modified current expression, as well as the copied fragment and position for reuse
        /// </returns>
        private StringBuilder CurrentExpressionChange(string currentExpression, out int pos, out string copiedFragment)
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
        private bool MathSignCheck(string currentExpression)
        {
            return 
                currentExpression.IndexOf('+') != -1 || currentExpression.IndexOf('-') != -1 ||
                currentExpression.IndexOf('×') != -1 || currentExpression.IndexOf('÷') != -1 ? true : false;
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CurrentExpressionFormation(CurrentData currentData, ButtonsState buttonsState)
        {
            this.currentData = currentData;
            this.buttonsState = buttonsState;
            calculate = new Calculate();
            clearData = new ClearData(currentData, buttonsState);
        }

        #endregion
    }
}