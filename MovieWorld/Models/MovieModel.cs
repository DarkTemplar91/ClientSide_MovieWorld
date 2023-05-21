
using System;
using System.Linq;

namespace MovieWorld.Models
{
    public class MovieModel
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public int runtime { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        public string ReleaseYear
        {
            get
            {
                return "(" + release_date.Substring(0, 4) + ")";
            }
        }
        public string VoteCountString
        {
            get
            {
                return $"({vote_count})";
            }
        }
        public float VoteAvarageOnScale
        {
            get
            {
                return vote_average / 2;
            }
        }
        public string DateString
        {
            get
            {
                DateTime asDate = DateTime.ParseExact(release_date,
                   "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                return asDate.ToString("dd/MM/yyyy");
            }
        }
        public string RuntimeString
        {
            get
            {
                if (runtime >= 60)
                    return $"{runtime / 60}h {runtime % 60}m";

                return $"{runtime}m";
            }
        }
        public string IMDb_ID
        {
            get
            {
                return $"https://www.imdb.com/title/{imdb_id}/";
            }
        }

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
