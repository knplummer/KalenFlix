using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Domain;
using MySql.Data.MySqlClient;

namespace KalenFlix.Infrastructure
{
    public class MainSiteRepo
    {
        private DatabaseHandler dbHandler;

        public MainSiteRepo()
        {
            dbHandler = new DatabaseHandler();
        }

        #region Movies
        public async Task<List<Movie>> SelectAllMovies()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_MainSite_GetAllMovies", parameters);
            return dt.Select(r => new Movie(r)).ToList();
        }

        public async Task<Movie> SelectMovie(int movieId)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = movieId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_MainSite_GetMovie", parameters);
            return dt.Select(r => new Movie(r)).FirstOrDefault();
        }

        public async Task<int> InsertMovie(Movie m)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "title",
                    Value = m.Title
                },
                new MySqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = m.ImdbLink
                },
                new MySqlParameter()
                {
                    ParameterName = "vudulink",
                    Value = m.VuduLink
                },
                new MySqlParameter()
                {
                    ParameterName = "trailerlink",
                    Value = m.TrailerLink
                },
                new MySqlParameter()
                {
                    ParameterName = "genre",
                    Value = m.Genre
                },
                new MySqlParameter()
                {
                    ParameterName = "releaseyear",
                    Value = m.ReleaseYear
                },
                new MySqlParameter()
                {
                    ParameterName = "imdbrating",
                    Value = m.ImdbRating
                },
                new MySqlParameter()
                {
                    ParameterName = "mpaarating",
                    Value = m.MpaaRating
                },
                new MySqlParameter()
                {
                    ParameterName = "directorid",
                    Value = m.DirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "codirectorid",
                    Value = m.CoDirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "seriesid",
                    Value = m.SeriesId
                },
                new MySqlParameter()
                {
                    ParameterName = "adduser",
                    Value = m.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddMovie", parameters));
        }

        public void UpdateMovie(Movie m)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = m.MovieId
                },
                new MySqlParameter()
                {
                    ParameterName = "title",
                    Value = m.Title
                },
                new MySqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = m.ImdbLink
                },
                new MySqlParameter()
                {
                    ParameterName = "vudulink",
                    Value = m.VuduLink
                },
                new MySqlParameter()
                {
                    ParameterName = "trailerlink",
                    Value = m.TrailerLink
                },
                new MySqlParameter()
                {
                    ParameterName = "genre",
                    Value = m.Genre
                },
                new MySqlParameter()
                {
                    ParameterName = "releaseyear",
                    Value = m.ReleaseYear
                },
                new MySqlParameter()
                {
                    ParameterName = "imdbrating",
                    Value = m.ImdbRating
                },
                new MySqlParameter()
                {
                    ParameterName = "mpaarating",
                    Value = m.MpaaRating
                },
                new MySqlParameter()
                {
                    ParameterName = "directorid",
                    Value = m.DirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "codirectorid",
                    Value = m.CoDirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "seriesid",
                    Value = m.SeriesId
                },
                new MySqlParameter()
                {
                    ParameterName = "chguser",
                    Value = m.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateMovie", parameters);
        }

        public void DeleteMovie(int movieId)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = movieId
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteMovie", parameters);
        }

        internal Task<List<Movie>> SelectMoviesBySeries(int seriesId)
        {
            throw new NotImplementedException();
        }

        internal Task<List<Movie>> SelectMoviesByDirector(int directorId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Directors
        public async Task<Director> SelectDirector(int directorId)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = directorId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_MainSite_GetDirector", parameters);
            return dt.Select(r => new Director(r)).FirstOrDefault();
        }

        public async Task<int> InsertDirector(Director d)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "lastname",
                    Value = d.LastName
                },
                new MySqlParameter()
                {
                    ParameterName = "firstname",
                    Value = d.FirstName
                },
                new MySqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = d.ImdbLink
                },

                new MySqlParameter()
                {
                    ParameterName = "adduser",
                    Value = d.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddDirector", parameters));
        }

        public void UpdateDirector(Director d)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = d.DirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "lastname",
                    Value = d.LastName
                },
                new MySqlParameter()
                {
                    ParameterName = "firstname",
                    Value = d.FirstName
                },
                new MySqlParameter()
                {
                    ParameterName = "imdblink",
                    Value = d.ImdbLink
                },

                new MySqlParameter()
                {
                    ParameterName = "chguser",
                    Value = d.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateDirector", parameters);
        }

        public void DeleteDirctor(int directorId)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = directorId
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteDirector", parameters);
        }
        #endregion

        #region Series
        public async Task<Series> SelectSeries(int seriesId)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = seriesId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_MainSite_GetSeries", parameters);
            return dt.Select(r => new Series(r)).FirstOrDefault();
        }

        public async Task<int> InsertSeries(Series s)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "seriestitle",
                    Value = s.SeriesTitle
                },
                new MySqlParameter()
                {
                    ParameterName = "adduser",
                    Value = s.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddSeries", parameters));
        }

        public void UpdateSeries(Series s)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "seriesid",
                    Value = s.SeriesId
                },
                new MySqlParameter()
                {
                    ParameterName = "seriestitl",
                    Value = s.SeriesTitle
                },
                new MySqlParameter()
                {
                    ParameterName = "chguser",
                    Value = s.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateSeris", parameters);
        }

        public void DeleteSeries(int seriesId)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = seriesId
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteSeries", parameters);
        }
        #endregion

        #region Rating
        public async Task<Rating> SelectRating(int ratingId)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = ratingId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_MainSite_GetRating", parameters);
            return dt.Select(r => new Rating(r)).FirstOrDefault();
        }

        public async Task<int> InsertRating(Rating r)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "movieid",
                    Value = r.MovieId
                },
                new MySqlParameter()
                {
                    ParameterName = "userid",
                    Value = r.UserId
                },
                new MySqlParameter()
                {
                    ParameterName = "rating",
                    Value = r.RatingValue
                },
                new MySqlParameter()
                {
                    ParameterName = "comments",
                    Value = r.Comments
                },
                new MySqlParameter()
                {
                    ParameterName = "adduser",
                    Value = r.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsync("VuduSite_MainSite_AddRating", parameters));
        }

        public void UpdateRating(Rating r)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "ratingid",
                    Value = r.RatingId
                },
                new MySqlParameter()
                {
                    ParameterName = "movieid",
                    Value = r.MovieId
                },
                new MySqlParameter()
                {
                    ParameterName = "userid",
                    Value = r.UserId
                },
                new MySqlParameter()
                {
                    ParameterName = "rating",
                    Value = r.RatingValue
                },
                new MySqlParameter()
                {
                    ParameterName = "comments",
                    Value = r.Comments
                },
                new MySqlParameter()
                {
                    ParameterName = "adduser",
                    Value = r.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_UpdateRating", parameters);
        }

        public void DeleteRating(int ratingId)
        {
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = ratingId
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_MainSite_DeleteRating", parameters);
        }

        internal Task<List<Rating>> SelectUserRatings(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
