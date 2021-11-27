using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lernprogramm.ViewModel
{
    class DelegateCommand : ICommand
    {
        readonly Predicate<object> canExecute;
        readonly Action<object> execute;      

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }
        public DelegateCommand(Action<object> execute) { }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;
        public void Execute(object parameter) => execute?.Invoke(parameter);
    }
}
