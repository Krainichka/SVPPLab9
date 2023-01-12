using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab9.Commands
{
    class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Признак CanExecute
        private Func<object, bool> canExecute;
      
        // делегат метода Execute        
        private Action<object> executeMethod;
        
        // Конструктор
        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecute)
        {
            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
        }
        public RelayCommand(Action<object> executeMethod)
        {
            this.executeMethod = executeMethod;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }
        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
