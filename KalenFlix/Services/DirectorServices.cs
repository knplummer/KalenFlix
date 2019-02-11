using System.Collections.Generic;
using System.Threading.Tasks;
using KalenFlix.Domain;
using KalenFlix.Infrastructure;

namespace KalenFlix.Services
{
    public class DirectorServices
    {
        public MainSiteRepo _repo { get; set; }

        public DirectorServices()
        {
            _repo = new MainSiteRepo();
        }

        public async Task<Director> GetDirector(int directorId)
        {
            return await _repo.GetDirector(directorId);
        }

        public async Task<int> AddDirector(Director director)
        {
            return await _repo.AddDirector(director);
        }

        public void DeleteDirector(int directorId)
        {
            _repo.DeleteDirctor(directorId);
        }

        public void UpdateDirector(Director director)
        {
            _repo.UpdateDirector(director);
        }
    }
}
