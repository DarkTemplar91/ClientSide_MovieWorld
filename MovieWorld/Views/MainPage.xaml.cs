using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Uwp.Notifications;
using MovieWorld.Models;
using MovieWorld.Services;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string queryText = "";

        /// <summary>
        /// Constructor the adds the Navigation and MoveDB service to the IoC container, and select the 
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            Ioc.Default.ConfigureServices(new ServiceCollection().AddSingleton<INavigationService>(new NavigationService(ContentFrame))
                .AddSingleton<MovieDBService>().BuildServiceProvider());
            NavView.SelectedItem = NavView.MenuItems.ElementAt(0);
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }

        /// <summary>
        /// Event handler for the navigation items selection changed event. Navigates to the given page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavigationView_SelectionChanged(NavigationView sender,
            NavigationViewSelectionChangedEventArgs args)
        {

            var selectedItem = (NavigationViewItem) args.SelectedItem;
            if (selectedItem != null)
            {
                string selectedItemTag = ((string) selectedItem.Tag);
                ViewModel.NavigateToNavItemPage(selectedItemTag);
            }


        }

        /// <summary>
        /// Event handler for the back request. Traverses back in the frame stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            var navigationService = Ioc.Default.GetRequiredService<INavigationService>();
            if (navigationService.CanGoBack)
            {
                navigationService.GoBack(NavView);
            }
        }
        /// <summary>
        /// Called when the text is changed in the <c>AutoSuggestBox</c>. Refreshes search results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void ControlsSearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                await ViewModel.RefreshSearchResults(sender.Text);
            }
        }

        private void ControlsSearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (string.IsNullOrEmpty(ControlsSearchBox.Text) != true)
            {
                if (queryText == ControlsSearchBox.Text)
                    return;
            }
            queryText = ControlsSearchBox.Text;

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
        /// <summary>
        /// If a content item was chosen, fill out the box with the name of the content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ControlsSearchBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = ((SearchResult) args.SelectedItem).SearchName;
        }
        /// <summary>
        /// Button accelerator. When CTRL+F is pressed, focuses the <c>AutoSuggestBox</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CtrlF_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            ControlsSearchBox.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }
    }
}
