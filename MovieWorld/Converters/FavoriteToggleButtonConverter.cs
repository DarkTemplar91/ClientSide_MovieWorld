using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Converter class used for assigning different symbols for the toggle button's states
    /// </summary>
    internal class FavoriteToggleButtonConverter : IValueConverter
    {
        /// <summary>
        /// Return with different symbol values depending on the on/off state of the favorites toggle button
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
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
