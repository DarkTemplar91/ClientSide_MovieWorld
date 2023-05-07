using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToMovieDetails(5054);
        }
    }
}
