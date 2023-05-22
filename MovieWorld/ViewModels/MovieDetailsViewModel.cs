using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using MovieWorld.Commands;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// The view page for the movie details view
    /// </summary>
    public class MovieDetailsViewModel : ObservableRecipient
    {
        /// <summary>
        /// Constructor. Sets the commands for the toggle buttons.
        /// </summary>
        public MovieDetailsViewModel()
        {
            FavoritesCommand = new ToggleFavoritesCommand();
            WatchlistCommand = new ToggleWatchlistCommand();
        }

        /// <summary>
        /// The id of the movie.
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// The movie model that is displayed on the corresponding page
        /// </summary>
        private MovieModel movieModel;
        public MovieModel MovieModel
        {
            get => movieModel;
            private set => SetProperty(ref movieModel, value);
        }
        /// <summary>
        /// The cast of the movie displayed on the corresponding page
        /// </summary>
        private CastModel movieCastModel;
        public CastModel MovieCastModel
        {
            get => movieCastModel;
            private set => SetProperty(ref movieCastModel, value);
        }
        
        //Command delegates
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }

        /// <summary>
        /// Called when the page is navigated to. Loads the movie model and its cast.
        /// </summary>
        /// <returns></returns>
        public async Task OnNavigatedAsync()
        {
            var service = Ioc.Default.GetRequiredService<MovieDBService>();
            MovieModel = await service.GetMovieModelAsync(MovieId);
            MovieCastModel = await service.GetMovieCastAsync(MovieId);

        }
        /// <summary>
        /// Navigates to the Person Details page, if item was clicked
        /// </summary>
        /// <param name="personId">Id of the person in TMDB</param>
        public void NavigateToPersonPage(int personId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(personId);
        }

    }
}
