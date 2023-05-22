using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
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
            FavoritesCommand = new ToggleFavoritesCommand();
            WatchlistCommand = new ToggleWatchlistCommand();
        }

        public int MovieId { get; set; }

        private MovieModel movieModel;
        public MovieModel MovieModel
        {
            get => movieModel;
            private set => SetProperty(ref movieModel, value);
        }

        private CastModel movieCastModel;
        public CastModel MovieCastModel
        {
            get => movieCastModel;
            private set => SetProperty(ref movieCastModel, value);
        }
        
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }

        public async Task OnNavigatedAsync()
        {
            var service = Ioc.Default.GetRequiredService<MovieDBService>();
            MovieModel = await service.GetMovieModelAsync(MovieId);
            MovieCastModel = await service.GetMovieCastAsync(MovieId);

        }

        public void NavigateToPersonPage(int personId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(personId);
        }

    }
}
