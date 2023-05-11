using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MovieWorld.Models
{


    public class MovieList
    {
        public int page { get; set; }
        public MovieListResult[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class MovieListResult
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string media_type { get; set; }
        public int[] genre_ids { get; set; }
        public float popularity { get; set; }
        public string release_date { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        public string PosterImagePath
        {
            get
            {
                string baseUri = $"https://image.tmdb.org/t/p/w500";
                return string.Format("{0}/{1}", baseUri, poster_path.Trim('/'));
            }
        }

        public string VoteString
        {
            get
            {
                return $"{string.Format("{0:F1}", vote_average)}/10";
            }
        }
    }

}
