using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieWorld.ViewModels
{
    public class PersonDetailsViewModel : ObservableRecipient
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

        }
    }
}
