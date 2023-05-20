using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Commands;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.ViewModels
{
    public class MovieDetailsViewModel : ObservableRecipient
    {
        public MovieDetailsViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
            FavoritesCommand = new ToggleFavoritesCommand();
            WatchlistCommand = new ToggleWatchlistCommand();
        }
        private int movieId;
        public int MovieId { get { return movieId; } set { movieId = value; } }
        private MovieModel movieModel;
        public MovieModel MovieModel
        {
            get { return movieModel; }
            set { SetProperty(ref movieModel, value); }
        }

        private CastModel movieCastModel;
        public CastModel MovieCastModel
        {
            get { return movieCastModel; }
            set { SetProperty(ref movieCastModel, value); }
        }

        public IAsyncRelayCommand ReloadTaskCommand { get; }
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }

        public async Task OnNavigatedAsync()
        {
            //TODO: Create a singleton?
            var service = new MovieDBService();
            MovieModel = await service.GetMovieModelAsync(movieId);
            MovieCastModel = await service.GetMovieCastAsync(movieId);

        }

        public void NavigateToPersonPage(int personId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(personId);
        }

    }
}
