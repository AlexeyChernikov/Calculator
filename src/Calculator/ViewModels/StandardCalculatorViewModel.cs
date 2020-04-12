using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Calculator.Common;
using Calculator.ViewModels.Base;
using Calculator.Models;

namespace Calculator.ViewModels
{
    class StandardCalculatorViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// Contains logic for the calculator
        /// </summary>
        private CalculatorLogic calculatorLogic;

        #endregion

        #region Public properties

        /// <summary>
        /// To show the current number on the display
        /// </summary>
        public string CurrentNumber
        {
            get
            {
                return calculatorLogic.CurrentNumber;
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
                return calculatorLogic.CurrentExpression;
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
        /// To UpdateMainProperties the current number and current expression
        /// </summary>
        private void UpdateMainProperties()
        {
            CurrentNumber = calculatorLogic.CurrentNumber;
            CurrentExpression = calculatorLogic.CurrentExpression;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardCalculatorViewModel()
        {
            #region Initialization

            calculatorLogic = new CalculatorLogic();

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
                calculatorLogic.ClearAll();
                UpdateMainProperties();
            });

            ClearEntryCommand = new RelayCommand(() =>
            {
                calculatorLogic.ClearEntry();
                UpdateMainProperties();
            });

            BackspaceCommand = new RelayCommand(() => 
            {
                calculatorLogic.Backspace();
                CurrentNumber = calculatorLogic.CurrentNumber;
            });

            #endregion

            #region Commands for additional operations

            FindPercentageCommand = new RelayCommand(() =>
            {
                calculatorLogic.FindPercentage();
                UpdateMainProperties();
            });

            PartOfTheWholeCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetAdditionalOperation(AdditionalOperations.PartOfTheWhole);
                UpdateMainProperties();
            });

            SqrCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetAdditionalOperation(AdditionalOperations.Exponentiation);
                UpdateMainProperties();
            });

            SqrtCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetAdditionalOperation(AdditionalOperations.RootExtraction);
                UpdateMainProperties();
            });

            #endregion

            #region Commands for basic math operations

            AdditionCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetBasicMathOperation(BasicMathOperations.Addition);
                UpdateMainProperties();
            });

            SubtractionCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetBasicMathOperation(BasicMathOperations.Subtraction);
                UpdateMainProperties();
            });

            MultiplyCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetBasicMathOperation(BasicMathOperations.Multiplication);
                UpdateMainProperties();
            });

            DivisionCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetBasicMathOperation(BasicMathOperations.Division);
                UpdateMainProperties();
            });

            EqualCommand = new RelayCommand(() =>
            {
                calculatorLogic.SetBasicMathOperation(BasicMathOperations.Equal);
                UpdateMainProperties();
            });

            #endregion

            #region Number pad commands

            DigitZeroCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Zero));
            DigitOneCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.One));
            DigitTwoCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Two));
            DigitThreeCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Three));
            DigitFourCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Four));
            DigitFiveCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Five));
            DigitSixCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Six));
            DigitSevenCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Seven));
            DigitEightCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Eight));
            DigitNineCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.SetNumber(Digits.Nine));
            InvertNumberCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.InvertNumber());
            CommaCommand = new RelayCommand(() => CurrentNumber = calculatorLogic.PutAComma());

            #endregion

            #endregion
        }

        #endregion
    }
}