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
    public sealed partial class PersonDetailsPage : Page
    {
        public PersonDetailsPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Called when the page was navigated to. Calls the view model's own method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null) ViewModel.PersonId = (int) e.Parameter;
            ViewModel?.OnNavigatedAsync();
        }

        /// <summary>
        /// If an item was selected tries to load the content page,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var obj = e.ClickedItem;
            if (obj.GetType() == typeof(CreditCrew))
                ViewModel.NavigateToMoviePage(((CreditCrew) obj).id);
            else if (obj.GetType() == typeof(CreditCast))
                ViewModel.NavigateToMoviePage(((CreditCast) obj).id);

        }
    }
}
