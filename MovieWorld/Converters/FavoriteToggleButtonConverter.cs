using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class FavoriteToggleButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isChecked = (bool)value;

            var content = isChecked ? "\xE735" : "\xE734";

            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
