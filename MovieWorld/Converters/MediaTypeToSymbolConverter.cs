using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    /// <summary>
    /// Used for the <c>AutoSuggestBox</c>'s auto-completion. Gives back a symbol based on media type 
    /// </summary>
    internal class MediaTypeToSymbolConverter : IValueConverter
    {
        /// <summary>
        /// Based on the type of media returned as a search result, it gives back the name of a Symbol, for the SymbolIcon to display
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var media_type = (string) value;
            return media_type switch
            {
                "movie" => "Video",
                "tv" => "GoToStart",
                "person" => "People",
                _ => "Placeholder"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
