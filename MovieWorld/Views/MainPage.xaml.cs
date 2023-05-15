using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MovieWorld.Models;
using Newtonsoft.Json;
using Windows.UI.Xaml.Navigation;
using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MovieWorld.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Ioc.Default.ConfigureServices(new ServiceCollection().AddSingleton<INavigationService>(new NavigationService(contentFrame)).BuildServiceProvider());
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

            var selectedItem = (NavigationViewItem)args.SelectedItem;
            if (selectedItem != null)
            {
                string selectedItemTag = ((string)selectedItem.Tag);
                ViewModel.NavigateToNavItemPage(selectedItemTag);
            }

        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (contentFrame.CanGoBack)
            {
                contentFrame.GoBack();
            }
        }
    }
}
