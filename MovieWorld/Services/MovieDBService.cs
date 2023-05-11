using MovieWorld.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    public class MovieDBService
    {
        private readonly Uri serverUrl = new Uri("https://api.themoviedb.org/3/");
        private readonly string apiKey = "eecb4764a3dc1e3c49f14ecf0365ad28";
        private readonly string readAccessToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJlZWNiNDc2NGEzZGMxZTNjNDlmMTRlY2YwMzY1YWQyOCIsInN1YiI6IjY0NTdiZGQwMWI3MGFlMDEyNjBiOTY5NiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.N5ZVga5oQIgSa2AO7PHMXlZqzZ3X07ecp2Vx8K_tXGo";

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", readAccessToken);
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<MovieList> GetTrendingMoviesAsync()
        {
            return await GetAsync<MovieList>(new Uri(serverUrl, "trending/movie/day?language=en-US"));
        }

        public async Task<MovieModel> GetMovieModelAsync(int movieId)
        {
            return await GetAsync<MovieModel>(new Uri(serverUrl, $"movie/{movieId}?language-en-US"));
        }


    }
}
