using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KalenFlix.Domain;
using KalenFlix.Services;

namespace KalenFlix.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class DirectorsController : Controller
    {
        private DirectorService directorServices;

        public DirectorsController()
        {
            directorServices = new DirectorService();
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