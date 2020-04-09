namespace Calculator.Common
{
    /// <summary>
    /// Contains common data and methods
    /// </summary>
    static class CommonData
    {
        #region Public properties

        /// <summary>
        /// Default value for string with the current number
        /// </summary>
        public static string DefCurNumStr { get; } = ((int)Digits.Zero).ToString();

        /// <summary>
        /// Default value for string with the current expression
        /// </summary>
        public static string DefCurExprStr { get; } = string.Empty;

        #endregion
    }
}