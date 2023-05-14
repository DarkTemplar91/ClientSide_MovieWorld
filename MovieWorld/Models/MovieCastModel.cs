using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Models
{

    public class MovieCastModel
    {
        public int id { get; set; }
        public Cast[] cast { get; set; }
        public Crew[] crew { get; set; }

        public Crew[] GetFilteredCrew
        {
            get
            {
                return crew.Where(c => c.job == "Director" || c.job == "Screenplay" || c.job == "Writer" || c.job == "Story by").ToArray();
            }
        }
    }

    public class Cast
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }
        public int cast_id { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int order { get; set; }

        public string ProfileImagePath
        {
            get
            {
                if (profile_path == null || profile_path.Length == 0)
                    return "ms-appx:///Assets/headshot-placeholder.png";

                string baseUri = $"https://image.tmdb.org/t/p/original";
                return string.Format("{0}/{1}", baseUri, profile_path.Trim('/'));
            }
        }
    }

    public class Crew
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }
        public string credit_id { get; set; }
        public string department { get; set; }
        public string job { get; set; }

        public static explicit operator Crew(Cast cast)
        {
            return new Crew()
            {
                adult = cast.adult,
                gender = cast.gender,
                id = cast.id,
                known_for_department = cast.known_for_department,
                name = cast.name,
                original_name = cast.original_name,
                popularity = cast.popularity,
                profile_path = cast.profile_path,
                credit_id = cast.credit_id,
                job = cast.character
            };
        }

        public static explicit operator Cast(Crew crew)
        {
            return new Cast()
            {
                adult = crew.adult,
                gender = crew.gender,
                id = crew.id,
                known_for_department = crew.known_for_department,
                name = crew.name,
                original_name = crew.original_name,
                popularity = crew.popularity,
                profile_path = crew.profile_path,
                credit_id = crew.credit_id,
                character = crew.job
            };
        }

    }


}
