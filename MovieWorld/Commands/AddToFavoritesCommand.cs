using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieWorld.Commands
{
    public class AddToFavoritesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(parameter == null)
                return false;

            if (parameter.GetType() != typeof(ContentListItem))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter) == false)
                return;

            var user = UserModel.Instance;
            user.AddContentToFavorites(parameter as ContentListItem);
        }
    }
}
