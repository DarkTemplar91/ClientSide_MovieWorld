using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Commands;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// The trending page's corresponding view model where trending content can be seen
    /// </summary>
    public class TrendingPageViewModel : ObservableRecipient
    {
        public TrendingPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
            FavoritesCommand = new ToggleFavoritesCommand();
            WatchlistCommand = new ToggleWatchlistCommand();
        }
        /// <summary>
        /// The list of trending/recommendid content
        /// </summary>
        public ObservableCollection<ContentGroup> RecommendedContent { get; } = new();
        /// <summary>
        /// Commands used to add or remove from the Favorites list via the favorite toggle button
        /// </summary>
        public ToggleFavoritesCommand FavoritesCommand { get; }
        /// <summary>
        /// Commands used to add or remove from the Watchlist via the favorite toggle button
        /// </summary>
        public ToggleWatchlistCommand WatchlistCommand { get; }
        public IAsyncRelayCommand ReloadTaskCommand { get; }

        /// <summary>
        /// Called when the corresponding page was navigated to. Fetches a list of content, and it organizes is into groups
        /// for the GridView to display.
        /// </summary>
        /// <returns></returns>
        private async Task OnNavigatedAsync()
        {
            try
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
                    RecommendedContent.Add(new ContentGroup() {Content = movieList, Title = "Movies", Id = "0"});
                if (showList.Count > 0)
                    RecommendedContent.Add(new ContentGroup() {Content = showList, Title = "TV Shows", Id = "1"});
                if (actorList.Count > 0)
                    RecommendedContent.Add(new ContentGroup() {Content = actorList, Title = "Actors", Id = "2"});
            }
            catch
            {
                new ToastContentBuilder()
                    .AddText("An error occurred", hintMaxLines: 1)
                    .AddText("We ran into an unexpected problem.").Show();
            }

        }
        /// <summary>
        /// Navigates to the content's details page, based on <c>media_type</c>
        /// </summary>
        /// <param name="model"></param>
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
