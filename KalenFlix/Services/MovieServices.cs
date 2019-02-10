using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Infrastructure;
using KalenFlix.Domain;

namespace KalenFlix.Services
{
    public class MovieServices
    {
        public MainSiteRepo _repo { get; set; }

        public MovieServices()
        {
            _repo = new MainSiteRepo();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _repo.GetAllMovies();
        }
    }
}
