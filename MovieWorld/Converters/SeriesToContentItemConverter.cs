using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class SeriesToContentItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            var model = value as SeriesModel;
            return new ContentListItem()
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
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
