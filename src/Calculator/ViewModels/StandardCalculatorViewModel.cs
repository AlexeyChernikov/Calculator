﻿using System.Windows.Input;
using Calculator.Common;
using Calculator.Models.MakeAnExpression;
using Calculator.ViewModels.Base;

namespace Calculator.ViewModels
{
    class StandardCalculatorViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// To track the values ​​of the current number and current expression
        /// </summary>
        private CurrentData currentData;

        /// <summary>
        /// To track the status of buttons
        /// </summary>
        private ButtonsState buttonsState;

        /// <summary>
        /// To access methods for clearing data
        /// </summary>
        private ClearData clearData;

        /// <summary>
        /// To access methods for formation the current number
        /// </summary>
        private CurrentNumberFormation currentNumberFormation;

        /// <summary>
        /// To access methods for formation the current expression
        /// </summary>
        private CurrentExpressionFormation currentExpressionFormation;

        #endregion

        #region Public properties

        /// <summary>
        /// To show the current number on the display
        /// </summary>
        public string CurrentNumber
        {
            get
            {
                return currentData.CurrentNumber;
            }
            set
            {
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
                return currentData.CurrentExpression;
            }
            set
            {
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

        #region Private methods

        /// <summary>
        /// To update main properties the current number and current expression
        /// </summary>
        private void UpdateMainProperties()
        {
            CurrentNumber = currentData.CurrentNumber;
            CurrentExpression = currentData.CurrentExpression;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardCalculatorViewModel()
        {
            #region Initialization

            currentData = new CurrentData();
            buttonsState = new ButtonsState();
            clearData = new ClearData(currentData, buttonsState);
            currentNumberFormation = new CurrentNumberFormation(currentData, buttonsState);
            currentExpressionFormation = new CurrentExpressionFormation(currentData, buttonsState);

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
                clearData.ClearAll();
                UpdateMainProperties();
            });

            ClearEntryCommand = new RelayCommand(() =>
            {
                clearData.ClearEntry();
                UpdateMainProperties();
            });

            BackspaceCommand = new RelayCommand(() =>
            {
                clearData.Backspace();
                UpdateMainProperties();
            });

            #endregion

            #region Commands for additional operations

            FindPercentageCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.FindPercentage();
                UpdateMainProperties();
            });

            PartOfTheWholeCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetAdditionalOperation(AdditionalOperations.PartOfTheWhole);
                UpdateMainProperties();
            });

            SqrCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetAdditionalOperation(AdditionalOperations.Exponentiation);
                UpdateMainProperties();
            });

            SqrtCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetAdditionalOperation(AdditionalOperations.RootExtraction);
                UpdateMainProperties();
            });

            #endregion

            #region Commands for basic math operations

            AdditionCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetBasicMathOperation(BasicMathOperations.Addition);
                UpdateMainProperties();
            });

            SubtractionCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetBasicMathOperation(BasicMathOperations.Subtraction);
                UpdateMainProperties();
            });

            MultiplyCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetBasicMathOperation(BasicMathOperations.Multiplication);
                UpdateMainProperties();
            });

            DivisionCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetBasicMathOperation(BasicMathOperations.Division);
                UpdateMainProperties();
            });

            EqualCommand = new RelayCommand(() =>
            {
                currentExpressionFormation.SetBasicMathOperation(BasicMathOperations.Equal);
                UpdateMainProperties();
            });

            #endregion

            #region Number pad commands

            DigitZeroCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Zero);
                UpdateMainProperties();
            });

            DigitOneCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.One);
                UpdateMainProperties();
            });

            DigitTwoCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Two);
                UpdateMainProperties();
            });

            DigitThreeCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Three);
                UpdateMainProperties();
            });

            DigitFourCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Four);
                UpdateMainProperties();
            });

            DigitFiveCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Five);
                UpdateMainProperties();
            });

            DigitSixCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Six);
                UpdateMainProperties();
            });

            DigitSevenCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Seven);
                UpdateMainProperties();
            });

            DigitEightCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Eight);
                UpdateMainProperties();
            });

            DigitNineCommand = new RelayCommand(() =>
            {
                currentNumberFormation.SetNumber(Digits.Nine);
                UpdateMainProperties();
            });

            InvertNumberCommand = new RelayCommand(() =>
            {
                currentNumberFormation.InvertNumber();
                UpdateMainProperties();
            });

            CommaCommand = new RelayCommand(() =>
            {
                currentNumberFormation.PutAComma();
                UpdateMainProperties();
            });

            #endregion

            #endregion
        }

        #endregion
    }
}