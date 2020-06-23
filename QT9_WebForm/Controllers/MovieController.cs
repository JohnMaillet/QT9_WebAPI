using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QT9_WebForm.BLL;
using QT9_WebForm.Models;

namespace QT9_WebForm.Controllers
{
    public class MovieController : Controller
    {
        private static IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async  Task<IActionResult> Index()
        {
            MovieClient client = new MovieClient(_configuration);
            List<MovieViewModel> movieViewModels = await client.GetMovies();
            
            return View(movieViewModels);
        }
    }
}
