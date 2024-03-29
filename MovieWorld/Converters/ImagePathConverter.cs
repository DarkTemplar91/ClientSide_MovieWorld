﻿using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Class used for converting the images to the correct format
    /// </summary>
    internal class ImagePathConverter : IValueConverter
    {
        /// <summary>
        /// Depending on the type of object and its use-case, it converts the
        /// <c>image_path</c> or <c>poster_path</c> to the correct format.
        /// </summary>
        /// <param name="value">The model</param>
        /// <param name="targetType"><c>ImageSource URI</c></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            if (value == null)
                return XamlBindingHelper.ConvertValue(targetType, "ms-appx:///Assets/headshot-placeholder.png");

            string size = "w342";
            string poster_path = null;
            if (value is SeriesModel seriesModel)
            {
                poster_path = seriesModel.poster_path;
                size = "w500";
            }
            else if (value is MovieModel movieModel)
            {
                poster_path = movieModel.poster_path;
                size = "w500";
            }
            else if (value is CreditCast creditCast)
            {
                poster_path = creditCast.poster_path;
                size = "w185";
            }
            else if (value is CreditCrew creditCrew)
            {
                poster_path = creditCrew.poster_path;
                size = "w185";
            }
            else if (value is Cast cast)
            {
                poster_path = cast.profile_path;
                size = "w185";
            }
            else if (value is Crew crew)
            {
                poster_path = crew.profile_path;
                size = "w185";
            }

            else if (value is PersonModel personModel)
            {
                poster_path = personModel.profile_path;
                size = "w500";
            }
            else if (value is ContentListItem item)
            {
                poster_path = item.poster_path;
                if (string.IsNullOrEmpty(poster_path))
                {
                    poster_path = item.profile_path;
                    size = "w185";
                }

            }
            else if (value is SearchResult model)
            {
                poster_path = model.poster_path;
                if (string.IsNullOrEmpty(poster_path))
                {
                    poster_path = model.profile_path;
                    size = "w185";
                }
            }

            if (string.IsNullOrEmpty(poster_path))
                return XamlBindingHelper.ConvertValue(targetType, "ms-appx:///Assets/no_image_placeholder.png");

            string baseUri = $"https://image.tmdb.org/t/p/{size}";
            return XamlBindingHelper.ConvertValue(targetType, $"{baseUri}/{poster_path.Trim('/')}");


        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
