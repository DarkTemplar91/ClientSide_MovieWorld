using System.Linq;

namespace MovieWorld.Models
{
    /// <summary>
    /// Class that represent the cast of a movie.
    /// It inclused the actors <see cref="cast"/> and the all the crew who worked on the movie: <see cref="Crew"/>
    /// </summary>
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
    /// <summary>
    /// The model of the actors who got credited in the movie
    /// </summary>
    public class Cast
    {
        public int id { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
        public string character { get; set; }
    }
    /// <summary>
    /// The model of the crew-members who worked on the movie
    /// </summary>
    public class Crew
    {
        public int id { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
        public string job { get; set; }
    }


}
