using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models.FormingAnExpression
{
    /// <summary>
    /// 
    /// </summary>
    static class BasicMathOperationsLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentExpression"></param>
        /// <param name="currentNumber"></param>
        /// <param name="selectedOperation"></param>
        /// <param name="press"></param>
        /// <returns>
        /// 
        /// </returns>
        public static string SetOperation(string currentExpression, string currentNumber, string selectedOperation, ref bool press)
        {
            if (press)
            {
                press = false;
                return NegateCheck(currentNumber) ? (currentExpression + '(' + currentNumber + ')' + selectedOperation) : (currentExpression + currentNumber + selectedOperation);
            }

            press = false;
            return !currentExpression.EndsWith(selectedOperation) && currentExpression != "" ? (currentExpression.Remove(currentExpression.Length - 3, 3) + selectedOperation) : currentExpression;
        }

        /// <summary>
        /// To check if a current number is negative
        /// </summary>
        private static bool NegateCheck(string currentNumber)
        {
            return currentNumber[0] == '-' ? true : false;
        }
    }
}
