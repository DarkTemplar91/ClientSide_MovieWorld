namespace MovieWorld.Models
{

    public class PersonCreditsModel
    {
        public CreditCast[] cast { get; set; }
        public CreditCrew[] crew { get; set; }
        public int id { get; set; }
    }

    public class CreditCast
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public string character { get; set; }
        public string name { get; set; }

    }

    public class CreditCrew
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public string job { get; set; }
        public string name { get; set; }

    }

}
