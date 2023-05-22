using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Commands;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MovieWorld.ViewModels
{
    public class SeriesDetailsViewModel : ObservableRecipient
    {
        public SeriesDetailsViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
            FavoritesCommand = new ToggleFavoritesCommand();
            WatchlistCommand = new ToggleWatchlistCommand();
        }

        public int ShowId { get; set; }

        private SeriesModel seriesModel;
        public SeriesModel SeriesModel
        {
            get => seriesModel;
            set => SetProperty(ref seriesModel, value);
        }

        private CastModel castModel;
        public CastModel CastModel
        {
            get => castModel;
            set => SetProperty(ref castModel, value);
        }

        private List<EpisodeList> episodeList;
        public List<EpisodeList> EpisodeList
        {
            get => episodeList;
            set => SetProperty(ref episodeList, value);
        }

        public IAsyncRelayCommand ReloadTaskCommand { get; }
        public ToggleFavoritesCommand FavoritesCommand { get; }
        public ToggleWatchlistCommand WatchlistCommand { get; }

        public async Task OnNavigatedAsync()
        {
            var service = Ioc.Default.GetRequiredService<MovieDBService>();
            SeriesModel = await service.GetSeriesModelAsync(ShowId);
            CastModel = await service.GetSeriesCastAsync(ShowId);
            EpisodeList = await service.GetEpisodeList(ShowId, SeriesModel.number_of_seasons);

        }

        public void NavigateToPersonPage(int personId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<PersonDetailsViewModel>(personId);
        }

    }

    public class EpisodeItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SeasonTemplate { get; set; }
        public DataTemplate EpisodeTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item.GetType() == typeof(EpisodeList)) return SeasonTemplate;

            return EpisodeTemplate;
        }

    }
}
