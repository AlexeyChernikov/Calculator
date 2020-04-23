using Calculator.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModels
{
    class MainWindowContentControlViewModel : BaseViewModel
    {
        #region Commands

        /// <summary>
        /// Nope!!!
        /// </summary>
        public ICommand NopeCommand { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowContentControlViewModel()
        {
            NopeCommand = new RelayCommand(() => MessageBox.Show("Nope!!!"));
        }

        #endregion
    }
}
