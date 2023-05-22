using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace MovieWorld.Converters
{
    /// <summary>
    /// This class converts the backdrop image of a model to the valid format.
    /// </summary>
    internal class BackdropImagePathConverter : IValueConverter
    {
        /// <summary>
        /// This method converts the <c>backdrop_path</c> of the model to the correct URL. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if( value is null)
                return XamlBindingHelper.ConvertValue(typeof(ImageSource), "ms-appx:///Assets/headshot-placeholder.png");

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
                return XamlBindingHelper.ConvertValue(typeof(ImageSource), "ms-appx:///Assets/headshot-placeholder.png");

            string baseUri = "https://image.tmdb.org/t/p/original";
            return XamlBindingHelper.ConvertValue(typeof(ImageSource), $"{baseUri}/{backdrop_path.Trim('/')}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
