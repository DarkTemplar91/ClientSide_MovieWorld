using Windows.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MovieWorld.Services;
using System.Linq;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System;
using MovieWorld.Models;
using Windows.UI.Xaml.Input;
using Windows.Networking.BackgroundTransfer;
using MovieWorld.ViewModels;
using System.Reflection;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string queryText = "";

        public MainPage()
        {
            this.InitializeComponent();
            Ioc.Default.ConfigureServices(new ServiceCollection().AddSingleton<INavigationService>(new NavigationService(contentFrame)).BuildServiceProvider());
            NavView.SelectedItem = NavView.MenuItems.ElementAt(0);
            if (contentFrame.CanGoBack)
                contentFrame.GoBack();
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
            var navigationService = Ioc.Default.GetRequiredService<INavigationService>();
            if(navigationService.CanGoBack)
            {
                navigationService.GoBack(NavView);
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
            if (string.IsNullOrEmpty(controlsSearchBox.Text) != true)
            {
                if (queryText == controlsSearchBox.Text)
                    return;
            }
            queryText = controlsSearchBox.Text;

            if (args.ChosenSuggestion != null)
            {
                var searchResult = args.ChosenSuggestion as SearchResult;
                ViewModel.NavigateToDetailsPage(searchResult);

            }
            else
            {
                if (string.IsNullOrEmpty(args.QueryText))
                    return;

                ViewModel.NavigateToSearchPage(args.QueryText);
            }
        }

        private void controlsSearchBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = (args.SelectedItem as SearchResult).SearchName;
        }

        private void CtrlF_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            controlsSearchBox.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }
    }
}
