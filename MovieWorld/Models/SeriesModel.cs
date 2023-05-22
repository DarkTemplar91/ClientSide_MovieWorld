using System;
using System.Linq;

namespace MovieWorld.Models
{
    /// <summary>
    /// Model that represents a TV Show. Contains most of the important information about a series.
    /// </summary>
    public class SeriesModel
    {
        public string backdrop_path { get; set; }
        public string first_air_date { get; set; }
        public Genre[] genres { get; set; }
        public Created_By[] created_by { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int number_of_seasons { get; set; }
        public string original_language { get; set; }
        public string original_name { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string tagline { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        /// <summary>
        /// Returns with the release year encompassed in brackets
        /// </summary>
        public string ReleaseYear => "(" + first_air_date.Substring(0, 4) + ")";
        /// <summary>
        /// The vote count represented as a string, surrounded with brackets
        /// </summary>
        public string VoteCountString => $"({vote_count})";

        /// <summary>
        /// The vote value on a five-star based rating system
        /// </summary>
        public float VoteAverageOnScale => vote_average / 2;

        /// <summary>
        /// All the genres as a string
        /// </summary>
        public string AllGenres
        {
            get
            {
                return genres.Select(s => s.name + ", ").Aggregate((s, q) => s + q).TrimEnd(' ').TrimEnd(',');
            }
        }
    }
    /// <summary>
    /// The list of episodes in a series.
    /// </summary>
    public class EpisodeList
    {
        public Episode[] episodes { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int season_number { get; set; }
    }

    /// <summary>
    /// Represents an episode of a show.
    /// </summary>
    public class Episode
    {
        public string air_date { get; set; }
        public int episode_number { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int? runtime { get; set; }
        public float vote_average { get; set; }

        /// <summary>
        /// The vote string on percentage based system
        /// </summary>
        public string VoteString => $"{vote_average * 10}/100";
        /// <summary>
        /// The value of the vote average scaled to a percentage system
        /// </summary>
        public float VoteValueScaled => vote_average * 10;
        /// <summary>
        /// The air date of the episode formatted
        /// </summary>
        public string AirDateString
        {
            get
            {
                DateTime asDate = DateTime.ParseExact(air_date,
                   "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                return asDate.ToString("dd/MM/yyyy");
            }
        }

    }
    /// <summary>
    /// The creators, show-runners of the TV Series.
    /// </summary>
    public class Created_By
    {
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public object profile_path { get; set; }
    }

}
