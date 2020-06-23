using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QT9_WebForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace QT9_WebForm.BLL
{
   public class MovieClient
    {
        private static IConfiguration _configuration;
       
        private static string apiURL;
        private static string apiEndpoint;
        public MovieClient(IConfiguration configuration)
        {
            _configuration = configuration;
            apiURL = _configuration.GetValue<string>("MovieApiUrl");
            apiEndpoint = _configuration.GetValue<string>("MovieApiEndpoint");
         
        }
        public  async Task<List<MovieViewModel>> GetMovies()
        {
            IEnumerable<Movie> movies = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(apiEndpoint);
            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(responseAsString);
            }

            List <MovieViewModel> listMovies = new List<MovieViewModel>();

            foreach(var movie in movies)
            {
                listMovies.Add(new MovieViewModel
                {
                    MovieID = movie.MovieID,
                    MovieRating = movie.MovieRating,
                    MovieTitle = movie.MovieTitle,
                    ReleaseYear = movie.ReleaseYear,
                    Selected = false
                });
            }
            return listMovies;
        }
    }
}
