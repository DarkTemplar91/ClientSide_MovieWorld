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

        public ObservableCollection<ContentGroup> RecommendedContent { get; set; } = new();
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }
        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public async Task OnNavigatedAsync()
        {
            var service = Ioc.Default.GetRequiredService<MovieDBService>();
            var recommendedMovies = await service.GetTrendingContentAsync();
            List<ContentListItem> movieList = new();
            List<ContentListItem> showList = new();
            List<ContentListItem> actorList = new();
            foreach (var item in recommendedMovies.results)
            {
                switch (item.media_type)
                {
                    case "movie":
                        movieList.Add(item);
                        break;
                    case "tv":
                        showList.Add(item);
                        break;
                    case "person":
                        actorList.Add(item);
                        break;
                }
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
