using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Domain;
using KalenFlix.Infrastructure;

namespace KalenFlix.Services
{
    public class ProfileService : IProfileService
    {
        private IMainSiteRepo _mainRepo;
        private IAdminAreaRepo _adminRepo;

        public ProfileService(IMainSiteRepo mainSiteRepo, IAdminAreaRepo adminAreaRepo)
        {
            _mainRepo = mainSiteRepo;
            _adminRepo = adminAreaRepo;
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
