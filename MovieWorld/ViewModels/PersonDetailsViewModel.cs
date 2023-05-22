using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace MovieWorld.ViewModels
{
    /// <summary>
    /// View Model for the Person model
    /// </summary>
    public class PersonDetailsViewModel : ObservableRecipient
    {
        /// <summary>
        /// Id of the person displayed in the view
        /// </summary>
        private int personId;
        public int PersonId
        {
            get => personId;
            set => SetProperty(ref personId, value);
        }
        /// <summary>
        /// Model of the person displayed in the view
        /// </summary>
        private PersonModel personModel;
        public PersonModel PersonModel
        {
            get => personModel;
            private set => SetProperty(ref personModel, value);
        }
        /// <summary>
        /// The credits of the person
        /// </summary>
        private PersonCreditsModel credits;
        public PersonCreditsModel Credits
        {
            get => credits;
            private set => SetProperty(ref credits, value);
        }
        /// <summary>
        /// Called when the corresponding page was navigated to.
        /// Loads the person displayed and their credits.
        /// </summary>
        /// <returns></returns>
        public async Task OnNavigatedAsync()
        {
            try
            {
                var service = Ioc.Default.GetRequiredService<MovieDBService>();
                PersonModel = await service.GetPersonDetailsAsync(PersonId);
                Credits = await service.GetPersonCredits(PersonId);
            }
            catch(Exception e)
            {
                new ToastContentBuilder()
                    .AddText("An error occurred")
                    .AddText("We ran into an unexpected problem.")
                    .AddText(e.Message).Show();
            }
            
        }
        /// <summary>
        /// Navigates to the selected movie's details page
        /// </summary>
        /// <param name="movieId"></param>
        public void NavigateToMoviePage(int movieId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>(movieId);
        }

    }
}
