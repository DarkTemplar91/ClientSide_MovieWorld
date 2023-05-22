using Microsoft.Toolkit.Uwp.Notifications;
using MovieWorld.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Called when the page was navigated to. Calls the view model' own method.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Keyword = (string)e.Parameter;
            ViewModel.OnNavigatedAsync();
        }

        /// <summary>
        /// When an item was clicked, it tries to navigate to the content's page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var searchResult = (SearchResult) e.ClickedItem;
            ViewModel.NavigateToDetailsPage(searchResult);

        }

        /// <summary>
        /// Refreshes the search results if the text changed in the <c>AutoSuggestBox</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ViewModel.Keyword = args.QueryText;
            ViewModel.RefreshSearchResults(args.QueryText);
        }
    }
}
