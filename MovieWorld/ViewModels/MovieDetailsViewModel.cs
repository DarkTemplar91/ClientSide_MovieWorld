using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Commands;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Threading.Tasks;

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
        public int MovieId
        {
            get => movieId;
            set => movieId = value;
        }
        private MovieModel movieModel;
        public MovieModel MovieModel
        {
            get => movieModel;
            set => SetProperty(ref movieModel, value);
        }

        private CastModel movieCastModel;
        public CastModel MovieCastModel
        {
            get => movieCastModel;
            set => SetProperty(ref movieCastModel, value);
        }

        public IAsyncRelayCommand ReloadTaskCommand { get; }
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }

        public async Task OnNavigatedAsync()
        {
            //TODO: Create a singleton somewhere else and use it here with ioc and di
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
