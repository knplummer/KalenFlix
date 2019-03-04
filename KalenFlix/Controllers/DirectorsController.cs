using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KalenFlix.Domain;
using KalenFlix.Services;

namespace KalenFlix.Controllers
{
    [Produces("application/json")]
    [Route("api/directors")]
    public class DirectorsController : Controller
    {
        private DirectorServices directorServices;

        public DirectorsController()
        {
            directorServices = new DirectorServices();
        }

        [HttpGet("{id}")]
        public async Task<Director> GetDirector(int id)
        {
            return await directorServices.GetDirector(id);
        }

        [HttpPost]
        public async Task<int> AddDirector(Director d)
        {
            return await directorServices.AddDirector(d);
        }

        [HttpPost]
        public void UpdateDirector(Director d)
        {
            directorServices.UpdateDirector(d);
        }

        [HttpGet("delete/{id}")]
        public void DeleteDirector(int id)
        {
            directorServices.DeleteDirector(id);
        }
    }
}