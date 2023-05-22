using Microsoft.Toolkit.Uwp.Notifications;
using MovieWorld.Models;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WatchlistPage : Page
    {
        public WatchlistPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When an item is clicked it tries to navigate to the corresponding page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {

            ContentListItem contentListItem = e.ClickedItem as ContentListItem;
            ViewModel.NavigateToDetailsPage(contentListItem);

        }
    }
}
