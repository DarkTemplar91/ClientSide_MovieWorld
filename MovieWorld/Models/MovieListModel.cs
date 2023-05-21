using System.Collections.Generic;

namespace MovieWorld.Models
{
    public class ContentGroup
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<ContentListItem> Content { get; set; }
    }

    public class ContentList
    {
        public ContentListItem[] results { get; set; }
    }

    public class ContentListItem
    {

        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string profile_path { get; set; }
        public string media_type { get; set; }
        public float vote_average { get; set; }

        public string Name => title ?? name;

        public string VoteString => $"{vote_average:F1}/10";

    }

}
