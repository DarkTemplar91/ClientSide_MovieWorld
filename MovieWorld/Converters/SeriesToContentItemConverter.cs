using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Class that converts a <c>SeriesModel</c> to <c>ContentListItem</c>.
    /// Mainly used by the SeriesDetailsPage, so we can reuse the commands for the toggle button.
    /// Works better than explicit/implicit operators.
    /// </summary>
    internal class SeriesToContentItemConverter : IValueConverter
    {
        /// <summary>
        /// Converts the <c>SeriesModel</c> to <c>ContentListItem</c>. It copies all the shared data fields.
        /// </summary>
        /// <param name="value">The <c>MovieModel</c> that needs to be converted</param>
        /// <param name="targetType"><c>ContentListItem</c></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value switch
            {
                null => null,
                SeriesModel model => new ContentListItem()
                {
                    id = model.id,
                    title = model.name,
                    name = model.name,
                    original_language = model.original_language,
                    original_title = model.original_name,
                    poster_path = model.poster_path,
                    vote_average = model.vote_average,
                    media_type = "tv",
                    overview = model.overview,
                },
                _ => null
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
