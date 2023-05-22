namespace MovieWorld.Models
{
    /// <summary>
    /// A person's credits model, that contains all of their credits as an actor or crew member
    /// </summary>
    public class PersonCreditsModel
    {
        public CreditCast[] cast { get; set; }
        public CreditCrew[] crew { get; set; }
        public int id { get; set; }
    }

    /// <summary>
    /// The credits as a cast member
    /// </summary>
    public class CreditCast
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public string character { get; set; }
        public string name { get; set; }

    }

    /// <summary>
    /// The credits as a crew member
    /// </summary>
    public class CreditCrew
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public string job { get; set; }
        public string name { get; set; }

    }

}
