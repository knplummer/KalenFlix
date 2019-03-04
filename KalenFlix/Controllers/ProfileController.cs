using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KalenFlix.Domain;
using KalenFlix.Services;

namespace KalenFlix.Controllers
{
    [Produces("application/json")]
    [Route("api/profile")]
    public class ProfileController : Controller
    {
        private ProfileServices profileServices;

        public ProfileController()
        {
            profileServices = new ProfileServices();
        }

        [HttpGet("{user/id}")]
        public async Task<User> GetUser(int id)
        {
            return await profileServices.GetUserProfile(id);
        }

        [HttpGet("{ratings/id}")]
        public async Task<List<Rating>> GetUserRatings(int id)
        {
            return await profileServices.GetUserRatings(id);
        }

        [HttpGet("{devices/id}")]
        public async Task<List<Device>> GetUserDevices(int id)
        {
            return await profileServices.GetUserDevices(id);
        }
    }
}