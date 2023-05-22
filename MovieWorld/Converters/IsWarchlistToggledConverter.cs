﻿using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Class that converts the specified id to a toggled or not toggled state, based on watchlist items
    /// </summary>
    public class IsWatchlistToggledConverter : IValueConverter
    {
        /// <summary>
        /// Gives back a <c>bool</c> value, if the specified id is in the watchlist, it will return with <c>true</c>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int id = (int)value;

            var item = UserModel.Instance.Watchlist?.Find(x => x.id == id);
            return item != null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
