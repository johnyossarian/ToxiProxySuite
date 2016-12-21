using System;
using System.Windows.Input;


namespace ToxiproxySuite
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> action;

        private Predicate<object> canExecute;
        
        public RelayCommand(Action<object> action) : this (action, (x => true))
        { }

        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null && this.canExecute(parameter);
        }
    }
}
