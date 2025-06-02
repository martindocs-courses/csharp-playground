using System.Windows.Input;

namespace ViewModelsInMVVM.MVVM
{
    internal class RelayCommand : ICommand
    {
        // Minimum requirements of the 'ICommand' interface
        /*
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                throw new NotImplementedException();
            }

            public void Execute(object? parameter)
            {
                throw new NotImplementedException();
            }
         */

        // extend the interface
        private Action<object> execute; // Action<T> is a method that has single parameter and do not return a value and 'execute' will be a function call.
        private Func<object, bool> canExecute; // return bool value

        public event EventHandler? CanExecuteChanged{
            // below code allows us to better manage our memory by adding and unhooking our events when appropriate
            add { CommandManager.RequerySuggested += value; } 
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
