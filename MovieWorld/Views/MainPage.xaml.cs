using Windows.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MovieWorld.Services;
using System.Linq;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System;
using MovieWorld.Models;

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
            NavView.SelectedItem = NavView.MenuItems.ElementAt(0);
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

        private async void controlsSearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if ( args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                ViewModel.RefreshSearchResults(sender.Text);
            }
        }

        private void controlsSearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                var searchResult = args.ChosenSuggestion as SearchResult;
                ViewModel.NavigateToDetailsPage(searchResult);

            }
            else
            {
                ViewModel.NavigateToSearchPage(args.QueryText);
            }
        }

        private void controlsSearchBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = (args.SelectedItem as SearchResult).SearchName;
        }
    }
}
