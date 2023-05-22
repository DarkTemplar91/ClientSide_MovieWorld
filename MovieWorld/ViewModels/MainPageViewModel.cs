using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// The view model of our main page.
    /// </summary>
    public class MainPageViewModel
    {
        /// <summary>
        /// The constructor of our view model. Sets the task that is to be run when the page is loaded
        /// </summary>
        public MainPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }
        /// <summary>
        /// The result of the search in the <c>AutoSuggestBox</c>
        /// </summary>
        public ObservableCollection<SearchResult> SearchResults { get; } = new();

        /// <summary>
        /// The command delegate that is used, when the page is loaded.
        /// </summary>
        public IAsyncRelayCommand ReloadTaskCommand { get; }

        /// <summary>
        /// When the page is loaded, load the Trending Page to the content frame by default
        /// </summary>
        /// <returns></returns>
        private async Task OnNavigatedAsync()
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<TrendingPageViewModel>();
        }

        /// <summary>
        /// Called by the view. Navigates to the page selected from the NavigationView
        /// </summary>
        /// <param name="selectedItemTag"></param>
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

        /// <summary>
        /// Refreshes the search results displayed. Called by the view, when the text is updated.
        /// </summary>
        /// <param name="keyword">the search query</param>
        /// <returns></returns>
        public async Task RefreshSearchResults(string keyword)
        {
            SearchResults.Clear();
            var searchResultModel = await Ioc.Default.GetRequiredService<MovieDBService>().GetSearchResult(keyword);
            foreach (var result in searchResultModel.results)
            {
                SearchResults.Add(result);
            }
        }
        /// <summary>
        /// Navigates to the specified content's page
        /// </summary>
        /// <param name="model">the model that was clicked in the searchbox</param>
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
        /// <summary>
        /// Navigates to the searchbox if no item was selected when the AutoSuggestBox was queried.
        /// </summary>
        /// <param name="keyword">The keyword used for the search</param>
        public void NavigateToSearchPage(string keyword)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<SearchPageViewModel>(keyword);
        }
    }
}
