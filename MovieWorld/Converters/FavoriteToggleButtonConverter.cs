using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class FavoriteToggleButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool ischecked = (bool)value;

            string content = null;

            if (ischecked)
            {
                content = "\xE735";
            }
            else
            {
                content = "\xE734";
            }

            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
