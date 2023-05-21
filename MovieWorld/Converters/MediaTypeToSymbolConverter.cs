using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class MediaTypeToSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var media_type = (string) value;
            return media_type switch
            {
                "movie" => "Video",
                "tv" => "GoToStart",
                "person" => "People",
                _ => "Placeholder"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
