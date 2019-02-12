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
        private MainSiteRepo _repo { get; set; }

        public MovieServices()
        {
            _repo = new MainSiteRepo();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _repo.SelectAllMovies();
        }

        public async Task<Movie> GetMovie(int movieId)
        {
            return await _repo.SelectMovie(movieId);
        }

        public async Task<int> AddMovie(Movie movie)
        {
            return await _repo.InsertMovie(movie);
        }

        public void DeleteMovie(int movieId)
        {
            _repo.DeleteMovie(movieId);
        }

        public void UpdateMovie(Movie movie)
        {
            _repo.UpdateMovie(movie);
        }

        public async Task<List<Movie>> GetMoviesBySeries(int seriesId)
        {
            return await _repo.SelectMoviesBySeries(seriesId);
        }

        public async Task<List<Movie>> GetMoviesByDirector(int directorId)
        {
            return await _repo.SelectMoviesByDirector(directorId);
        }
    }
}
