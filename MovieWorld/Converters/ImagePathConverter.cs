using MovieWorld.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MovieWorld.Converters
{
    internal class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "ms-appx:///Assets/headshot-placeholder.png";

            string size = "w342";
            string poster_path = null;
            if (value is SeriesModel)
            {
                poster_path = (value as SeriesModel).poster_path;
                size = "w500";
            }
            else if (value is MovieModel)
            {
                poster_path = (value as MovieModel).poster_path;
                size = "w500";
            }
            else if (value is CreditCast)
            {
                poster_path = (value as CreditCast).poster_path;
                size = "w185";
            }
            else if (value is CreditCrew)
            {
                poster_path = (value as CreditCrew).poster_path;
                size = "w185";
            }
            else if (value is Cast)
            {
                poster_path = (value as Cast).profile_path;
                size = "w185";
            }
            else if (value is Crew)
            {
                poster_path = (value as Crew).profile_path;
                size = "w185";
            }

            else if (value is PersonModel)
            {
                poster_path = (value as PersonModel).profile_path;
                size = "w500";
            }
            else if (value is ContentListItem)
            {
                var model = value as ContentListItem;
                poster_path = model.poster_path;
                if (string.IsNullOrEmpty(poster_path))
                {
                    poster_path = model.profile_path;
                    size = "w185";
                }

            }
            else if (value is SearchResult)
            {
                var model = value as SearchResult;
                poster_path = model.poster_path;
                if (string.IsNullOrEmpty(poster_path))
                {
                    poster_path = model.profile_path;
                    size = "w185";
                }
            }

            if (string.IsNullOrEmpty(poster_path))
                return "ms-appx:///Assets/no_image_placeholder.png";

            string baseUri = $"https://image.tmdb.org/t/p/{size}";
            return string.Format("{0}/{1}", baseUri, poster_path.Trim('/'));


        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
