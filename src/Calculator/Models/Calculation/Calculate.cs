using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models.Calculation
{
    /// <summary>
    /// To calculate the current expression
    /// </summary>
    class Calculate
    {
        #region Private members

        /// <summary>
        /// String of the current expression
        /// </summary>
        private string currentExpression;

        /// <summary>
        /// Current position in the expression
        /// </summary>
        private int pos;

        #endregion

        #region Private methods



        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Calculate(string currentExpression)
        {
            this.currentExpression = currentExpression;
        }

        #endregion
    }
}