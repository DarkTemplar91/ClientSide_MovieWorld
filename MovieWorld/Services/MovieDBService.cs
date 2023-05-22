using MovieWorld.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    /// <summary>
    /// <c>MovieDBService</c> is a class which helps us access the needed data via API calls to the TheMovieDB endpoints
    /// </summary>
    public class MovieDBService
    {
        private readonly Uri serverUrl = new("https://api.themoviedb.org/3/");
        private readonly string readAccessToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJlZWNiNDc2NGEzZGMxZTNjNDlmMTRlY2YwMzY1YWQyOCIsInN1YiI6IjY0NTdiZGQwMWI3MGFlMDEyNjBiOTY5NiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.N5ZVga5oQIgSa2AO7PHMXlZqzZ3X07ecp2Vx8K_tXGo";

        /// <summary>
        /// Sends a Get request to the endpoint, and if successful, returns with an object.
        /// </summary>
        /// <typeparam name="T">The type of the object that we wish to receive.</typeparam>
        /// <param name="uri">The whole URL of the Get request.</param>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", readAccessToken);
            var response = await client.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        /// <summary>
        /// Gets a list with today's trending content.
        /// </summary>
        /// <returns>A ContentList object containing today's trending movies, tv shows and actors</returns>
        public async Task<ContentList> GetTrendingContentAsync()
        {
            return await GetAsync<ContentList>(new Uri(serverUrl, "trending/all/day"));
        }
        /// <summary>
        /// Gets the details of the movie specified by the id.
        /// </summary>
        /// <param name="movieId">the id of the movie in TMDB</param>
        /// <returns>With a <c>MovieModel</c> object, that contains most of the useful information about the film.</returns>
        public async Task<MovieModel> GetMovieModelAsync(int movieId)
        {
            return await GetAsync<MovieModel>(new Uri(serverUrl, $"movie/{movieId}"));
        }
        /// <summary>
        /// Gets the details of the tv show specified by the id
        /// </summary>
        /// <param name="seriesId">the id of the movie in TMDB</param>
        /// <returns>With a <c>SeriesModel</c> object, that contains most of the useful information about the tv show.</returns>
        public async Task<SeriesModel> GetSeriesModelAsync(int seriesId)
        {
            return await GetAsync<SeriesModel>(new Uri(serverUrl, $"tv/{seriesId}"));
        }
        /// <summary>
        /// Gets the cast of the movie specified by the id
        /// </summary>
        /// <param name="movieId">the id of the movie in TMDB</param>
        /// <returns>With a <c>CastModel</c> object, that contains everyone who worked on the movie as a <c>Cast</c> or <c>Crew</c> member</returns>
        public async Task<CastModel> GetMovieCastAsync(int movieId)
        {
            return await GetAsync<CastModel>(new Uri(serverUrl, $"movie/{movieId}/credits"));
        }
        /// <summary>
        /// Gets the cast of the series specified by the id
        /// </summary>
        /// <param name="seriesId">the id of the tv show in TMDB</param>
        /// <returns>With a <c>CastModel</c> object, that contains everyone who worked on the tv show as a <c>Cast</c> or <c>Crew</c> member</returns>
        public async Task<CastModel> GetSeriesCastAsync(int seriesId)
        {
            return await GetAsync<CastModel>(new Uri(serverUrl, $"tv/{seriesId}/credits"));
        }
        /// <summary>
        /// Gets the personal details of the person(actor, director, cameraman etc.)
        /// </summary>
        /// <param name="personId">the id of the person in TMDB</param>
        /// <returns>With a <c>PersonModel</c> object, that represents an individual who worked on the given content</returns>
        public async Task<PersonModel> GetPersonDetailsAsync(int personId)
        {
            return await GetAsync<PersonModel>(new Uri(serverUrl, $"person/{personId}"));
        }
        /// <summary>
        /// Gets all the credits of the specified person.
        /// </summary>
        /// <param name="personId">the id of the person in TMDB</param>
        /// <returns>With a <c>PersonCreditsModel</c> object, that encompasses every role or job the person had in the industry</returns>
        public async Task<PersonCreditsModel> GetPersonCredits(int personId)
        {
            return await GetAsync<PersonCreditsModel>(new Uri(serverUrl, $"person/{personId}/combined_credits"));
        }
        /// <summary>
        /// Gets all the episodes of the specified show up to the given season
        /// </summary>
        /// <param name="showId">the id of the show in TMDB</param>
        /// <param name="seasonCount">the number of seasons we wish to get, inclusive</param>
        /// <returns></returns>
        public async Task<List<EpisodeList>> GetEpisodeList(int showId, int seasonCount)
        {
            List<EpisodeList> allEpisodes = new List<EpisodeList>();
            for (int i = 0; i < seasonCount; i++)
            {
                var episodesInSeason = await GetAsync<EpisodeList>(new Uri(serverUrl, $"tv/{showId}/season/{i + 1}"));
                allEpisodes.Add(episodesInSeason);
            }

            return allEpisodes;
        }
        /// <summary>
        /// Gets the search results for the given keyword
        /// </summary>
        /// <param name="keyword">the keyword in our query</param>
        /// <returns>A <c>SearchResultModel</c> that contains the list of contents that matches the given keyword</returns>
        public async Task<SearchResultModel> GetSearchResult(string keyword)
        {
            return await GetAsync<SearchResultModel>(new Uri(serverUrl, $"search/multi?query={keyword}"));
        }


    }
}
