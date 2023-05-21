using System.Linq;

namespace MovieWorld.Models
{

    public class CastModel
    {
        public int id { get; set; }
        public Cast[] cast { get; set; }
        public Crew[] crew { get; set; }

        public Crew[] GetFilteredCrew
        {
            get
            {
                return crew.Where(c => c.job is "Director" or "Screenplay" or "Writer" or "Story by" or "Creator").ToArray();
            }
        }
    }

    public class Cast
    {
        public int id { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
        public string character { get; set; }
    }

    public class Crew
    {
        public int id { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
        public string job { get; set; }
    }


}
