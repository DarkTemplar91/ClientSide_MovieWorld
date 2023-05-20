﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    public class WatchlistPageViewModel : ObservableRecipient
    {
        public ObservableCollection<ContentListItem> ContentLists { get; set; } = new ObservableCollection<ContentListItem>();
        public WatchlistPageViewModel()
        {
            if (UserModel.Instance.Watchlist is null)
                return;

            foreach(var item in UserModel.Instance.Watchlist)
            {
                ContentLists.Add(item);
            }
        }

        public void NavigateToDetailsPage(ContentListItem model)
        {
            if (model.media_type == "movie")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>(model.id);
            else if (model.media_type == "tv")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<SeriesDetailsViewModel>(model.id);
            else if (model.media_type == "person")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(model.id);
        }
    }
}
