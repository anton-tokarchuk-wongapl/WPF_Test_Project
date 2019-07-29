using System;
using System.Windows.Input;

namespace SampleWPFProject.Commands
{
    class UserCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public UserCommands(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
