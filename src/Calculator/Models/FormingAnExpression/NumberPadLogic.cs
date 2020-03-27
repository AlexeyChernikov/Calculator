using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Models.FormingAnExpression
{
    static class NumberPadLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static string SetNumber(string currentNumber, char pressedNumber, out bool whichBtnIsPressed)
        {
            whichBtnIsPressed = true;
            return currentNumber != "0" ? (currentNumber + pressedNumber) : pressedNumber.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string InvertNumber(string currentNumber)
        {
            return currentNumber != "0" ? (currentNumber.IndexOf('-') == -1 ? currentNumber.Insert(0, "-") : currentNumber.Remove(0, 1)) : currentNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static string PutAComma(string currentNumber, out bool whichBtnIsPressed)
        {
            whichBtnIsPressed = true;
            return currentNumber.IndexOf(',') == -1 ? currentNumber + ',' : currentNumber;
        }
    }
}