﻿using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using MovieWorld.Models;
using System.Collections.ObjectModel;
using MovieWorld.Services;
using MovieWorld.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Mail;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.DependencyInjection;
using System.Reflection.Metadata;
using System.Windows.Input;
using Windows.UI.Xaml.Automation;
using Windows.ApplicationModel.Contacts;
using Microsoft.Extensions.DependencyInjection;

namespace MovieWorld.ViewModels
{
    public class TrendingPageViewModel : ObservableRecipient
    {
        public TrendingPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }

        public ObservableCollection<ContentGroup> RecommendedContent { get; set; } = new ObservableCollection<ContentGroup>();


        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public async Task OnNavigatedAsync()
        {
            var service = new MovieDBService();
            var recommendedMovies = await service.GetTrendingContentAsync();
            List<MovieListResult> movieList = new List<MovieListResult>();
            List<MovieListResult> showList = new List<MovieListResult>();
            List<MovieListResult> actorList = new List<MovieListResult>();
            foreach (var item in recommendedMovies.results)
            {
                if(item.media_type == "movie")
                    movieList.Add(item);
                else if (item.media_type == "tv")
                    showList.Add(item);
                else if (item.media_type == "person")
                    actorList.Add(item);
            }
            if( movieList.Count > 0)
                RecommendedContent.Add(new ContentGroup() { Content = movieList, Title = "Movies", Id = "0" });
            if( showList.Count > 0)
                RecommendedContent.Add(new ContentGroup() { Content = showList, Title = "TV Shows", Id = "1" });
            if (actorList.Count > 0)
                RecommendedContent.Add(new ContentGroup() { Content = actorList, Title = "Actors", Id = "2" });

        }

        public void NavigateToDetailsPage(MovieListResult model)
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