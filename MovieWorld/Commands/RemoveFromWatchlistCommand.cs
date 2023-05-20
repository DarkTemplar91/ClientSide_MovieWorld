using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieWorld.Commands
{
    internal class RemoveFromWatchlistCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return false;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
