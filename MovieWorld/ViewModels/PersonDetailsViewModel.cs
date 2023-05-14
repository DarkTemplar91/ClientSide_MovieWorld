using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieWorld.ViewModels
{
    public class PersonDetailsViewModel : ObservableRecipient, INotifyPropertyChanged
    {
        private int personId;
        public int PersonId
        {
            get { return personId; }
            set { SetProperty(ref personId, value); }
        }
        private PersonModel personModel;
        public PersonModel PersonModel
        {
            get { return personModel; }
            set { SetProperty(ref personModel, value); }
        }

        private PersonCreditsModel credits;
        public PersonCreditsModel Credits
        {
            get { return credits; }
            set { SetProperty(ref credits, value); }
        }

        public ICommand ReloadTaskCommand { get; }

        public PersonDetailsViewModel()
        {
            ReloadTaskCommand = new RelayCommand(OnNavigatedAsync);
        }

        public async void OnNavigatedAsync()
        {
            //TODO: Create a singleton?
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

        public int DefaultTabPage
        {
            get
            {
                return personModel?.known_for_department == "Acting" ? 0 : 1;
            }
        }

        public string ShowDeathDate
        {
            get
            {
                return showDeathDate;
            }
            set
            {
                SetProperty(ref showDeathDate, value);
            }
        }

        public string ShowActingCredit
        {
            get
            {
                return showActingCredit;
            }

            set
            {
                SetProperty(ref showActingCredit, value);
            }
        }

        public string ShowCrewCredit
        {
            get
            {
                return showCrewCredit;
            }
            set
            {
                SetProperty(ref showCrewCredit, value);
            }
        }

        public void SetContentVisibility()
        {

            if (Credits?.cast.Length == 0)
            {
                ShowActingCredit = "Collapsed";
            }
            else
            {
                ShowActingCredit = "Visible";
            }

            if (Credits?.crew.Length == 0)
            {
                ShowCrewCredit = "Collapsed";
            }
            else
            {
                ShowCrewCredit = "Visible";
            }

            if(PersonModel?.deathday is null)
            {
                ShowDeathDate = "Collapsed";
            }
            else
            {
                ShowDeathDate = "Visible";
            }

        }


    }
}
