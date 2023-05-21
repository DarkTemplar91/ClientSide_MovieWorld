using System;
using System.Linq;

namespace MovieWorld.Models
{

    public class SeriesModel
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public Created_By[] created_by { get; set; }
        public object[] episode_run_time { get; set; }
        public string first_air_date { get; set; }
        public Genre[] genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public bool in_production { get; set; }
        public string[] languages { get; set; }
        public string last_air_date { get; set; }
        public Episode last_episode_to_air { get; set; }
        public string name { get; set; }
        public Episode next_episode_to_air { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public string[] origin_country { get; set; }
        public string original_language { get; set; }
        public string original_name { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public Season[] seasons { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string type { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        public string ReleaseYear
        {
            get
            {
                return "(" + first_air_date.Substring(0, 4) + ")";
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

    public class Created_By
    {
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
    }

    public class Season
    {
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }

    public class EpisodeList
    {
        public string _id { get; set; }
        public string air_date { get; set; }
        public Episode[] episodes { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }

    public class Episode
    {
        public string air_date { get; set; }
        public int episode_number { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string production_code { get; set; }
        public int? runtime { get; set; }
        public int season_number { get; set; }
        public int show_id { get; set; }
        public string still_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }


        public string RuntimeString
        {
            get
            {
                if (runtime >= 60)
                    return $"{runtime / 60}h {runtime % 60}m";

                return $"{runtime}m";
            }
        }

        public string VoteString
        {
            get
            {
                return $"{vote_average * 10}/100";
            }
        }

        public float VoteValueScaled
        {
            get { return vote_average * 10; }
        }

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
