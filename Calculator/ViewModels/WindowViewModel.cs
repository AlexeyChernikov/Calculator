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
    public class WindowViewModel : BaseViewModel
    {
        #region Private member

        private Window window;
        private int outerMarginSize = 10;


        //private int windowRadius = 10;

        #endregion

        #region Public properties

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
            }
            set
            {
                outerMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        //public int WindowRadius
        //{
        //    get
        //    {
        //        return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
        //    }
        //    set
        //    {
        //        windowRadius = value;
        //    }
        //}

        //public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        //Height of the title bar
        public int TitleHeight { get; set; } = 26;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        #endregion

        public WindowViewModel(Window window)
        {
            this.window = window;

            //Window resize
            window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                //OnPropertyChanged(nameof(WindowRadius));
                //OnPropertyChanged(nameof(WindowCornerRadius));
            };

            //Create command
            MinimizeCommand = new RelayCommand(minimizeCommand);
            MaximizeCommand = new RelayCommand(maximizeCommand);
            CloseCommand = new RelayCommand(closeCommand);

            //Fix window resize issue
            var resizer = new WindowResizer(this.window);
        }

        private void minimizeCommand(object parameter) => window.WindowState = WindowState.Minimized;
        private void maximizeCommand(object parameter) => window.WindowState ^= WindowState.Maximized;
        private void closeCommand(object parameter) => window.Close();
    }
}