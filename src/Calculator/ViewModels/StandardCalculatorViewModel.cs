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
using Calculator.Models.ComposingAnExpression;

namespace Calculator.ViewModels
{
    class StandardCalculatorViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// Current entered number
        /// </summary>
        private string currentNumber = "0";

        /// <summary>
        /// Current entered expression
        /// </summary>
        private string currentExpression = "";

        /// <summary>
        /// служит для отслеживания, какая кнопка была нажата последней - кнопка цифровой клавиатуры или кнопка с основной мат. операцией
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        private bool whichBtnIsPressed = true;

        /// <summary>
        /// служит для отслеживания, была ли нажата любая из 3-х дополнительных операций
        /// </summary>
        private bool firstUsedCheck = true;

        /// <summary>
        /// To calculate the current expression
        /// </summary>
        private Calculate calculate;

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
        /// Erases numbers stored in memory
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
        /// The default value in memory is 0
        /// </remarks>
        public ICommand MemoryPlusCommand { get; }

        /// <summary>
        /// Subtracts the current number from the number stored in memory
        /// </summary>
        /// <remarks>
        /// The default value in memory is 0
        /// </remarks>
        public ICommand MemoryMinusCommand { get; }

        /// <summary>
        /// Saves the current number in memory for later use
        /// </summary>
        public ICommand MemorySaveCommand { get; }

        /// <summary>
        /// View the number stored in memory
        /// </summary>
        public ICommand MemoryHistoryCommand { get; }

        #endregion

        #region Commands for additional operations

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

        /// <summary>
        /// Finds a percentage of the current expression
        /// </summary>
        public ICommand FindPercentageCommand { get; }

        /// <summary>
        /// Allows you to find out how much the current number is from a single whole
        /// </summary>
        public ICommand PartOfTheWholeCommand { get; }

        /// <summary>
        /// Square of the current number
        /// </summary>
        public ICommand SqrCommand { get; }

        /// <summary>
        /// Square root of the current number
        /// </summary>
        public ICommand SqrtCommand { get; }

        #endregion

        #region Commands for basic math operations

        /// <summary>
        /// Adds an addition operation to an expression
        /// </summary>
        public ICommand AdditionCommand { get; }

        /// <summary>
        /// Adds a subtraction operation to an expression
        /// </summary>
        public ICommand SubtractionCommand { get; }

        /// <summary>
        /// Adds a multiply operation to an expression
        /// </summary>
        public ICommand MultiplyCommand { get; }

        /// <summary>
        /// Adds a division operation to an expression
        /// </summary>
        public ICommand DivisionCommand { get; }

        /// <summary>
        /// Counts the value of the current expression
        /// </summary>
        public ICommand EquallyCommand { get; }

        #endregion

        #region Number pad commands

        /// <summary>
        /// Adds number 0 to the current number
        /// </summary>
        public ICommand NumberZeroCommand { get; }

        /// <summary>
        /// Adds number 1 to the current number
        /// </summary>
        public ICommand NumberOneCommand { get; }

        /// <summary>
        /// Adds number 2 to the current number
        /// </summary>
        public ICommand NumberTwoCommand { get; }

        /// <summary>
        /// Adds number 3 to the current number
        /// </summary>
        public ICommand NumberThreeCommand { get; }

        /// <summary>
        /// Adds number 4 to the current number
        /// </summary>
        public ICommand NumberFourCommand { get; }

        /// <summary>
        /// Adds number 5 to the current number
        /// </summary>
        public ICommand NumberFiveCommand { get; }

        /// <summary>
        /// Adds number 6 to the current number
        /// </summary>
        public ICommand NumberSixCommand { get; }

        /// <summary>
        /// Adds number 7 to the current number
        /// </summary>
        public ICommand NumberSevenCommand { get; }

        /// <summary>
        /// Adds number 8 to the current number
        /// </summary>
        public ICommand NumberEightCommand { get; }

        /// <summary>
        /// Adds number 9 to the current number
        /// </summary>
        public ICommand NumberNineCommand { get; }

        /// <summary>
        /// Inverts a number from positive to negative and vice versa
        /// </summary>
        public ICommand InvertNumberCommand { get; }

