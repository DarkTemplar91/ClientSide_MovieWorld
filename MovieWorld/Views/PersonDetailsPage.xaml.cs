﻿using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class PersonDetailsPage : Page
    {
        public PersonDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.PersonId = (int)e.Parameter;
            ViewModel.OnNavigatedAsync();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var obj = e.ClickedItem;
            int id = -1;
            if (obj.GetType() == typeof(CreditCrew))
                id = ((CreditCrew)obj).id;
            else if (obj.GetType() == typeof(CreditCast))
                id = ((CreditCast)obj).id;
            else
                return;

            ViewModel.NavigateToMoviePage(id);
        }
    }
}
