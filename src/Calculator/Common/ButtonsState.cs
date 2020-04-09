namespace Calculator.Common
{
    /// <summary>
    /// Contains data for the program. Lets you track which buttons were pressed
    /// </summary>
    struct ButtonsState
    {
        #region Public properties

        /// <summary>
        /// To check whether the number pad button is pressed
        /// </summary>
        public bool NumberPadBtnPressed { get; set; }

        /// <summary>
        /// To check whether the additional operation button is pressed
        /// </summary>
        public bool AdditionalOperationBtnPressed { get; set; }

        /// <summary>
        /// To check whether the result calculation button is pressed
        /// </summary>
        public bool EqualBtnPressed { get; set; }

        #endregion

        #region Constructor

        public ButtonsState(bool numberPadBtnPressed = true, bool additionalOperationBtnPressed = false, bool equalBtnPressed = false)
        {
            NumberPadBtnPressed = numberPadBtnPressed;
            AdditionalOperationBtnPressed = additionalOperationBtnPressed;
            EqualBtnPressed = equalBtnPressed;
        }

        #endregion
    }
}