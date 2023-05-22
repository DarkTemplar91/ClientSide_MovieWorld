using CommunityToolkit.Mvvm.ComponentModel;
using MovieWorld.ViewModels;
using MovieWorld.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Services
{
    /// <summary>
    /// <c>NavigationService</c> implements our <c>INavigationService</c> interface.
    /// This class is used for basic navigation between our pages.
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// A Dictionary for the ViewModel-View relation
        /// </summary>
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

        /// <summary>
        /// Public constructor for the NavigationService.
        /// </summary>
        /// <param name="frame">The root frame of our application. Used by the NavigationView to switch between views</param>
        public NavigationService(Frame frame)
        {
            this.frame = frame;
        }

        /// <summary>
        /// Property indicating if we can traverse backwards from the current frame
        /// </summary>
        public bool CanGoBack => this.frame.CanGoBack;
        /// <summary>
        /// Goes back to the previous frame in the stack
        /// </summary>
        /// <param name="rootNavigationView">The <c>NavigationView</c> used in our main page</param>
        public void GoBack(NavigationView rootNavigationView = null)
        {
            if (frame.CanGoBack)
            {
                var lastPageEntry = frame.BackStack[frame.BackStackDepth - 1];
                var lastPageType = lastPageEntry.SourcePageType;
                if (lastPageType != frame.CurrentSourcePageType && rootNavigationView is not null)
                {
                    NavigationViewItem navigationViewItem;

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
                    if (navigationViewItem is {IsSelected: false})
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
        /// <summary>
        /// Navigates to the page specified
        /// </summary>
        /// <typeparam name="T">The viewmodels type</typeparam>
        /// <param name="args">Additional arguments for the navigation</param>
        public void Navigate<T>(object args = null) where T : ObservableRecipient
        {
            this.frame.Navigate(this.viewMapping[typeof(T)], args);
        }
    }
}
