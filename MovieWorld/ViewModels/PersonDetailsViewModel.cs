using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System.ComponentModel;
using System.Threading.Tasks;

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
            var service = new MovieDBService();
            PersonModel = await service.GetPersonDetailsAsync(PersonId);
            Credits = await service.GetPersonCredits(PersonId);
            SetContentVisibility();

        }

        private string showDeathDate = "Visible";
        private string showActingCredit = "Visible";
        private string showCrewCredit = "Visible";

        public void NavigateToMoviePage(int movieId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>(movieId);
        }

        public int DefaultTabPage => personModel?.known_for_department == "Acting" ? 0 : 1;

        public string ShowDeathDate
        {
            get => showDeathDate;
            set => SetProperty(ref showDeathDate, value);
        }

        public string ShowActingCredit
        {
            get => showActingCredit;

            set => SetProperty(ref showActingCredit, value);
        }

        public string ShowCrewCredit
        {
            get => showCrewCredit;
            set => SetProperty(ref showCrewCredit, value);
        }

        public void SetContentVisibility()
        {

            ShowActingCredit = Credits?.cast.Length == 0 ? "Collapsed" : "Visible";

            ShowCrewCredit = Credits?.crew.Length == 0 ? "Collapsed" : "Visible";

            ShowDeathDate = PersonModel?.deathday is null ? "Collapsed" : "Visible";

        }


    }
}
