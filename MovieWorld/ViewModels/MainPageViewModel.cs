using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    public class MainPageViewModel
    {

        public MainPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }

        public ObservableCollection<SearchResult> SearchResults { get; set; } = new();


        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public async Task OnNavigatedAsync()
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<TrendingPageViewModel>();
        }

        public void NavigateToNavItemPage(string selectedItemTag)
        {
            switch (selectedItemTag)
            {
                case "x:home":
                    Ioc.Default.GetRequiredService<INavigationService>().Navigate<TrendingPageViewModel>();
                    break;
                case "x:favorites":
                    Ioc.Default.GetRequiredService<INavigationService>().Navigate<FavoritesPageViewModel>();
                    break;
                case "x:watchlist":
                    Ioc.Default.GetRequiredService<INavigationService>().Navigate<WatchlistPageViewModel>();
                    break;
            }
        }

        public async Task RefreshSearchResults(string keyword)
        {
            SearchResults.Clear();
            var searchResultModel = await Ioc.Default.GetRequiredService<MovieDBService>().GetSearchResult(keyword);
            foreach (var result in searchResultModel.results)
            {
                SearchResults.Add(result);
            }
        }

        public void NavigateToDetailsPage(SearchResult model)
        {
            switch (model.media_type)
            {
                case "movie":
                    Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>(model.id);
                    break;
                case "tv":
                    Ioc.Default.GetRequiredService<INavigationService>().Navigate<SeriesDetailsViewModel>(model.id);
                    break;
                case "person":
                    Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(model.id);
                    break;
            }
        }

        public void NavigateToSearchPage(string keyword)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<SearchPageViewModel>(keyword);
        }
    }
}
