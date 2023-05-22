using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.ObjectModel;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// The view model for the Watchlist page
    /// </summary>
    public class WatchlistPageViewModel : ObservableRecipient
    {
        /// <summary>
        /// Content added to the watchlist
        /// </summary>
        public ObservableCollection<ContentListItem> ContentLists { get; } = new();
        public WatchlistPageViewModel()
        {
            if (UserModel.Instance.Watchlist is null)
                return;

            foreach (var item in UserModel.Instance.Watchlist)
            {
                ContentLists.Add(item);
            }
        }

        /// <summary>
        /// Navigates to the item's corresponding details page, based on <c>media_type</c>
        /// </summary>
        /// <param name="model">the item the user wants to open</param>
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
