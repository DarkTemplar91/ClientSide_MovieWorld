using System;
using Windows.UI.Xaml.Data;
using MovieWorld.Models;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Converter class used to create label with the correct format for the Move and Series Views
    /// </summary>
    internal class NameLabelConverter : IValueConverter
    {
        /// <summary>
        /// Converts the <c>MovieModel</c> or <c>SeriesModel</c> object's name/title and release year to label text.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is null)
                return "";

            if (value is SeriesModel seriesModel)
            {
                return $"{seriesModel.name} {seriesModel.ReleaseYear}";
            }

            if (value is MovieModel movieModel)
            {
                return $"{movieModel.title} {movieModel.ReleaseYear}";
            }
            return string.Empty;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
