namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains information about currently pressed buttons and methods for changing
    /// </summary>
    class ButtonsState
    {
        #region Public properties

        /// <summary>
        /// To check whether the number pad button is pressed
        /// </summary>
        public bool NumberPadBtnPressed { get; private set; } = true;

        /// <summary>
        /// To check whether the additional operation button is pressed
        /// </summary>
        public bool AdditionalOperationBtnPressed { get; private set; } = false;

        /// <summary>
        /// To check whether the result calculation button is pressed
        /// </summary>
        public bool EqualBtnPressed { get; private set; } = false;

        #endregion

        #region Public methods

        /// <summary>
        /// To change the NumberPadBtnPressed value
        /// </summary>
        public void NumberPadBtnPressed_Change(bool newValue)
        {
            this.NumberPadBtnPressed = newValue;
        }

        /// <summary>
        /// To change the AdditionalOperationBtnPressed value
        /// </summary>
        public void AdditionalOperationBtnPressed_Change(bool newValue)
        {
            this.AdditionalOperationBtnPressed = newValue;
        }

        /// <summary>
        /// To change the EqualBtnPressed value
        /// </summary>
        public void EqualBtnPressed_Change(bool newValue)
        {
            this.EqualBtnPressed = newValue;
        }

        #endregion
    }
}