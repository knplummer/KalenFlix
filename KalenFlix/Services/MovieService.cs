using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Infrastructure;
using KalenFlix.Domain;

namespace KalenFlix.Services
{
    public class MovieService : IMovieService
    {
        private IMainSiteRepo _repo;

        public MovieService(IMainSiteRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
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

        public async Task<IEnumerable<Movie>> GetMoviesBySeries(int seriesId)
        {
            return await _repo.SelectMoviesBySeries(seriesId);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByDirector(int directorId)
        {
            return await _repo.SelectMoviesByDirector(directorId);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _repo.SelectMoviesByGenre(genreId);
        }

    }
}
