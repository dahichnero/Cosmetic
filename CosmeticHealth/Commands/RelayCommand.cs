using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CosmeticHealth.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> action;
        private readonly Func<object?, bool> canExecute;

        public RelayCommand(Action<object?> action)
        {
            this.action = action;
            canExecute = _ => true;
        }

        public RelayCommand(Action<object?> action, Func<object?, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested+=value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object? parameter)
        {
            if (canExecute is null)
            {
                return true;
            }
            return canExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            action?.Invoke(parameter);
        }
    }
}
