using CommunityToolkit.Mvvm.ComponentModel;
using MovieWorld.ViewModels;
using MovieWorld.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> viewMapping = new()
        {
            [typeof(MainPageViewModel)] = typeof(MainPage),
            [typeof(MovieDetailsViewModel)] = typeof(MovieDetailsPage),
            [typeof(PersonDetailsViewModel)] = typeof(PersonDetailsPage),
            [typeof(SeriesDetailsViewModel)] = typeof(SeriesDetailsPage),
            // Other viewmodel types...
        };

        private readonly Frame frame;

        public NavigationService(Frame frame)
        {
            this.frame = frame;
        }

        public bool CanGoBack => this.frame.CanGoBack;

        public void GoBack()
        {
            this.frame.GoBack();
        }

        public void Navigate<T>(object args = null) where T : ObservableRecipient
        {
            this.frame.Navigate(this.viewMapping[typeof(T)], args);
        }
    }
}
