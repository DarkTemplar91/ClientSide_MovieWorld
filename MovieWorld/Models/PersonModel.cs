using System;

namespace MovieWorld.Models
{
    /// <summary>
    /// The Model of a person. It contains most of the personal information of the industry member, such as birthplace, time, name, biography etc
    /// </summary>
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

        /// <summary>
        /// The gender of the person as a string
        /// </summary>
        public string Gender =>
            gender switch
            {
                1 => "Female",
                2 => "Male",
                _ => "Not specified"
            };

        /// <summary>
        /// The age of the person calculated from their birthday.
        /// </summary>
        private int Age
        {
            get
            {
                if (birthday is null)
                    return 0;
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
        /// <summary>
        /// The birthday string
        /// </summary>
        public string Birthday
        {
            get
            {
                if (birthday is null)
                    return "Unknown";
                if (deathday is not null)
                    return birthday;

                return $"{birthday} ({Age} years old)";

            }
        }
        /// <summary>
        /// The day of their death, and their age.
        /// </summary>
        public string Deathday => deathday is null ? "" : $"{deathday} ({Age} years old)";

        /// <summary>
        /// The IMDb URL of the person.
        /// </summary>
        public string IMDb_ID => $"https://www.imdb.com/name/{imdb_id}/";
    }


}
