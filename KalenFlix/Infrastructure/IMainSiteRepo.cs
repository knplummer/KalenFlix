using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Domain;

namespace KalenFlix.Infrastructure
{
    public interface IMainSiteRepo
    {
        Task<Movie> SelectMovie(int movieId);
        Task<int> InsertMovie(Movie m);
        void UpdateMovie(Movie m);
        void DeleteMovie(int movieId);
        Task<IEnumerable<Movie>> SelectMoviesBySeries(int seriesId);
        Task<IEnumerable<Movie>> SelectMoviesByDirector(int directorId);
        Task<Director> SelectDirector(int directorId);
        Task<int> InsertDirector(Director d);
        void UpdateDirector(Director d);
        void DeleteDirctor(int directorId);
        Task<Series> SelectSeries(int seriesId);
        Task<int> InsertSeries(Series s);
        void UpdateSeries(Series s);
        void DeleteSeries(int seriesId);
        Task<Rating> SelectRating(int ratingId);
        Task<int> InsertRating(Rating r);
        void UpdateRating(Rating r);
        void DeleteRating(int ratingId);
        Task<IEnumerable<Rating>> SelectUserRatings(int userId);
        Task<IEnumerable<Movie>> SelectMoviesByGenre(int genreId);
    }
}
