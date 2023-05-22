
using System;
using System.Linq;

namespace MovieWorld.Models
{
    /// <summary>
    /// The model of the movie. Contains all the most important information about the movie, that we will be displaying
    /// </summary>
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

        /// <summary>
        /// Returns with the release year encompassed in brackets
        /// </summary>
        public string ReleaseYear => string.IsNullOrEmpty(release_date) ? "" : "(" + release_date.Substring(0, 4) + ")";
        /// <summary>
        /// The vote count represented as a string, surround id with brackets
        /// </summary>
        public string VoteCountString => $"({vote_count})";
        /// <summary>
        /// The vote value on a five-star based rating system
        /// </summary>
        public float VoteAverageOnScale => vote_average / 2;
        /// <summary>
        /// The date string of the release year formatted
        /// </summary>
        public string DateString
        {
            get
            {
                if (string.IsNullOrEmpty(release_date))
                    return "";

                DateTime asDate = DateTime.ParseExact(release_date,
                   "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                return asDate.ToString("dd/MM/yyyy");
            }
        }
        /// <summary>
        /// The IMDb URL of the Movie
        /// </summary>
        public string IMDb_ID => $"https://www.imdb.com/title/{imdb_id}/";

        /// <summary>
        /// All the genres as a string
        /// </summary>
        public string AllGenres
        {
            get
            {
                if (genres is null || genres.Length == 0)
                    return "";
                return genres.Select(s => s.name + ", ").Aggregate((s, q) => s + q).TrimEnd(' ').TrimEnd(',');
            }
        }
    }
    /// <summary>
    /// Represents a Genre
    /// </summary>
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
