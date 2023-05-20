using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    public class MainPageViewModel
    {

        public MainPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }

        public ObservableCollection<ContentGroup> RecommendedContent { get; set; } = new ObservableCollection<ContentGroup>();
        public ObservableCollection<SearchResult> SearchResults { get; set; } = new ObservableCollection<SearchResult>();


        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public async Task OnNavigatedAsync()
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<TrendingPageViewModel>();
        }

        public void NavigateToNavItemPage(string selectedItemTag)
        {
            if (selectedItemTag == "x:home")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<TrendingPageViewModel>();
            else if (selectedItemTag == "x:favorites")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<FavoritesPageViewModel>();
            else if (selectedItemTag == "x:watchlist")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<WatchlistPageViewModel>();
        }

        public async Task RefreshSearchResults(string keyword)
        {
            SearchResults.Clear();
            var searchResultModel = await new MovieDBService().GetSearchResult(keyword);
            foreach( var result in searchResultModel.results )
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

        public void NavigateToSearchPage(string keyword)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<SearchPageViewModel>(keyword);
        }
    }
}
