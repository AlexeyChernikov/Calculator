using Calculator.Common;

namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains methods for clearing data
    /// </summary>
    class ClearData
    {
        #region Private members

        private CurrentData currentData;
        private ButtonsState buttonsState;

        #endregion

        #region Public methods

        /// <summary>
        /// Clears all data
        /// </summary>
        /// <remarks>
        /// At the same time, the numbers recorded in the memory are stored
        /// </remarks>
        public void ClearAll()
        {
            currentData.CurrentNumber = ClearNumber(currentData.CurrentNumber);
            currentData.CurrentExpression = ClearExpression(currentData.CurrentExpression);
            buttonsState.NumberPadBtnPressed_Change(true);
            buttonsState.AdditionalOperationBtnPressed_Change(false);
            buttonsState.EqualBtnPressed_Change(false);
        }

        /// <summary>
        /// Clears the current number
        /// </summary>
        public void ClearEntry()
        {
            if (buttonsState.EqualBtnPressed)
            {
                ClearAll();
            }
            else if (buttonsState.AdditionalOperationBtnPressed && Common.MathSignCheck(currentData.CurrentExpression))
            {
                currentData.CurrentExpression = ClearLastAdditionalOperation(currentData.CurrentExpression);
                buttonsState.NumberPadBtnPressed_Change(true);
                buttonsState.AdditionalOperationBtnPressed_Change(false);
            }
            else
            {
                currentData.CurrentNumber = ClearNumber(currentData.CurrentNumber);
                buttonsState.NumberPadBtnPressed_Change(true);
            }
        }

        /// <summary>
        /// Clears the last digit entered in the current number
        /// </summary>
        public void Backspace()
        {
            if (buttonsState.EqualBtnPressed)
            {
                if (NumberStandardization.NumberCheck(currentData.CurrentNumber))
                {
                    currentData.CurrentExpression = ClearExpression(currentData.CurrentExpression);
                    buttonsState.NumberPadBtnPressed_Change(true);
                    buttonsState.AdditionalOperationBtnPressed_Change(false);
                    buttonsState.EqualBtnPressed_Change(false);
                }
                else
                {
                    ClearAll();
                }
            }
            else
            {
                currentData.CurrentNumber = Backspace(currentData.CurrentNumber);
            }
        }

        /// <summary>
        /// To clear the current number
        /// </summary>
        public string ClearNumber(string currentNumber)
        {
            return currentNumber != ((int)Digits.Zero).ToString() ? ((int)Digits.Zero).ToString() : currentNumber;
        }

        /// <summary>
        /// To clear the current expression
        /// </summary>
        public string ClearExpression(string currentExpression)
        {
            return currentExpression != string.Empty ? string.Empty : currentExpression;
        }

        /// <summary>
        /// To remove the last additional operation from the current expression
        /// </summary>
        public string ClearLastAdditionalOperation(string currentExpression)
        {
            int pos = 0;
            int fragmentSize = currentExpression.Length;

            //If the expression has at least one basic math operation
            if (Common.MathSignCheck(currentData.CurrentExpression))
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

            return currentExpression.Remove(pos, fragmentSize);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// To clear the last digit in the current number
        /// </summary>
        private string Backspace(string currentNumber)
        {
            int len = currentNumber.IndexOf('-') == -1 ? 1 : 2;

            return currentNumber.Length != len ? currentNumber.Remove(currentNumber.Length - 1) : ((int)Digits.Zero).ToString();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClearData(CurrentData currentData, ButtonsState buttonsState)
        {
            this.currentData = currentData;
            this.buttonsState = buttonsState;
        }

        #endregion
    }
}