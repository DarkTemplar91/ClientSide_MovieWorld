using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using MovieWorld.Models;

namespace MovieWorld.Converters
{
    /// <summary>
    /// This class uses the person's credit model to determine whether the given element should be shown or not
    /// </summary>
    internal class CreditsVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts to the <c>Visibility</c> object based on the number of credits they have as a cast or crew member.
        /// </summary>
        /// <param name="value"><c>PersonCreditsModel</c></param>
        /// <param name="targetType"><c>Visibility</c></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>With the visibility determined</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var model = value as PersonCreditsModel;
            if ((string) parameter == "CastCredit")
            {
                return model?.cast.Length == 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            if ((string) parameter == "CrewCredit")
            {
                return model?.crew.Length == 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
