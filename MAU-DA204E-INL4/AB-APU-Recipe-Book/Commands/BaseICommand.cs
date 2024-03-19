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
    /// </summary>
    public class BaseICommand : ICommand
    {
        private readonly Action _executeWithoutParam;
        private readonly Action<object> _executeWithParam;
        private readonly Func<bool> _canExecuteWithoutParam;
        private readonly Func<object, bool> _canExecuteWithParam;

        public BaseICommand(Action execute, Func<bool> canExecute = null)
        {
            _executeWithoutParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithoutParam = canExecute;
        }

        public BaseICommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _executeWithParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithParam = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteWithoutParam != null)
            {
                return _canExecuteWithoutParam();
            }
            else if (_canExecuteWithParam != null)
            {
                return _canExecuteWithParam(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _executeWithoutParam?.Invoke();
            _executeWithParam?.Invoke(parameter);
        }
    }
}
