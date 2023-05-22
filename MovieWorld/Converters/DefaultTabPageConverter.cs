using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using MovieWorld.Models;

namespace MovieWorld.Converters
{
    internal class DefaultTabPageConverter : IValueConverter
    {
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
