using System.Collections.Generic;
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

namespace MovieWorld.ViewModels
{
    public class MainPageViewModel : ObservableRecipient
    {
        public MainPageViewModel()
        {
            ReloadTaskCommand = new RelayCommand(OnNavigatedAsync);
        }

        public ObservableCollection<MovieListResult> RecommendedMovies { get; set; } = new ObservableCollection<MovieListResult>();

        public ICommand ReloadTaskCommand { get; }

        public async void OnNavigatedAsync()
        {
            var service = new MovieDBService();
            var recommendedMovies = await service.GetTrendingMoviesAsync();
            foreach (var item in recommendedMovies.results)
            {
                RecommendedMovies.Add(item);
            }
        }

        public void NavigateToMovieDetails(int movieId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>(movieId);
        }

    }
}
