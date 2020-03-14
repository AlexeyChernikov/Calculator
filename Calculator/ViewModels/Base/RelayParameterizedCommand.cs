using System;
using System.Windows.Input;

namespace Calculator.ViewModels.Base
{
    public class RelayParameterizedCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayParameterizedCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}