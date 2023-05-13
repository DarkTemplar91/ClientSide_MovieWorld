using MovieWorld.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.MovieId = (int)e.Parameter;
            ViewModel.OnNavigatedAsync();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var obj = e.ClickedItem;
            int id = -1;
            if (obj.GetType() == typeof(Crew))
                id = ((Crew)obj).id;
            else if (obj.GetType() == typeof(Cast))
                id = ((Cast)obj).id;
            else
                return;
            
            ViewModel.NavigateToPersonPage(id);
        }
    }
}
