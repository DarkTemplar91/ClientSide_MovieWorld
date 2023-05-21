using CommunityToolkit.Mvvm.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        void GoBack(NavigationView rootNavigationView = null);
        void Navigate<T>(object args = null) where T : ObservableRecipient;
    }
}