        /// <summary>
        /// Makes the current number real
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
            MemoryHistoryCommand = ;
            */
            #endregion

            #region Commands for additional operations

            ClearCommand = new RelayCommand(() => 
            {
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);
                CurrentExpression = ClearData.ClearExpression(CurrentExpression);

                //сомнительный момент
                whichBtnIsPressed = true;
                firstUsedCheck = true;
            });

            ClearEntryCommand = new RelayCommand(() =>
            {
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);

                //сомнительный момент
                whichBtnIsPressed = true;
            });

            BackspaceCommand = new RelayCommand(() => CurrentNumber = ClearData.Backspace(CurrentNumber));

            //FindPercentageCommand = ;

            PartOfTheWholeCommand = new RelayCommand(() =>
            {
                CurrentExpression = FormingAnExpression.SetAdditionalOperation(CurrentNumber, CurrentExpression, "1/", ref firstUsedCheck, out whichBtnIsPressed);
            });

            SqrCommand = new RelayCommand(() =>
            {
                CurrentExpression = FormingAnExpression.SetAdditionalOperation(CurrentNumber, CurrentExpression, "Sqr", ref firstUsedCheck, out whichBtnIsPressed);
            });

            SqrtCommand = new RelayCommand(() => 
            {
                CurrentExpression = FormingAnExpression.SetAdditionalOperation(CurrentNumber, CurrentExpression, "√", ref firstUsedCheck, out whichBtnIsPressed);
            });

            #endregion

            #region Commands for basic math operations

            AdditionCommand = new RelayCommand(() =>
            {
                CurrentExpression = FormingAnExpression.SetBasicMathOperation(CurrentNumber, CurrentExpression, Operations.Addition, ref whichBtnIsPressed, ref firstUsedCheck);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            });

            SubtractionCommand = new RelayCommand(() =>
            {
                CurrentExpression = FormingAnExpression.SetBasicMathOperation(CurrentNumber, CurrentExpression, Operations.Subtraction, ref whichBtnIsPressed, ref firstUsedCheck);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            });

            MultiplyCommand = new RelayCommand(() =>
            {
                CurrentExpression = FormingAnExpression.SetBasicMathOperation(CurrentNumber, CurrentExpression, Operations.Multiplication, ref whichBtnIsPressed, ref firstUsedCheck);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            });

            DivisionCommand = new RelayCommand(() =>
            {
                CurrentExpression = FormingAnExpression.SetBasicMathOperation(CurrentNumber, CurrentExpression, Operations.Division, ref whichBtnIsPressed, ref firstUsedCheck);
                CurrentNumber = ClearData.ClearNumber(CurrentNumber);
            });

            //возможно дописать отдельную функцию
            EquallyCommand = new RelayCommand(() =>
            {
                CurrentExpression = FormingAnExpression.SetBasicMathOperation(CurrentNumber, CurrentExpression, Operations.Equally, ref whichBtnIsPressed, ref firstUsedCheck);
                CurrentNumber = calculate.Calc(CurrentExpression).ToString();
            });
            
            #endregion

            #region Number pad commands

            NumberZeroCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Zero, out whichBtnIsPressed));
            NumberOneCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.One, out whichBtnIsPressed));
            NumberTwoCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Two, out whichBtnIsPressed));
            NumberThreeCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Three, out whichBtnIsPressed));
            NumberFourCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Four, out whichBtnIsPressed));
            NumberFiveCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Five, out whichBtnIsPressed));
            NumberSixCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Six, out whichBtnIsPressed));
            NumberSevenCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Seven, out whichBtnIsPressed));
            NumberEightCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Eight, out whichBtnIsPressed));
            NumberNineCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.SetNumber(CurrentNumber, Numerals.Nine, out whichBtnIsPressed));
            InvertNumberCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.InvertNumber(CurrentNumber));
            CommaCommand = new RelayCommand(() => CurrentNumber = FormingCurrentNumber.PutAComma(CurrentNumber, out whichBtnIsPressed));
            
            #endregion

            #endregion
        }

        #endregion
    }
}