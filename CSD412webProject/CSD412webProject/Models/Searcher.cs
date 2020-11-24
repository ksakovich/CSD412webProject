using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace CSD412webProject.Models
{
    public static class Searcher
    {
        public const string apiUrl = "https://api.themoviedb.org/3/";
        public static HttpClient client;
        private static string apiKey = Environment.GetEnvironmentVariable("TMDB_API_KEY");

        private static void ConnectClient()
        { 

            //bool isLocal = HttpContext.Request.IsLocal;
            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<string> SearchMovieByTitle(string movieTitle )
        {
            ConnectClient();

            //GET Method  
            
            string urlForSearchingMovieByTitle = $"search/movie?api_key={apiKey}&language=en-US&query=";
            HttpResponseMessage response = await client.GetAsync(urlForSearchingMovieByTitle + movieTitle);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                throw new Exception($"Error occured while connecting to TMDB API by movie title = {movieTitle}");
            }
        }

        public static async Task<string> SearchMovieById(int movieId)
        {
            string urlForSearchMovieById = $"movie/{movieId}/videos?api_key={apiKey}";
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
                return null;
                 //throw new Exception($"Error occured while connecting to TMDB API by searching movie by id ={movieId}");
            }
        }
         public static async Task<string>SearchForGenres()
         {
            string urlForSearchAllGenres = $"genre/movie/list?api_key={apiKey}&language=en-US";

            ConnectClient();

            //GET Method  
            HttpResponseMessage response = await client.GetAsync(urlForSearchAllGenres);
            if (response.IsSuccessStatusCode)
            {
                var jsonGenres = await response.Content.ReadAsStringAsync();
                return jsonGenres;
            }
            else
            {
                throw new Exception($"Error occured while connecting to TMDB API by searching for genres");
            }
        }
    }
}
