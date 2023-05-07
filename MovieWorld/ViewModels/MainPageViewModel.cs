using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using MovieWorld.Models;
using System.Collections.ObjectModel;
using MovieWorld.Services;
using MovieWorld.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Mail;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace MovieWorld.ViewModels
{
    public class MainPageViewModel : ObservableRecipient
    {
        public void NavigateToMovieDetails(int movieId)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<MovieDetailsViewModel>();
        }

    }
}
