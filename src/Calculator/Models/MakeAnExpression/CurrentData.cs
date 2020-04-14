using Calculator.Common;

namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains information about current data: number and expression
    /// </summary>
    class CurrentData
    {
        #region Public properties

        /// <summary>
        /// Contains current entered number
        /// </summary>
        public string CurrentNumber { get; set; } = ((int)Digits.Zero).ToString();

        /// <summary>
        /// Contains current entered expression
        /// </summary>
        public string CurrentExpression { get; set; } = string.Empty;

        #endregion
    }
}