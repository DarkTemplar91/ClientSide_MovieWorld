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
    public class SearchPageViewModel : ObservableRecipient
    {
        public IAsyncRelayCommand ReloadTaskCommand { get; }
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

        public ObservableCollection<SearchResult> SearchResults { get; set; } = new();

        public async Task OnNavigatedAsync()
        {
            await RefreshSearchResults(Keyword);
        }

        public async Task RefreshSearchResults(string searchKeyword)
        {
            SearchResults.Clear();
            var searchResultModel = await Ioc.Default.GetRequiredService<MovieDBService>().GetSearchResult(searchKeyword);
            foreach (var result in searchResultModel.results)
            {
                SearchResults.Add(result);
            }
        }

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

    public class SearchItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MovieTemplate { get; set; }
        public DataTemplate SeriesTemplate { get; set; }
        public DataTemplate PersonTemplate { get; set; }

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
