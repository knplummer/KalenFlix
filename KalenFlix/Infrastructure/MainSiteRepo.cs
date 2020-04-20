using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Domain;
using KalenFlix.Database;
using System.Data.SqlClient;

namespace KalenFlix.Infrastructure
{
    public class MainSiteRepo : IMainSiteRepo
    {
        private IDatabaseHandler _dbHandler;

        public MainSiteRepo(IDatabaseHandler databaseHandler)
        {
            _dbHandler = databaseHandler;
        }

        #region Movies
        public async Task<IEnumerable<Movie>> SelectAllMovies()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return new DataMapper<Movie>().Map(await _dbHandler.ExecuteQueryAsync("VuduSite_MainSite_GetAllMovies", parameters));
        }

        public async Task<Movie> SelectMovie(int movieId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = movieId
                }
            };
            return new DataMapper<Movie>().Map(await _dbHandler.ExecuteSingleRowQueryAsync("VuduSite_MainSite_GetMovie", parameters));
        }

        public async Task<int> InsertMovie(Movie m)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "title",
                    Value = m.Title
                },
                new SqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = m.ImdbLink
                },
                new SqlParameter()
                {
                    ParameterName = "vudulink",
                    Value = m.VuduLink
                },
                new SqlParameter()
                {
                    ParameterName = "trailerlink",
                    Value = m.TrailerLink
                },
                new SqlParameter()
                {
                    ParameterName = "releaseyear",
                    Value = m.ReleaseYear
                },
                new SqlParameter()
                {
                    ParameterName = "imdbrating",
                    Value = m.ImdbRating
                },
                new SqlParameter()
                {
                    ParameterName = "mpaarating",
                    Value = m.MpaaRating
                },
                new SqlParameter()
                {
                    ParameterName = "directorid",
                    Value = m.DirectorId
                },
                new SqlParameter()
                {
                    ParameterName = "codirectorid",
                    Value = m.CoDirectorId
                },
                new SqlParameter()
                {
                    ParameterName = "seriesid",
                    Value = m.SeriesId
                },
                new SqlParameter()
                {
                    ParameterName = "adduser",
                    Value = m.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await _dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddMovie", parameters));
        }


        public void UpdateMovie(Movie m)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = m.MovieId
                },
                new SqlParameter()
                {
                    ParameterName = "title",
                    Value = m.Title
                },
                new SqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = m.ImdbLink
                },
                new SqlParameter()
                {
                    ParameterName = "vudulink",
                    Value = m.VuduLink
                },
                new SqlParameter()
                {
                    ParameterName = "trailerlink",
                    Value = m.TrailerLink
                },
                new SqlParameter()
                {
                    ParameterName = "releaseyear",
                    Value = m.ReleaseYear
                },
                new SqlParameter()
                {
                    ParameterName = "imdbrating",
                    Value = m.ImdbRating
                },
                new SqlParameter()
                {
                    ParameterName = "mpaarating",
                    Value = m.MpaaRating
                },
                new SqlParameter()
                {
                    ParameterName = "directorid",
                    Value = m.DirectorId
                },
                new SqlParameter()
                {
                    ParameterName = "codirectorid",
                    Value = m.CoDirectorId
                },
                new SqlParameter()
                {
                    ParameterName = "seriesid",
                    Value = m.SeriesId
                },
                new SqlParameter()
                {
                    ParameterName = "chguser",
                    Value = m.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateMovie", parameters);
        }

        public void DeleteMovie(int movieId)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = movieId
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteMovie", parameters);
        }

        public async Task<IEnumerable<Movie>> SelectMoviesBySeries(int seriesId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "seriesId",
                    Value = seriesId
                }
            };
            return new DataMapper<Movie>().Map(await _dbHandler.ExecuteQueryAsync("VuduSite_MainSite_SelectMoviesBySeries", parameters));
        }

        internal Task<IEnumerable<Movie>> SelectMoviesByDirector(int directorId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Directors
        public async Task<Director> SelectDirector(int directorId)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = directorId
                }
            };
            return new DataMapper<Director>().Map(await _dbHandler.ExecuteSingleRowQueryAsync("VuduSite_MainSite_GetDirector", parameters));
        }

        public async Task<int> InsertDirector(Director d)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "lastname",
                    Value = d.LastName
                },
                new SqlParameter()
                {
                    ParameterName = "firstname",
                    Value = d.FirstName
                },
                new SqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = d.ImdbLink
                },

                new SqlParameter()
                {
                    ParameterName = "adduser",
                    Value = d.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await _dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddDirector", parameters));
        }

        public void UpdateDirector(Director d)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = d.DirectorId
                },
                new SqlParameter()
                {
                    ParameterName = "lastname",
                    Value = d.LastName
                },
                new SqlParameter()
                {
                    ParameterName = "firstname",
                    Value = d.FirstName
                },
                new SqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = d.ImdbLink
                },

                new SqlParameter()
                {
                    ParameterName = "chguser",
                    Value = d.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateDirector", parameters);
        }

        public void DeleteDirctor(int directorId)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = directorId
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteDirector", parameters);
        }
        #endregion

        #region Series
        public async Task<Series> SelectSeries(int seriesId)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = seriesId
                }
            };
            return new DataMapper<Series>().Map(await _dbHandler.ExecuteSingleRowQueryAsync("VuduSite_MainSite_GetSeries", parameters));
        }

        public async Task<int> InsertSeries(Series s)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "seriestitle",
                    Value = s.SeriesTitle
                },
                new SqlParameter()
                {
                    ParameterName = "adduser",
                    Value = s.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await _dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddSeries", parameters));
        }

        public void UpdateSeries(Series s)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "seriesid",
                    Value = s.SeriesId
                },
                new SqlParameter()
                {
                    ParameterName = "seriestitl",
                    Value = s.SeriesTitle
                },
                new SqlParameter()
                {
                    ParameterName = "chguser",
                    Value = s.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateSeris", parameters);
        }

        public void DeleteSeries(int seriesId)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = seriesId
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteSeries", parameters);
        }
        #endregion

        #region Rating
        public async Task<Rating> SelectRating(int ratingId)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = ratingId
                }
            };
           return new DataMapper<Rating>().Map(await _dbHandler.ExecuteSingleRowQueryAsync("VuduSite_MainSite_GetRating", parameters));
        }

        public async Task<int> InsertRating(Rating r)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "movieid",
                    Value = r.MovieId
                },
                new SqlParameter()
                {
                    ParameterName = "userid",
                    Value = r.UserId
                },
                new SqlParameter()
                {
                    ParameterName = "rating",
                    Value = r.RatingValue
                },
                new SqlParameter()
                {
                    ParameterName = "comments",
                    Value = r.Comments
                },
                new SqlParameter()
                {
                    ParameterName = "adduser",
                    Value = r.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await _dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddRating", parameters));
        }

        public void UpdateRating(Rating r)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "ratingid",
                    Value = r.RatingId
                },
                new SqlParameter()
                {
                    ParameterName = "movieid",
                    Value = r.MovieId
                },
                new SqlParameter()
                {
                    ParameterName = "userid",
                    Value = r.UserId
                },
                new SqlParameter()
                {
                    ParameterName = "rating",
                    Value = r.RatingValue
                },
                new SqlParameter()
                {
                    ParameterName = "comments",
                    Value = r.Comments
                },
                new SqlParameter()
                {
                    ParameterName = "adduser",
                    Value = r.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateRating", parameters);
        }

        public void DeleteRating(int ratingId)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = ratingId
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteRating", parameters);
        }

        internal Task<IEnumerable<Rating>> SelectUserRatings(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Genre
        internal Task<IEnumerable<Movie>> SelectMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}