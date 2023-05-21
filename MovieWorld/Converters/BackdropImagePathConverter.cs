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
            if (value is MovieModel model)
            {
                backdrop_path = model.backdrop_path;
            }
            else if (value is SeriesModel seriesModel)
            {
                backdrop_path = seriesModel.backdrop_path;
            }

            if (string.IsNullOrEmpty(backdrop_path))
                return "ms-appx:///Assets/headshot-placeholder.png";

            string baseUri = "https://image.tmdb.org/t/p/original";
            return $"{baseUri}/{backdrop_path.Trim('/')}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
