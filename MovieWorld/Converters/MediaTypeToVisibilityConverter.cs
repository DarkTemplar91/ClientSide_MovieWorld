using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Converts content's <c>media_type</c> to <c>Visibility</c>
    /// </summary>
    internal class MediaTypeToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convert to <c>Visibility</c> based on the content's media_type.
        /// If it is a <value>person</value>, it will not be shown.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var media_type = (string)value;
            return media_type == "person" ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
