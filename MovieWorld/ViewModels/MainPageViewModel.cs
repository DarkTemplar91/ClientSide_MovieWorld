using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using MovieWorld.Models;
using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            ReloadTaskCommand = new AsyncRelayCommand(OnNavigatedAsync);
        }

        public ObservableCollection<ContentGroup> RecommendedContent { get; set; } = new ObservableCollection<ContentGroup>();


        public IAsyncRelayCommand ReloadTaskCommand { get; }

        public async Task OnNavigatedAsync()
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<TrendingPageViewModel>();
        }

        public void NavigateToNavItemPage(string selectedItemTag)
        {
            if (selectedItemTag == "x:home")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<TrendingPageViewModel>();
            /*else if (selectedItemTag == "favorites")
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<SeriesDetailsViewModel>(model.id);*/
        }
    }
}
