using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Calculator.ViewModels.Base;

namespace Calculator.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private member

        private Window window;
        private int outerMarginSize = 10;
        private int windowRadius = 10;

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

        public int WindowRadius
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }
            set
            {
                windowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        #endregion

        public WindowViewModel (Window window)
        {
            this.window = window;

            //window resize
            window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }
    }
}
