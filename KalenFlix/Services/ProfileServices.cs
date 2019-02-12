using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Domain;
using KalenFlix.Infrastructure;

namespace KalenFlix.Services
{
    public class ProfileServices
    {
        private MainSiteRepo _mainRepo;
        private AdminAreaRepo _adminRepo;

        public ProfileServices()
        {
            _mainRepo = new MainSiteRepo();
            _adminRepo = new AdminAreaRepo();
        }

        public async Task<User> GetUserProfile(int userId)
        {
            return await _adminRepo.SelectUser(userId);
        }

        public async Task<List<Rating>> GetUserRatings(int userId)
        {
            return await _mainRepo.SelectUserRatings(userId);
        }

        public async Task<List<Device>> GetUserDevices(int userId)
        {
            return await _adminRepo.SelectUserDevices(userId);
        }
    }
}
