using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// The view model for the Search Page
    /// </summary>
    public class SearchPageViewModel : ObservableRecipient
    {
        public IAsyncRelayCommand ReloadTaskCommand { get; }
        /// <summary>
        /// Keyword used for the search
        /// </summary>
        private string keyword;
        public string Keyword
        {
            get => keyword;
            set => SetProperty(ref keyword, value);
        }

        public SearchPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }

        /// <summary>
        /// The result of the User's search for the keyword
        /// </summary>
        public ObservableCollection<SearchResult> SearchResults { get; } = new();

        /// <summary>
        /// Called when the corresponding page is navigated to. Refreshes the results.
        /// </summary>
        /// <returns></returns>
        public async Task OnNavigatedAsync()
        {
            await RefreshSearchResults(Keyword);
        }
        /// <summary>
        /// Refreshes the results. Uses the keyword for the query.
        /// </summary>
        /// <param name="searchKeyword">The query parameter</param>
        /// <returns></returns>
        public async Task RefreshSearchResults(string searchKeyword)
        {
            SearchResults.Clear();
            var searchResultModel = await Ioc.Default.GetRequiredService<MovieDBService>().GetSearchResult(searchKeyword);
            foreach (var result in searchResultModel.results)
            {
                SearchResults.Add(result);
            }
        }
        /// <summary>
        /// Navigates to the item's corresponding page, based on <c>media_type</c>
        /// </summary>
        /// <param name="model"></param>
        public void NavigateToDetailsPage(SearchResult model)
        {
            if (model.media_type == "movie")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>(model.id);
            else if (model.media_type == "tv")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<SeriesDetailsViewModel>(model.id);
            else if (model.media_type == "person")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(model.id);
        }
    }
    /// <summary>
    /// Selector used for the search lists data templates.
    /// </summary>
    public class SearchItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MovieTemplate { get; set; }
        public DataTemplate SeriesTemplate { get; set; }
        public DataTemplate PersonTemplate { get; set; }

        /// <summary>
        /// Returns the correct <c>DataTemplate</c> based on the content's <c>media_type</c>
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is SearchResult searchResult)
                return searchResult.media_type switch
                {
                    "movie" => MovieTemplate,
                    "tv" => SeriesTemplate,
                    "person" => PersonTemplate,
                    _ => null
                };
            return null;
        }

    }
}
