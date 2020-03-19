using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Calculator.ViewModels.Base;
using Calculator.WindowHelper;

namespace Calculator.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// Current window object
        /// </summary>
        private Window window;

        #endregion

        #region Public properties

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// Height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 26;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Commands

        /// <summary>
        /// Command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel()
        {
            this.window = Application.Current.MainWindow;

            //Window resizing
            this.window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
            };

            //Create commands
            MinimizeCommand = new RelayCommand(() => this.window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => this.window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => this.window.Close());

            //Fix window resize issue
            var resizer = new WindowResizer(this.window);
        }

        #endregion
    }
}