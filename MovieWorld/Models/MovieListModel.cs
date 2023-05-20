using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MovieWorld.Models
{
    public class ContentGroup
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<ContentListItem> Content { get; set; }
    }

    public class ContentList
    {
        public int page { get; set; }
        public ContentListItem[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class ContentListItem
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string profile_path { get; set; }
        public string media_type { get; set; }
        public int[] genre_ids { get; set; }
        public float popularity { get; set; }
        public string release_date { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        public string Name
        {
            get
            {
                if (title != null)
                    return title;

                return name;
            }
        }

        public string PosterImagePath
        {
            get
            {
                if (poster_path is null && profile_path is null)
                    return "ms-appx:///Assets/headshot-placeholder.png";


                string baseUri = $"https://image.tmdb.org/t/p/w500";
                if (poster_path is not null)
                {
                    return string.Format("{0}/{1}", baseUri, poster_path.Trim('/'));
                }

                return string.Format("{0}/{1}", baseUri, profile_path.Trim('/'));
            }
        }

        public string VoteString
        {
            get
            {
                return $"{string.Format("{0:F1}", vote_average)}/10";
            }
        }

        public string ShowIfNotPerson
        {
            get
            {
                return  media_type == "person" ? "Collapsed" : "Visible";
            }
        }

    }

}
