﻿using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieWorld.Commands
{
    public class ToggleFavoritesCommand : ICommand
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

            var model = parameter as ContentListItem;
            var user = UserModel.Instance;
            var modelFound = UserModel.Instance.Favorites.Find(x => x.id == model.id);
            if(modelFound is null)
            {
                user.AddContentToFavorites(model);
                return;
            }

            user.RemoveContentFromFavorites(modelFound);
            
        }
    }
}