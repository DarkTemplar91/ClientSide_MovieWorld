using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.ObjectModel;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// Corresponding view model to the Favorites page
    /// </summary>
    public class FavoritesPageViewModel : ObservableRecipient
    {
        /// <summary>
        /// List of content, that is currently among the User's favorites.
        /// </summary>
        public ObservableCollection<ContentListItem> ContentLists { get; } = new();
        /// <summary>
        /// Constructor of the View Model. Loads the content that has been added to the User's favorites
        /// </summary>
        public FavoritesPageViewModel()
        {
            if (UserModel.Instance.Favorites is null)
                return;

            foreach (var item in UserModel.Instance.Favorites)
            {
                ContentLists.Add(item);
            }
        }
        /// <summary>
        /// Called by the View. Navigates to the content's corresponding details page, based on its media type.
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
