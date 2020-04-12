using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Common;
using Calculator.Models.Calculation;
using Calculator.Models.MakeAnExpression;

namespace Calculator.Models
{
    /// <summary>
    /// Contains logic for the calculator
    /// </summary>
    class CalculatorLogic
    {
        #region Private members

        /// <summary>
        /// Structure containing data about pressed buttons
        /// </summary>
        private ButtonsState buttonsState = new ButtonsState(true, false, false);

        /// <summary>
        /// To calculate the current expression
        /// </summary>
        private Calculate calculate = new Calculate();

        #endregion

        #region Public properties

        /// <summary>
        /// Contains current entered number
        /// </summary>
        public string CurrentNumber { get; private set; } = ((int)Digits.Zero).ToString();

        /// <summary>
        /// Contains current entered expression
        /// </summary>
        public string CurrentExpression { get; private set; } = string.Empty;

        #endregion

        #region Public methods

        #region Clear entered data

        /// <summary>
        /// Clears all entered data
        /// </summary>
        /// <remarks>
        /// At the same time, the numbers recorded in the memory are stored
        /// </remarks>
        public void ClearAll()
        {
            CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            CurrentExpression = ClearData.ClearExpression(CurrentExpression);
            buttonsState.NumberPadBtnPressed = true;
            buttonsState.AdditionalOperationBtnPressed = false;
            buttonsState.EqualBtnPressed = false;
        }

        /// <summary>
        /// Clears the current number
        /// </summary>
        public void ClearEntry()
        {
            CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            buttonsState.NumberPadBtnPressed = true;
        }

        /// <summary>
        /// Clears the last digit entered in the current number
        /// </summary>
        public void Backspace()
        {
            CurrentNumber = ClearData.Backspace(CurrentNumber);
        }

        #endregion

        #region Formation of the current expression

        /// <summary>
        /// The logic of the program when you click on the main math operation
        /// </summary>
        public void SetBasicMathOperation(BasicMathOperations pressedOperation)
        {
            CurrentExpression = CurrentExpressionFormation.SetBasicMathOperation(CurrentNumber, CurrentExpression, pressedOperation, buttonsState);
            CurrentNumber = pressedOperation == BasicMathOperations.Equal ? calculate.Calc(CurrentExpression).ToString() : ClearData.ClearNumber(CurrentNumber);

            if (pressedOperation == BasicMathOperations.Equal)
            {
                buttonsState.EqualBtnPressed = true;
            }

            buttonsState.NumberPadBtnPressed = false;
            buttonsState.AdditionalOperationBtnPressed = false;
        }

        /// <summary>
        /// The logic of the program when you click on an additional operation
        /// </summary>
        public void SetAdditionalOperation(AdditionalOperations pressedOperation)
        {
            CurrentExpression = CurrentExpressionFormation.SetAdditionalOperation(CurrentNumber, CurrentExpression, pressedOperation, buttonsState);
            CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            buttonsState.NumberPadBtnPressed = true;
            buttonsState.AdditionalOperationBtnPressed = true;
        }

        /// <summary>
        /// The logic of the program when calculating the percentage of the current expression
        /// </summary>
        public void FindPercentage()
        {
            CurrentExpression = CurrentExpressionFormation.FindPercentage(CurrentNumber, CurrentExpression, buttonsState);
            CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            buttonsState.NumberPadBtnPressed = true;
            buttonsState.AdditionalOperationBtnPressed = true;
        }

        #endregion

        #region Formation of the current number

        /// <summary>
        /// The logic of the program when you click on a digit
        /// </summary>
        public string SetNumber(Digits pressedDigit)
        {
            CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, pressedDigit);
            buttonsState.NumberPadBtnPressed = true;

            return CurrentNumber;
        }

        /// <summary>
        /// Logic of the program when inverting the current number
        /// </summary>
        public string InvertNumber()
        {
            CurrentNumber = CurrentNumberFormation.InvertNumber(CurrentNumber);
            buttonsState.NumberPadBtnPressed = true;

            return CurrentNumber;
        }

        /// <summary>
        /// Logic of the program when you click on a comma
        /// </summary>
        public string PutAComma()
        {
            CurrentNumber = CurrentNumberFormation.PutAComma(CurrentNumber);
            buttonsState.NumberPadBtnPressed = true;

            return CurrentNumber;
        }

        #endregion

        #endregion
    }
}