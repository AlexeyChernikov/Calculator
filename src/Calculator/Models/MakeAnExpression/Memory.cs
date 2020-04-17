namespace Calculator.Models.MakeAnExpression
{
    /// <summary>
    /// Contains methods for working with memory
    /// </summary>
    class Memory
    {
        #region Public properties

        /// <summary>
        /// To track if there is a stored number in memory
        /// </summary>
        public bool MemoryIsEmpty { get; private set; } = true;

        /// <summary>
        /// To store the current value/number in memory
        /// </summary>
        public double CurrentValue { get; private set; } = 0.0;

        #endregion

        #region Public methods

        /// <summary>
        /// To clear data stored in memory
        /// </summary>
        public void MemoryClear()
        {
            CurrentValue = 0.0;
            MemoryIsEmpty = true;
        }

        /// <summary>
        /// To addition the current number on the display to the current number stored in memory
        /// </summary>
        public void MemoryPlus(string currentNumber)
        {
            CurrentValue += double.Parse(currentNumber);
            MemoryIsEmpty = false;
        }

        /// <summary>
        /// To subtract the current number on the display to the current number stored in memory
        /// </summary>
        public void MemoryMinus(string currentNumber)
        {
            CurrentValue -= double.Parse(currentNumber);
            MemoryIsEmpty = false;
        }

        /// <summary>
        /// To save the current number on the display in memory
        /// </summary>
        public void MemorySave(string currentNumber)
        {
            CurrentValue = double.Parse(currentNumber);
            MemoryIsEmpty = false;
        }

        #endregion
    }
}