using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Calculator.Common;
using Calculator.ViewModels.Base;
using Calculator.Models.Calculation;
using Calculator.Models.MakeAnExpression;

namespace Calculator.ViewModels
{
    class StandardCalculatorViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// Structure containing data about pressed buttons
        /// </summary>
        private ButtonsState buttonsState;

        /// <summary>
        /// To calculate the current expression
        /// </summary>
        private Calculate calculate;

        /// <summary>
        /// Contains current entered number
        /// </summary>
        private string currentNumber = ((int)Digits.Zero).ToString();

        /// <summary>
        /// Contains current entered expression
        /// </summary>
        private string currentExpression = string.Empty;

        #endregion

        #region Public properties

        /// <summary>
        /// To show the current number on the display
        /// </summary>
        public string CurrentNumber
        {
            get
            {
                return currentNumber;
            }
            set
            {
                currentNumber = value;
                OnPropertyChanged(nameof(CurrentNumber));
            }
        }

        /// <summary>
        /// To show the current expression on the display
        /// </summary>
        public string CurrentExpression
        {
            get
            {
                return currentExpression;
            }
            set
            {
                currentExpression = value;
                OnPropertyChanged(nameof(CurrentExpression));
            }
        }

        #endregion

        #region Commands

        #region Commands for memory operations

        /// <summary>
        /// Clear numbers stored in memory
        /// </summary>
        public ICommand MemoryClearCommand { get; }

        /// <summary>
        /// Reading value from memory
        /// </summary>
        public ICommand MemoryReadCommand { get; }

        /// <summary>
        /// Adds the current number to the one stored in memory
        /// </summary>
        /// <remarks>
        /// The default value in memory is zero
        /// </remarks>
        public ICommand MemoryPlusCommand { get; }

        /// <summary>
        /// Subtracts the current number from the number stored in memory
        /// </summary>
        /// <remarks>
        /// The default value in memory is zero
        /// </remarks>
        public ICommand MemoryMinusCommand { get; }

        /// <summary>
        /// Saves the current number in memory for later use
        /// </summary>
        public ICommand MemorySaveCommand { get; }

        /// <summary>
        /// View numbers stored in memory
        /// </summary>
        public ICommand MemoryStorageCommand { get; }

        #endregion

        #region Commands for clearing data

        /// <summary>
        /// Clears all previously entered data
        /// </summary>
        /// <remarks>
        /// At the same time, the numbers recorded in the memory are stored
        /// </remarks>
        public ICommand ClearCommand { get; }

        /// <summary>
        /// Clears the current number
        /// </summary>
        public ICommand ClearEntryCommand { get; }

        /// <summary>
        /// Clears the last digit entered in the current number
        /// </summary>
        public ICommand BackspaceCommand { get; }

        #endregion

        #region Commands for additional operations

        /// <summary>
        /// Finds a percentage of the current expression and adds the found value to the expression
        /// </summary>
        public ICommand FindPercentageCommand { get; }

        /// <summary>
        /// Adds a "1/x" operation to the current expression
        /// </summary>
        /// <remarks>
        /// "x" - current number
        /// </remarks>
        public ICommand PartOfTheWholeCommand { get; }

        /// <summary>
        /// Adds a "x²" operation to the current expression
        /// </summary>
        /// <remarks>
        /// "x" - current number
        /// </remarks>
        public ICommand SqrCommand { get; }

        /// <summary>
        /// Adds a "√x" operation to the current expression
        /// </summary>
        /// <remarks>
        /// "x" - current number
        /// </remarks>
        public ICommand SqrtCommand { get; }

        #endregion

        #region Commands for basic math operations

        /// <summary>
        /// Adds an addition operation to the current expression
        /// </summary>
        public ICommand AdditionCommand { get; }

        /// <summary>
        /// Adds a subtraction operation to the current expression
        /// </summary>
        public ICommand SubtractionCommand { get; }

        /// <summary>
        /// Adds a multiplication operation to the current expression
        /// </summary>
        public ICommand MultiplyCommand { get; }

        /// <summary>
        /// Adds a division operation to the current expression
        /// </summary>
        public ICommand DivisionCommand { get; }

        /// <summary>
        /// Counts the value of the current expression
        /// </summary>
        public ICommand EqualCommand { get; }

        #endregion

        #region Number pad commands

        /// <summary>
        /// Adds digit 0 to the current number
        /// </summary>
        public ICommand DigitZeroCommand { get; }

        /// <summary>
        /// Adds digit 1 to the current number
        /// </summary>
        public ICommand DigitOneCommand { get; }

        /// <summary>
        /// Adds digit 2 to the current number
        /// </summary>
        public ICommand DigitTwoCommand { get; }

        /// <summary>
        /// Adds digit 3 to the current number
        /// </summary>
        public ICommand DigitThreeCommand { get; }

        /// <summary>
        /// Adds digit 4 to the current number
        /// </summary>
        public ICommand DigitFourCommand { get; }

        /// <summary>
        /// Adds digit 5 to the current number
        /// </summary>
        public ICommand DigitFiveCommand { get; }

