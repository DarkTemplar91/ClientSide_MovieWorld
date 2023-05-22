using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Uwp.Notifications;
using MovieWorld.Commands;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// View model for the Series Details view
    /// </summary>
    public class SeriesDetailsViewModel : ObservableRecipient
    {
        public SeriesDetailsViewModel()
        {
            FavoritesCommand = new ToggleFavoritesCommand();
            WatchlistCommand = new ToggleWatchlistCommand();
        }

        public int ShowId { get; set; }
        /// <summary>
        /// The model of the series that is being displayed on the view.
        /// </summary>
        private SeriesModel seriesModel;
        public SeriesModel SeriesModel
        {
            get => seriesModel;
            private set => SetProperty(ref seriesModel, value);
        }
        /// <summary>
        /// The cast of the series being displayed.
        /// </summary>
        private CastModel castModel;
        public CastModel CastModel
        {
            get => castModel;
            private set => SetProperty(ref castModel, value);
        }
        /// <summary>
        /// All the episodes of the series
        /// </summary>
        private List<EpisodeList> episodeList;
        public List<EpisodeList> EpisodeList
        {
            get => episodeList;
            private set => SetProperty(ref episodeList, value);
        }
        /// <summary>
        /// Commands to add and remove from watchlist/favorites
        /// </summary>
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }

        /// <summary>
        /// Called when the corresponding page was navigated to. Loads the model and its corresponding data.
        /// </summary>
        /// <returns></returns>
        public async Task OnNavigatedAsync()
        {
            try
            {
                var service = Ioc.Default.GetRequiredService<MovieDBService>();
                SeriesModel = await service.GetSeriesModelAsync(ShowId);
                CastModel = await service.GetSeriesCastAsync(ShowId);
                EpisodeList = await service.GetEpisodeList(ShowId, SeriesModel.number_of_seasons);
            }
            catch
            {
                new ToastContentBuilder()
                    .AddText("An error occurred", hintMaxLines: 1)
                    .AddText("We ran into an unexpected problem.").Show();
            }
        }
        /// <summary>
        /// Navigates to the person page indicated by the id.
        /// </summary>
        /// <param name="personId"></param>
        public void NavigateToPersonPage(int personId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(personId);
        }

    }
    /// <summary>
    /// Selector used for the series datatemplates
    /// </summary>
    public class EpisodeItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SeasonTemplate { get; set; }
        public DataTemplate EpisodeTemplate { get; set; }

        /// <summary>
        /// Returns a <c>DataTemplate</c> based on the current item's type. Used for having different appearances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item.GetType() == typeof(EpisodeList)) return SeasonTemplate;

            return EpisodeTemplate;
        }

    }
}
