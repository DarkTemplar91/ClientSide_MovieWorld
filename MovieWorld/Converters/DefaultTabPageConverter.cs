using System;
using Windows.UI.Xaml.Data;
using MovieWorld.Models;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Used to determine the default tab page for the person details page. (Cast or Crew)
    /// </summary>
    internal class DefaultTabPageConverter : IValueConverter
    {
        /// <summary>
        /// Depending on the person's main department, it return the valid tab page
        /// </summary>
        /// <param name="value"><c>PersonModel</c></param>
        /// <param name="targetType"><c>int</c></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>With an <c>int</c> tabId</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var model = value as PersonModel;
            if (model is null)
                return 0;

            return model.known_for_department == "Acting" ? 0 : 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
