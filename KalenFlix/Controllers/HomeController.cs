using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KalenFlix.Domain;
using KalenFlix.Services;

namespace KalenFlix.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        public MovieServices movieServices;

        public HomeController()
        {
            movieServices = new MovieServices();
        }

        [HttpGet]
        public async Task<List<Movie>> GetAllMovies()
        {
            return await movieServices.GetAllMovies();
        }
    }
}