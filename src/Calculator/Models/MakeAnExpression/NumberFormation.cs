using Calculator.Common;

namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains methods for forming the current number
    /// </summary>
    class NumberFormation
    {
        #region Private members

        private CurrentData currentData;
        private ButtonsState buttonsState;
        private ClearData clearData;

        /// <summary>
        /// The maximum size of the current number
        /// </summary>
        private readonly int currentNumberMaxSize = 16;

        #endregion

        #region Public methods

        /// <summary>
        /// To add the pressed digit to the current number
        /// </summary>
        public void AddDigit(Digits pressedDigit)
        {
            EqualBtnPressed_Check();
            AdditionalOperationBtnPressed_Check();

            if (CurrentNumberSizeCheck(currentData.CurrentNumber))
            {
                currentData.CurrentNumber = currentData.CurrentNumber != ((int)Digits.Zero).ToString() ? (currentData.CurrentNumber + (int)pressedDigit) : ((int)pressedDigit).ToString();
            }

            buttonsState.NumberPadBtnPressed_Change(true);
        }

        /// <summary>
        /// To add or remove a minus in the current number
        /// </summary>
        public void InvertNumber()
        {
            EqualBtnPressed_Check();
            AdditionalOperationBtnPressed_Check();

            if (currentData.CurrentNumber != ((int)Digits.Zero).ToString())
            {
                currentData.CurrentNumber = currentData.CurrentNumber.IndexOf('-') == -1 ? currentData.CurrentNumber.Insert(0, "-") : currentData.CurrentNumber.Remove(0, 1);
            }

            buttonsState.NumberPadBtnPressed_Change(true);
        }

        /// <summary>
        /// To add a comma to the current number
        /// </summary>
        public void AddComma()
        {
            EqualBtnPressed_Check();
            AdditionalOperationBtnPressed_Check();

            currentData.CurrentNumber = currentData.CurrentNumber.IndexOf(',') == -1 ? currentData.CurrentNumber + ',' : currentData.CurrentNumber;
            buttonsState.NumberPadBtnPressed_Change(true);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// To check the size of the current number
        /// </summary>
        private bool CurrentNumberSizeCheck(string currentNumber)
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

        /// <summary>
        /// To check if the "Additional operation" button has been pressed
        /// </summary>
        /// <remarks>If "true", clears last additional operation</remarks>
        private void AdditionalOperationBtnPressed_Check()
        {
            if (buttonsState.AdditionalOperationBtnPressed)
            {
                currentData.CurrentExpression = clearData.ClearLastAdditionalOperation(currentData.CurrentExpression);
                buttonsState.AdditionalOperationBtnPressed_Change(false);
            }
        }

        /// <summary>
        /// To check if the "=" button has been pressed
        /// </summary>
        /// <remarks>If "true", clears all data</remarks>
        private void EqualBtnPressed_Check()
        {
            //If calculations have already been completed
            if (buttonsState.EqualBtnPressed)
            {
                clearData.ClearAll();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NumberFormation(CurrentData currentData, ButtonsState buttonsState, ClearData clearData)
        {
            this.currentData = currentData;
            this.buttonsState = buttonsState;
            this.clearData = clearData;
        }

        #endregion
    }
}