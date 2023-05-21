using System.Linq;

namespace MovieWorld.Models
{


    public class SearchResultModel
    {
        public SearchResult[] results { get; set; }
    }

    public class SearchResult
    {
        public int id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string media_type { get; set; }
        public string release_date { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
        public Known_For[] known_for { get; set; }
        public string first_air_date { get; set; }

        public string SearchName => media_type == "movie" ? title : name;

        public string SymbolName =>
            media_type switch
            {
                "movie" => "Video",
                "tv" => "GoToStart",
                "person" => "People",
                _ => ""
            };

        public string KnownForSeparated
        {
            get
            {
                if (known_for is null || known_for.Length == 0)
                    return "";

                return known_for.Select((k) => k.title).Aggregate((a, b) => a + ", " + b);
            }
        }
    }

    public class Known_For
    {
        public int id { get; set; }
        public string title { get; set; }
    }

}
