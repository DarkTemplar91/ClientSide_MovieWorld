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

        public async Task<MovieList> GetTrendingContentAsync()
        {
            return await GetAsync<MovieList>(new Uri(serverUrl, $"trending/person/day"));
        }

        public async Task<MovieModel> GetMovieModelAsync(int movieId)
        {
            return await GetAsync<MovieModel>(new Uri(serverUrl, $"movie/{movieId}"));
        }

        public async Task<SeriesModel> GetSeriesModelAsync(int seriesId)
        {
            return await GetAsync<SeriesModel>(new Uri(serverUrl, $"tv/{seriesId}"));
        }

        public async Task<CastModel> GetMovieCastAsync(int movieId)
        {
            return await GetAsync<CastModel>(new Uri(serverUrl, $"movie/{movieId}/credits"));
        }
        public async Task<CastModel> GetSeriesCastAsync(int seriesId)
        {
            return await GetAsync<CastModel>(new Uri(serverUrl, $"tv/{seriesId}/credits"));
        }

        public async Task<PersonModel> GetPersonDetailsAsync(int personId)
        {
            return await GetAsync<PersonModel>(new Uri(serverUrl, $"person/{personId}"));
        }

        public async Task<PersonCreditsModel> GetPersonCredits(int personId)
        {
            return await GetAsync<PersonCreditsModel>(new Uri(serverUrl, $"person/{personId}/combined_credits"));
        }

        public async Task<List<EpisodeList>> GetEpisodeList(int showId, int seasonCount)
        {
            List<EpisodeList> allEpisodes = new List<EpisodeList>();
            for(int i = 0; i < seasonCount; i++)
            {
                var episodesInSeason = await GetAsync<EpisodeList>(new Uri(serverUrl, $"tv/{showId}/season/{i+1}"));
                allEpisodes.Add(episodesInSeason);
            }

            return allEpisodes;
        }


    }
}
