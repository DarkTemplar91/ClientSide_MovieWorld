using MovieWorld.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class FavoriteToggleCommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool ischecked = (bool)value;


            if (ischecked)
            {
                return new AddToWatchlistCommand();
            }

            return new RemoveFromWatchlistCommand();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
