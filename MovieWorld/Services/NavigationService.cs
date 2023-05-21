using CommunityToolkit.Mvvm.ComponentModel;
using MovieWorld.ViewModels;
using MovieWorld.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> viewMapping = new()
        {
            [typeof(TrendingPageViewModel)] = typeof(MainPage),
            [typeof(MovieDetailsViewModel)] = typeof(MovieDetailsPage),
            [typeof(PersonDetailsViewModel)] = typeof(PersonDetailsPage),
            [typeof(SeriesDetailsViewModel)] = typeof(SeriesDetailsPage),
            [typeof(TrendingPageViewModel)] = typeof(TrendingPage),
            [typeof(SearchPageViewModel)] = typeof(SearchPage),
            [typeof(FavoritesPageViewModel)] = typeof(FavoritesPage),
            [typeof(WatchlistPageViewModel)] = typeof(WatchlistPage)
        };

        private readonly Frame frame;

        public NavigationService(Frame frame)
        {
            this.frame = frame;
        }

        public bool CanGoBack => this.frame.CanGoBack;

        public void GoBack(NavigationView rootNavigationView = null)
        {
            if (frame.CanGoBack)
            {
                var lastPageEntry = frame.BackStack[frame.BackStackDepth - 1];
                var lastPageType = lastPageEntry.SourcePageType;
                if (lastPageType != frame.CurrentSourcePageType && rootNavigationView is not null)
                {
                    NavigationViewItem navigationViewItem = null;

                    if (lastPageType == typeof(FavoritesPage))
                    {
                        navigationViewItem = rootNavigationView.MenuItems.ElementAt(1) as NavigationViewItem;
                    }
                    else if (lastPageType == typeof(WatchlistPage))
                    {
                        navigationViewItem = rootNavigationView.MenuItems.ElementAt(2) as NavigationViewItem;
                    }
                    else
                    {
                        navigationViewItem = rootNavigationView.MenuItems.ElementAt(0) as NavigationViewItem;
                    }
                    bool goBackLater = false;
                    if (navigationViewItem != null && navigationViewItem.IsSelected == false)
                    {
                        goBackLater = true;
                        navigationViewItem.IsSelected = true;
                    }
                    if (frame.CanGoBack && goBackLater)
                        frame.GoBack();
                }
                frame.GoBack();

            }
        }

        public void Navigate<T>(object args = null) where T : ObservableRecipient
        {
            this.frame.Navigate(this.viewMapping[typeof(T)], args);
        }
    }
}
