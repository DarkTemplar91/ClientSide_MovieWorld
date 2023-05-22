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
    public sealed partial class MovieDetailsPage : Page
    {
        public MovieDetailsPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Called when the page was navigated to, calls the view model's own method.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null) ViewModel.MovieId = (int) e.Parameter;
            ViewModel?.OnNavigatedAsync();
        }

        /// <summary>
        /// If an item was clicked, it will try to navigate to its corresponding page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {

            var obj = e.ClickedItem;
            int id;
            if (obj.GetType() == typeof(Crew))
                id = ((Crew) obj).id;
            else if (obj.GetType() == typeof(Cast))
                id = ((Cast) obj).id;
            else
                return;

            ViewModel.NavigateToPersonPage(id);

        }
    }
}
