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

        public async Task<Movie> GetMovie(int movieId)
        {
            return await _repo.GetMovie(movieId);
        }

        public async Task<int> AddMovie(Movie movie)
        {
            return await _repo.AddMovie(movie);
        }

        public void DeleteMovie(int movieId)
        {
            _repo.DeleteMovie(movieId);
        }

        public void UpdateMovie(Movie movie)
        {
            _repo.UpdateMovie(movie);
        }
    }
}
