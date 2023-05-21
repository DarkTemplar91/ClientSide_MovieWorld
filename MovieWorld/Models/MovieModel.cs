
using System;
using System.Linq;

namespace MovieWorld.Models
{
    public class MovieModel
    {
        public string backdrop_path { get; set; }
        public Genre[] genres { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public int runtime { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        public string ReleaseYear => "(" + release_date.Substring(0, 4) + ")";

        public string VoteCountString => $"({vote_count})";

        public float VoteAverageOnScale => vote_average / 2;

        public string DateString
        {
            get
            {
                DateTime asDate = DateTime.ParseExact(release_date,
                   "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                return asDate.ToString("dd/MM/yyyy");
            }
        }
        public string IMDb_ID => $"https://www.imdb.com/title/{imdb_id}/";

        public string AllGenres
        {
            get
            {
                return genres.Select(s => s.name + ", ").Aggregate((s, q) => s + q).TrimEnd(' ').TrimEnd(',');
            }
        }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
