using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Convert the runtime of a movie or show to the proper string
    /// </summary>
    internal class RuntimeStringConverter : IValueConverter
    {
        /// <summary>
        /// Convert the <c>runtime</c> to a string with the format of {00}h {00}m"
        /// </summary>
        /// <example>
        /// For Example:
        /// A value of <value>95</value> would be "1h 35m"
        /// </example>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var runtime = (int?) value;
            if (runtime is null)
                return "0h 0m";

            return runtime >= 60 ? $"{runtime / 60}h {runtime % 60}m" : $"{runtime}m";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
