using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using MovieWorld.Models;

namespace MovieWorld.Converters
{
    internal class NameLabelConverter : IValueConverter
    {
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
