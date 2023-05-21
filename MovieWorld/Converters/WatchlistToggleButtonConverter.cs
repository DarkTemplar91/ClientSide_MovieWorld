using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class WatchlistToggleButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool ischecked = (bool)value;

            string content = null;

            if (ischecked)
            {
                content = "\xE9D5";
            }
            else
            {
                content = "\xE8FD";
            }

            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
