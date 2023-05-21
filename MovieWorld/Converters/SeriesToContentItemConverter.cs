using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class SeriesToContentItemConverter : IValueConverter
    {
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
