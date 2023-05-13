﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }

}
