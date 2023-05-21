using System.Linq;

namespace MovieWorld.Models
{


    public class SearchResultModel
    {
        public int page { get; set; }
        public SearchResult[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class SearchResult
    {
        public bool adult { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string media_type { get; set; }
        public float popularity { get; set; }
        public string release_date { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public int gender { get; set; }
        public string known_for_department { get; set; }
        public string profile_path { get; set; }
        public Known_For[] known_for { get; set; }
        public string first_air_date { get; set; }

        public string SearchName
        {
            get
            {
                if (media_type == "movie")
                    return title;

                return name;
            }
        }

        public string SymbolName
        {
            get
            {
                switch (media_type)
                {
                    case "movie":
                        return "Video";
                    case "tv":
                        return "GoToStart";
                    case "person":
                        return "People";
                    default:
                        return "";

                }
            }
        }

        public string KnownForSeperated
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
