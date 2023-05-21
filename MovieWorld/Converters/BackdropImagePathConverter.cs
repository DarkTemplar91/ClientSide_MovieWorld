using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class BackdropImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string backdrop_path = null;
            if (value is MovieModel)
            {
                backdrop_path = (value as MovieModel).backdrop_path;
            }
            else if (value is SeriesModel)
            {
                backdrop_path = (value as SeriesModel).backdrop_path;
            }

            if (string.IsNullOrEmpty(backdrop_path))
                return "ms-appx:///Assets/headshot-placeholder.png";

            string baseUri = $"https://image.tmdb.org/t/p/original";
            return string.Format("{0}/{1}", baseUri, backdrop_path.Trim('/'));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
