﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        void GoBack();
        void Navigate<T>(object args = null) where T : ObservableRecipient;
    }
}