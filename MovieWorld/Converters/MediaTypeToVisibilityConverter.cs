﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class MediaTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var media_type = (string)value;
            return media_type == "person" ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}