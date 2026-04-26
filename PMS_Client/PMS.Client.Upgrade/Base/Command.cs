using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMS.Client.Upgrade.Base
{
    public class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _doExecute?.Invoke(parameter);
        }
        Action<object?> _doExecute;

        public Command(Action<object?> doExecute)
        {
            this._doExecute = doExecute;
        }
    }
}
