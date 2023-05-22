using System;

namespace MovieWorld.Models
{
    public class PersonModel
    {
        public string biography { get; set; }
        public string birthday { get; set; }
        public object deathday { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string place_of_birth { get; set; }
        public string profile_path { get; set; }

        public string Gender =>
            gender switch
            {
                1 => "Female",
                2 => "Male",
                _ => "Not specified"
            };

        private int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                if (deathday != null)
                    today = DateTime.ParseExact((string)deathday,
                   "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                DateTime birthdate = DateTime.ParseExact(birthday,
                   "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                int age = today.Year - birthdate.Year;
                if (birthdate.Date > today.AddYears(-age)) age--;

                return age;
            }
        }

        public string Birthday
        {
            get
            {
                if (deathday is not null)
                    return birthday;

                return $"{birthday} ({Age} years old)";

            }
        }

        public string Deathday => deathday is null ? "" : $"{deathday} ({Age} years old)";


        public string IMDb_ID => $"https://www.imdb.com/name/{imdb_id}/";
    }


}
