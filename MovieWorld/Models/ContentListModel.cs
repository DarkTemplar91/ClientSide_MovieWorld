using System.Collections.Generic;

namespace MovieWorld.Models
{
    /// <summary>
    /// A group of content that includes a list of content of the given type.
    /// </summary>
    /// <example>
    /// For example: actor, tv show, person
    /// </example>
    public class ContentGroup
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<ContentListItem> Content { get; set; }
    }

    /// <summary>
    /// The list of mixed contents returned by the API call.
    /// </summary>
    public class ContentList
    {
        public ContentListItem[] results { get; set; }
    }

    /// <summary>
    /// The model of the trending content item. These will be used for the the lists (trending, watchlist, favorites).
    /// </summary>
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

        /// <summary>
        /// The name of title of the content
        /// </summary>
        public string Name => title ?? name;
        /// <summary>
        /// The average value of the votes as a x/10 value
        /// </summary>
        public string VoteString => $"{vote_average:F1}/10";

    }

}
