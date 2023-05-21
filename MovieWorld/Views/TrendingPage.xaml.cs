using MovieWorld.Models;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TrendingPage : Page
    {
        public TrendingPage()
        {
            this.InitializeComponent();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movieModel = (ContentListItem)e.ClickedItem;
            ViewModel.NavigateToDetailsPage(movieModel);
        }
    }

}
