using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace MovieWorld.ViewModels
{
    public class SeriesDetailsViewModel : ObservableRecipient
    {
        public SeriesDetailsViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }
        private int showId;
        public int ShowId { get { return showId; } set { showId = value; } }
        private SeriesModel seriesModel;
        public SeriesModel SeriesModel
        {
            get { return seriesModel; }
            set { SetProperty(ref seriesModel, value); }
        }

        private CastModel castModel;
        public CastModel CastModel
        {
            get { return castModel; }
            set { SetProperty(ref castModel, value); }
        }

        private List<EpisodeList> episodeList;
        public List<EpisodeList> EpisodeList
        {
            get { return episodeList; }
            set { SetProperty(ref episodeList, value); }
        }

        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public async Task OnNavigatedAsync()
        {
            var service = new MovieDBService();
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
