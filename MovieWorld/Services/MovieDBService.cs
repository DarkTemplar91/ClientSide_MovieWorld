using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    public class MovieDBService
    {
        private readonly Uri serverUrl = new Uri("https://api.themoviedb.org/");
        private readonly string apiKey = "eecb4764a3dc1e3c49f14ecf0365ad28";
    }
}
