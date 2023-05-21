using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class RuntimeStringConverter : IValueConverter
    {
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
