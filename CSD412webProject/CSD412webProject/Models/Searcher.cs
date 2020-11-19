using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSD412webProject.Models
{
    public static class Searcher
    {
        public const string apiUrl = "https://api.themoviedb.org/3/";
        public const string urlForSearchingMovieByTitle ="search/movie?api_key=034a2378c1b093a7a29b0ae0ea2f6268&language=en-US&query=";
        //public const string urlForSearchMovieById = "movie/10555/videos?api_key=034a2378c1b093a7a29b0ae0ea2f6268&language=en-US";
        public static HttpClient client;

        private static void ConnectClient()
        { 
            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<string> SearchMovieByTitle(string movieTitle )
        {
            ConnectClient();

            //GET Method  
            HttpResponseMessage response = await client.GetAsync(urlForSearchingMovieByTitle + movieTitle);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                throw new Exception("Error occured while connecting to TMDB API");
            }
        }

        public static async Task<string> SearchMovieById(int movieId)
        {
            
            string urlForSearchMovieById = $"movie/{movieId}/videos?api_key=034a2378c1b093a7a29b0ae0ea2f6268";
            ConnectClient();

            //GET Method  
            HttpResponseMessage response = await client.GetAsync(urlForSearchMovieById);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                throw new Exception("Error occured while connecting to TMDB API");
            }
        }
    }
}
