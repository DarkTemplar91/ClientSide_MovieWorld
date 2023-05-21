using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    public class IsFavoriteToggledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int id = (int)value;

            var item = UserModel.Instance.Favorites?.Find(x => x.id == id);
            return item != null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
