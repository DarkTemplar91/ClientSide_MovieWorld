using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using MovieWorld.Models;

namespace MovieWorld.Converters
{
    internal class CheckNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is null)
                return null;

            if (value is not CastModel)
                return null;

            var castModel = value as CastModel;

            if (parameter != null && parameter == "filteredCrew")
                return castModel.GetFilteredCrew;

            return castModel.cast;


        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
