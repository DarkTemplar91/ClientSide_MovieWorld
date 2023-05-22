using System;
using MovieWorld.Models;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.Notifications;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavoritesPage : Page
    {
        public FavoritesPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// If an item was clicked, it will try to navigate to the content page via the content id.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ContentListItem contentListItem = e.ClickedItem as ContentListItem; 
            ViewModel.NavigateToDetailsPage(contentListItem);
        }
    }

    internal class AppNotificationBuilder
    {
    }
}
