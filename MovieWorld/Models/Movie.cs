﻿
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
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
