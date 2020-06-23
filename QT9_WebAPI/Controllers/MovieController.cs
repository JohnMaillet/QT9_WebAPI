    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QT9_WebAPI.Models;
using QT9_WebAPI.Services;

namespace QT9_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private UnitOfWork unitOfWork;
        private IConfiguration _configruation;

        public MovieController(IConfiguration configruation, IServiceProvider serviceProvider)
        {
            _configruation = configruation;
            unitOfWork = new UnitOfWork(serviceProvider);  
        }

        [HttpGet]
        public IEnumerable<tblMovie> GetMovies()
        {
            tblMovie movie = new tblMovie();                
            return unitOfWork.MovieRepository.GetAll(movie);           
        }
    }
}
