using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.UI.Converters;

namespace MovieWorld.ViewModels
{
    public class PersonDetailsViewModel : ObservableRecipient
    {
        private int personId;
        public int PersonId
        {
            get => personId;
            set => SetProperty(ref personId, value);
        }
        private PersonModel personModel;
        public PersonModel PersonModel
        {
            get => personModel;
            set => SetProperty(ref personModel, value);
        }

        private PersonCreditsModel credits;
        public PersonCreditsModel Credits
        {
            get => credits;
            set => SetProperty(ref credits, value);
        }

        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public PersonDetailsViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }

        public async Task OnNavigatedAsync()
        {
            var service = Ioc.Default.GetRequiredService<MovieDBService>();
            PersonModel = await service.GetPersonDetailsAsync(PersonId);
            Credits = await service.GetPersonCredits(PersonId);
        }

        public void NavigateToMoviePage(int movieId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>(movieId);
        }

    }
}
