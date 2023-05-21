using MovieWorld.Models;
using System;
using System.Windows.Input;

namespace MovieWorld.Commands
{
    public class ToggleWatchlistCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;

            if (parameter.GetType() != typeof(ContentListItem))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter) == false)
                return;

            var model = parameter as ContentListItem;
            var user = UserModel.Instance;
            var modelFound = UserModel.Instance.Watchlist.Find(x => model != null && x.id == model.id);
            if (modelFound is null)
            {
                user.AddContentToWatchlist(model);
                return;
            }
            user.RemoveContentFromWatchlist(modelFound);

        }
    }
}
