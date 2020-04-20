using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KalenFlix.Domain;
using KalenFlix.Services;

namespace KalenFlix.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        public MovieService movieServices;

        public HomeController()
        {
            movieServices = new MovieService();
        }

        [HttpGet]
        public async Task<List<Movie>> GetAllMovies()
        {
            return await movieServices.GetAllMovies();
        }

        [HttpGet("{id}")]
        public async Task<Movie> GetMovie(int id)
        {
            return await movieServices.GetMovie(id);
        }

        [HttpPost("add-movie")]
        public async Task<int> AddMovie(Movie m)
        {
            return await movieServices.AddMovie(m);
        }

        [HttpPost("update-movie")]
        public void UpdateMovie(Movie m)
        {
            movieServices.UpdateMovie(m);
        }

        [HttpGet("delete-movie/{id}")]
        public void DeleteMovie(int id)
        {
            movieServices.DeleteMovie(id);
        }
    }
}