        /// <summary>
        /// Adds digit 6 to the current number
        /// </summary>
        public ICommand DigitSixCommand { get; }

        /// <summary>
        /// Adds digit 7 to the current number
        /// </summary>
        public ICommand DigitSevenCommand { get; }

        /// <summary>
        /// Adds digit 8 to the current number
        /// </summary>
        public ICommand DigitEightCommand { get; }

        /// <summary>
        /// Adds digit 9 to the current number
        /// </summary>
        public ICommand DigitNineCommand { get; }

        /// <summary>
        /// Inverts a number from positive to negative and vice versa
        /// </summary>
        public ICommand InvertNumberCommand { get; }

        /// <summary>
        /// Adds a comma to the current number
        /// </summary>
        public ICommand CommaCommand { get; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardCalculatorViewModel()
        {
            #region Initialization

            buttonsState = new ButtonsState(true, false, false);
            calculate = new Calculate();

            #endregion

            #region Create commands

            #region Commands for memory operations
            /*
            MemoryClearCommand = ;
            MemoryReadCommand = ;
            MemoryPlusCommand = ;
            MemoryMinusCommand = ;
            MemorySaveCommand = ;
            MemoryStorageCommand = ;
            */
            #endregion

            #region Commands for clearing data

            ClearCommand = new RelayCommand(() =>
            {
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);
                CurrentExpression = ClearData.ClearExpression(CurrentExpression);

                buttonsState.NumberPadBtnPressed = true;
                buttonsState.AdditionalOperationBtnPressed = false;
                buttonsState.EqualBtnPressed = false;
            });

            ClearEntryCommand = new RelayCommand(() =>
            {
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = true;
            });

            BackspaceCommand = new RelayCommand(() => 
            {
                CurrentNumber = ClearData.Backspace(CurrentNumber);
            });

            #endregion

            #region Commands for additional operations

            FindPercentageCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.FindPercentage(CurrentNumber, CurrentExpression, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = true;
                buttonsState.AdditionalOperationBtnPressed = true;
            });

            PartOfTheWholeCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetAdditionalOperation(CurrentNumber, CurrentExpression, AdditionalOperations.PartOfTheWhole, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = true;
                buttonsState.AdditionalOperationBtnPressed = true;
            });

            SqrCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetAdditionalOperation(CurrentNumber, CurrentExpression, AdditionalOperations.Exponentiation, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = true;
                buttonsState.AdditionalOperationBtnPressed = true;
            });

            SqrtCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetAdditionalOperation(CurrentNumber, CurrentExpression, AdditionalOperations.RootExtraction, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = true;
                buttonsState.AdditionalOperationBtnPressed = true;
            });

            #endregion

            #region Commands for basic math operations

            AdditionCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetBasicMathOperation(CurrentNumber, CurrentExpression, BasicMathOperations.Addition, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = false;
                buttonsState.AdditionalOperationBtnPressed = false;
            });

            SubtractionCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetBasicMathOperation(CurrentNumber, CurrentExpression, BasicMathOperations.Subtraction, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = false;
                buttonsState.AdditionalOperationBtnPressed = false;
            });

            MultiplyCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetBasicMathOperation(CurrentNumber, CurrentExpression, BasicMathOperations.Multiplication, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = false;
                buttonsState.AdditionalOperationBtnPressed = false;
            });

            DivisionCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetBasicMathOperation(CurrentNumber, CurrentExpression, BasicMathOperations.Division, buttonsState);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                buttonsState.NumberPadBtnPressed = false;
                buttonsState.AdditionalOperationBtnPressed = false;
            });

            //возможно дописать отдельную функцию
            EqualCommand = new RelayCommand(() =>
            {
                CurrentExpression = CurrentExpressionFormation.SetBasicMathOperation(CurrentNumber, CurrentExpression, BasicMathOperations.Equal, buttonsState);
                CurrentNumber = calculate.Calc(CurrentExpression).ToString();

                buttonsState.NumberPadBtnPressed = false;
                buttonsState.AdditionalOperationBtnPressed = false;
                buttonsState.EqualBtnPressed = true;
            });

            #endregion

            #region Number pad commands

            DigitZeroCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Zero);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitOneCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.One);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitTwoCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Two);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitThreeCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Three);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitFourCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Four);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitFiveCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Five);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitSixCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Six);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitSevenCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Seven);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitEightCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Eight);
                buttonsState.NumberPadBtnPressed = true;
            });

            DigitNineCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.SetNumber(CurrentNumber, Digits.Nine);
                buttonsState.NumberPadBtnPressed = true;
            });

            InvertNumberCommand = new RelayCommand(() =>
            {
                CurrentNumber = CurrentNumberFormation.InvertNumber(CurrentNumber);
                buttonsState.NumberPadBtnPressed = true;
            });

            CommaCommand = new RelayParameterizedCommand((obj) =>
            {
                CurrentNumber = CurrentNumberFormation.PutAComma(CurrentNumber);
                buttonsState.NumberPadBtnPressed = true;
            }, (obj) => !buttonsState.EqualBtnPressed);

            #endregion

            #endregion
        }

        #endregion
    }
}