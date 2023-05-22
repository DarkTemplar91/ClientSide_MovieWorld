using CommunityToolkit.Mvvm.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Services
{
    /// <summary>
    /// Interface <c>INavigationService</c> defines a service used for navigating between frames in a UWP app
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Property <c>CanGoBack</c> indicates whether we can navigate back to the previous frame
        /// </summary>
        bool CanGoBack { get; }
        /// <summary>
        /// Method <c>GoBack</c> navigates back to the previous frame.
        /// </summary>
        /// <param name="rootNavigationView">the root NavigationView used in our application</param>
        void GoBack(NavigationView rootNavigationView = null);
        /// <summary>
        /// Method <c>Navigate</c> navigates to the ViewModel's corresponding View.
        /// </summary>
        /// <typeparam name="T">the view's corresponding view model where we wish to navigate</typeparam>
        /// <param name="args">additional arguments passed when navigating</param>
        void Navigate<T>(object args = null) where T : ObservableRecipient;
    }
}
