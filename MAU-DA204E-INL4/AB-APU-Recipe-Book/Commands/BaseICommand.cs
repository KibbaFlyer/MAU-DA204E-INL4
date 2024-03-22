using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AB_APU_Recipe_Book.Commands
{
    /// <summary>
    /// An extension of ICommand, to create a RelayCommand to be used in ViewModels
    /// Has functionality to support both argument-free commands but also those with an argument
    /// In a previous solution I used to pass parameters from the View to the ViewModel, and therefore needed these to accept arguments.
    /// This could be simplified but I would like to keep it like this in order to provide for that ability if necessary in the future.
    /// </summary>
    public class BaseICommand<T> : ICommand where T : class
    {
        private Action<T> _execute;
        private Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public BaseICommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute  = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
