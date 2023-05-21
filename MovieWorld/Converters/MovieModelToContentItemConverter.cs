using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class MovieModelToContentItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value switch
            {
                null => null,
                MovieModel model => new ContentListItem()
                {
                    id = model.id,
                    title = model.title,
                    name = model.title,
                    original_language = model.original_language,
                    original_title = model.original_title,
                    poster_path = model.poster_path,
                    vote_average = model.vote_average,
                    media_type = "movie",
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
