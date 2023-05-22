using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Convert values to <c>Visibility</c>
    /// </summary>
    internal class VisibilityNullConverter : IValueConverter
    {
        /// <summary>
        /// Converts <c>null</c> values to <c>Visibility.Collapsed</c>. Otherwise, it stays visible.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value is null)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
