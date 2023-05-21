using System;

namespace MovieWorld.Models
{
    public class PersonModel
    {
        public bool adult { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public object deathday { get; set; }
        public int gender { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string place_of_birth { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }

        public string ProfileImagePath
        {
            get
            {
                if (profile_path == null || profile_path.Length == 0)
                    return "ms-appx:///Assets/headshot-placeholder.png";

                string baseUri = $"https://image.tmdb.org/t/p/w500";
                return string.Format("{0}/{1}", baseUri, profile_path.Trim('/'));
            }
        }

        public string Gender
        {
            get
            {
                if (gender == 0)
                    return "Not specified";

                if (gender == 1)
                    return "Female";

                return "Male";
            }
        }

        public int Age
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

        public string Deathday
        {
            get
            {
                if (deathday is null)
                    return "";

                return $"{deathday} ({Age} years old)";



            }
        }


        public string IMDb_ID
        {
            get
            {
                return $"https://www.imdb.com/name/{imdb_id}/";
            }
        }
    }


}
