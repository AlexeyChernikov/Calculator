using System.Windows.Input;
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
        private NumberFormation numberFormation;

        /// <summary>
        /// To access methods for formation the current expression
        /// </summary>
        private ExpressionFormation expressionFormation;

        /// <summary>
        /// To access methods for working with memory
        /// </summary>
        private Memory memory;

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

        /// <summary>
        /// To check when to lock the memory buttons
        /// </summary>
        private bool MemoryBtnLockCondition()
        {
            return NumberStandardization.NumberCheck(currentData.CurrentNumber) && !memory.MemoryIsEmpty ? true : false;
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
            numberFormation = new NumberFormation(currentData, buttonsState, clearData);
            expressionFormation = new ExpressionFormation(currentData, buttonsState, clearData);
            memory = new Memory();

            #endregion

            #region Create commands

            #region Commands for memory operations

            MemoryClearCommand = new RelayParameterizedCommand((obj) =>
            {
                memory.MemoryClear();
            }, (obj) => MemoryBtnLockCondition());

            MemoryReadCommand = new RelayParameterizedCommand((obj) =>
            {
                if (buttonsState.EqualBtnPressed)
                {
                    clearData.ClearAll();
                }
                else if (buttonsState.AdditionalOperationBtnPressed)
                {
                    currentData.CurrentExpression = clearData.ClearLastAdditionalOperation(currentData.CurrentExpression);
                    buttonsState.AdditionalOperationBtnPressed_Change(false);
                }

                currentData.CurrentNumber = memory.CurrentValue.ToString();
                buttonsState.NumberPadBtnPressed_Change(true);
                UpdateMainProperties();
            }, (obj) => MemoryBtnLockCondition());

            MemoryPlusCommand = new RelayParameterizedCommand((obj) =>
            {
                memory.MemoryPlus(CurrentNumber);
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            MemoryMinusCommand = new RelayParameterizedCommand((obj) =>
            {
                memory.MemoryMinus(CurrentNumber);
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            MemorySaveCommand = new RelayParameterizedCommand((obj) =>
            {
                memory.MemorySave(CurrentNumber);
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            MemoryStorageCommand = new RelayParameterizedCommand((obj) =>
            {
                System.Windows.MessageBox.Show(memory.CurrentValue.ToString());
            }, (obj) => MemoryBtnLockCondition());

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

            FindPercentageCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.FindPercentage();
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            PartOfTheWholeCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetAdditionalOperation(AdditionalOperations.PartOfTheWhole);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            SqrCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetAdditionalOperation(AdditionalOperations.Exponentiation);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            SqrtCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetAdditionalOperation(AdditionalOperations.RootExtraction);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            #endregion

            #region Commands for basic math operations

            AdditionCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetBasicMathOperation(BasicMathOperations.Addition);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            SubtractionCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetBasicMathOperation(BasicMathOperations.Subtraction);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            MultiplyCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetBasicMathOperation(BasicMathOperations.Multiplication);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            DivisionCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetBasicMathOperation(BasicMathOperations.Division);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            EqualCommand = new RelayParameterizedCommand((obj) =>
            {
                expressionFormation.SetBasicMathOperation(BasicMathOperations.Equal);
                UpdateMainProperties();
            }, (obj) => NumberStandardization.NumberCheck(currentData.CurrentNumber));

            #endregion

            #region Number pad commands

            DigitZeroCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Zero);
                UpdateMainProperties();
            });

            DigitOneCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.One);
                UpdateMainProperties();
            });

            DigitTwoCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Two);
                UpdateMainProperties();
            });

            DigitThreeCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Three);
                UpdateMainProperties();
            });

            DigitFourCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Four);
                UpdateMainProperties();
            });

            DigitFiveCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Five);
                UpdateMainProperties();
            });

            DigitSixCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Six);
                UpdateMainProperties();
            });

            DigitSevenCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Seven);
                UpdateMainProperties();
            });

            DigitEightCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Eight);
                UpdateMainProperties();
            });

            DigitNineCommand = new RelayCommand(() =>
            {
                numberFormation.AddDigit(Digits.Nine);
                UpdateMainProperties();
            });

            InvertNumberCommand = new RelayCommand(() =>
            {
                numberFormation.InvertNumber();
                UpdateMainProperties();
            });

            CommaCommand = new RelayCommand(() =>
            {
                numberFormation.AddComma();
                UpdateMainProperties();
            });

            #endregion

            #endregion
        }

        #endregion
    }
}