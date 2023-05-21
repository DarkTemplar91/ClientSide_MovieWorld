using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Commands;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    public class TrendingPageViewModel : ObservableRecipient
    {
        public TrendingPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
            FavoritesCommand = new ToggleFavoritesCommand();
            WatchlistCommand = new ToggleWatchlistCommand();
        }

        public ObservableCollection<ContentGroup> RecommendedContent { get; set; } = new ObservableCollection<ContentGroup>();
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }
        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public async Task OnNavigatedAsync()
        {
            var service = new MovieDBService();
            var recommendedMovies = await service.GetTrendingContentAsync();
            List<ContentListItem> movieList = new List<ContentListItem>();
            List<ContentListItem> showList = new List<ContentListItem>();
            List<ContentListItem> actorList = new List<ContentListItem>();
            foreach (var item in recommendedMovies.results)
            {
                if (item.media_type == "movie")
                    movieList.Add(item);
                else if (item.media_type == "tv")
                    showList.Add(item);
                else if (item.media_type == "person")
                    actorList.Add(item);
            }
            if (movieList.Count > 0)
                RecommendedContent.Add(new ContentGroup() { Content = movieList, Title = "Movies", Id = "0" });
            if (showList.Count > 0)
                RecommendedContent.Add(new ContentGroup() { Content = showList, Title = "TV Shows", Id = "1" });
            if (actorList.Count > 0)
                RecommendedContent.Add(new ContentGroup() { Content = actorList, Title = "Actors", Id = "2" });

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
