using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models.ComposingAnExpression
{
    /// <summary>
    /// To clear the entered data
    /// </summary>
    static class ClearData
    {
        /// <summary>
        /// To clear the current number
        /// </summary>
        public static string ClearNumber(string currentNumber)
        {
            return currentNumber != "0" ? "0" : currentNumber;
        }

        /// <summary>
        /// To clear the current expression
        /// </summary>
        public static string ClearExpression(string currentExpression)
        {
            return currentExpression != "" ? "" : currentExpression;
        }

        /// <summary>
        /// To clear the last number in the current number
        /// </summary>
        public static string Backspace(string currentNumber)
        {
            //If the current number is non negative
            if (currentNumber[0] != '-')
            {
                if (currentNumber.Length != 1)
                {
                    return currentNumber.Remove(currentNumber.Length - 1);
                }
            }
            else
            {
                if (currentNumber.Length != 2)
                {
                    return currentNumber.Remove(currentNumber.Length - 1);
                }
            }

            return "0";
        }
    }
}