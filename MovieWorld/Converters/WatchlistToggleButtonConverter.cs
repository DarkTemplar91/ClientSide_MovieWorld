using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class WatchlistToggleButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isChecked = (bool)value;

            var content = isChecked ? "\xE9D5" : "\xE8FD";

            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
