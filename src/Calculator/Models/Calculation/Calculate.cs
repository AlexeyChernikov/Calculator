using System;
using Calculator.Models.Calculation.Operations.Base;
using Calculator.Models.Calculation.Operations.ArithmeticOperations;

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

        #region Public method

        /// <summary>
        /// To calculate the value of a specified expression
        /// </summary>
        /// <returns>
        /// Expression calculation result
        /// </returns>
        public double Calc(string currentExpression)
        {
            UniversalOperation result;
            this.currentExpression = currentExpression;
            pos = 0;

            result = ParsingAnExpression_LowPriority();

            return result.Operation();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// <para>
        /// To determine the sequence of actions: execution priority is low
        /// </para>
        /// <para>
        /// Low priority operations: addition, subtraction
        /// </para>
        /// </summary>
        private UniversalOperation ParsingAnExpression_LowPriority()
        {
            UniversalOperation result = ParsingAnExpression_MediumPriority();

            while (true)
            {
                if (MatchSearch('+'))
                {
                    result = new Addition(result, ParsingAnExpression_MediumPriority());
                }
                else if (MatchSearch('-'))
                {
                    result = new Subtraction(result, ParsingAnExpression_MediumPriority());
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// <para>
        /// To determine the sequence of actions: execution priority is medium
        /// </para>
        /// <para>
        /// Medium priority operations: multiplication, division
        /// </para>
        /// </summary>
        private UniversalOperation ParsingAnExpression_MediumPriority()
        {
            UniversalOperation result = ParsingAnExpression_HighPriority();

            while (true)
            {
                if (MatchSearch('×'))
                {
                    result = new Multiplication(result, ParsingAnExpression_HighPriority());
                }
                else if (MatchSearch('÷'))
                {
                    result = new Division(result, ParsingAnExpression_HighPriority());
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// <para>
        /// To determine the sequence of actions: execution priority is high
        /// </para>
        /// <para>
        /// High priority operations: negation, parentheses, number
        /// </para>
        /// </summary>
        private UniversalOperation ParsingAnExpression_HighPriority()
        {
            UniversalOperation result;

            if (MatchSearch('-'))
            {
                result = new Negation(ParsingAnExpression_LowPriority());
            }
            else if (MatchSearch('('))
            {
                result = ParsingAnExpression_LowPriority();

                if (!MatchSearch(')'))
                {
                    Console.WriteLine("Missing ')'");
                }
            }
            else
            {
                //Parsing numbers
                double val = 0.0;
                int startPosition = pos;

                //Find out the size of the number to parse
                while (pos < currentExpression.Length && (char.IsDigit(currentExpression[pos]) || currentExpression[pos] == ','))
                {
                    pos++;
                }

                //Attempt to parse a number
                try
                {
                    val = double.Parse(currentExpression.Substring(startPosition, pos - startPosition));
                }
                catch (Exception e)
                {
                    Console.WriteLine("The number is not parsed...");
                    Console.WriteLine(e);
                }

                result = new Number(val);
            }

            return result;
        }

        /// <summary>
        /// To search for a specified character in a string
        /// </summary>
        private bool MatchSearch(char ch)
        {
            if (pos >= currentExpression.Length)
            {
                return false;
            }

            //Skip spaces
            while (currentExpression[pos] == ' ')
            {
                pos++;
            }

            if (currentExpression[pos] == ch)
            {
                pos++;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}