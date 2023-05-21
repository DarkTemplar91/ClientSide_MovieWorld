using System;
using System.Linq;

namespace MovieWorld.Models
{

    public class SeriesModel
    {
        public string backdrop_path { get; set; }
        public string first_air_date { get; set; }
        public Genre[] genres { get; set; }
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

        public string ReleaseYear => "(" + first_air_date.Substring(0, 4) + ")";

        public string VoteCountString => $"({vote_count})";

        public float VoteAverageOnScale => vote_average / 2;

        public string DateString
        {
            get
            {
                DateTime asDate = DateTime.ParseExact(first_air_date,
                   "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                return asDate.ToString("dd/MM/yyyy");
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

    public class Season
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class EpisodeList
    {
        public Episode[] episodes { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int season_number { get; set; }
    }

    public class Episode
    {
        public string air_date { get; set; }
        public int episode_number { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int? runtime { get; set; }
        public float vote_average { get; set; }

        public string VoteString => $"{vote_average * 10}/100";

        public float VoteValueScaled => vote_average * 10;

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
}
