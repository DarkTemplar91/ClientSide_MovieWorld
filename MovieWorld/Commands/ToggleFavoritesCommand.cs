using MovieWorld.Models;
using System;
using System.Windows.Input;

namespace MovieWorld.Commands
{
    /// <summary>
    /// The <c>ToggleFavoritesCommand</c> is a class implementing the <c>ICommand</c> interface.
    /// It is used for the toggle buttons, so when pressed it adds to or removes the content from the Favorites page.
    /// </summary>
    public class ToggleFavoritesCommand : ICommand
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
            var modelFound = UserModel.Instance.Favorites.Find(x => model != null && x.id == model.id);
            if (modelFound is null)
            {
                user.AddContentToFavorites(model);
                return;
            }

            user.RemoveContentFromFavorites(modelFound);

        }
    }
}
