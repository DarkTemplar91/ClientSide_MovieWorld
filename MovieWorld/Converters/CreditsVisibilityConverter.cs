using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using MovieWorld.Models;

namespace MovieWorld.Converters
{
    internal class CreditsVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var model = value as PersonCreditsModel;
            if (parameter == "CastCredit")
            {
                return model?.cast.Length == 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            if (parameter == "CrewCredit")
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
