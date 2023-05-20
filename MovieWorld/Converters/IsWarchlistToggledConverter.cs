using MovieWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    public class IsWarchlistToggledConvereter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int id = (int)value;

            var item = UserModel.Instance.Watchlist?.Find(x => x.id == id);
            return item != null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
