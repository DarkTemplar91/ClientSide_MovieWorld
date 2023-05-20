using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
