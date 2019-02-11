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
        #region Movies
        public async Task<List<Movie>> GetAllMovies()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var dt = await dbHandler.ExecuteQueryAsyc("VuduSite_GetAllMovies", parameters);
            return dt.Select(r => new Movie(r)).ToList();
        }

        public async Task<Movie> GetMovie(int movieId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = movieId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsyc("VuduSite_GetMovie", parameters);
            return dt.Select(r => new Movie(r)).FirstOrDefault();
        }

        public async Task<int> AddMovie(Movie m)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsnyc("VuduSite_AddMovie", parameters));
        }

        public void UpdateMovie(Movie m)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            dbHandler.ExecuteNonQuery("VuduSite_UpdateMovie", parameters);
        }

        public void DeleteMovie(int movieId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = movieId
                }
            };
            dbHandler.ExecuteNonQuery("VuduSite_DeleteMovie", parameters);
        }
        #endregion

        #region Directors
        public async Task<Director> GetDirector(int directorId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = directorId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsyc("VuduSite_GetDirector", parameters);
            return dt.Select(r => new Director(r)).FirstOrDefault();
        }

        public async Task<int> AddDirector(Director d)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsnyc("VuduSite_AddDirector", parameters));
        }

        public void UpdateDirector(Director d)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            dbHandler.ExecuteNonQuery("VuduSite_UpdateDirector", parameters);
        }

        public void DeleteDirctor(int directorId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = directorId
                }
            };
            dbHandler.ExecuteNonQuery("VuduSite_DeleteDirector", parameters);
        }
        #endregion

        #region Series
        public async Task<Series> GetSeries(int seriesId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = seriesId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsyc("VuduSite_GetSeries", parameters);
            return dt.Select(r => new Series(r)).FirstOrDefault();
        }

        public async Task<int> AddSeries(Series s)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsnyc("VuduSite_AddSeries", parameters));
        }

        public void UpdateSeries(Series s)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            dbHandler.ExecuteNonQuery("VuduSite_UpdateSeris", parameters);
        }

        public void DeleteSeries(int seriesId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = seriesId
                }
            };
            dbHandler.ExecuteNonQuery("VuduSite_DeleteSeries", parameters);
        }
        #endregion

        #region Rating
        public async Task<Rating> GetRating(int ratingId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = ratingId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsyc("VuduSite_GetRating", parameters);
            return dt.Select(r => new Rating(r)).FirstOrDefault();
        }

        public async Task<int> AddRating(Rating r)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsnyc("VuduSite_AddRating", parameters));
        }

        public void UpdateRating(Rating r)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
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
            dbHandler.ExecuteNonQuery("VuduSite_UpdateRating", parameters);
        }

        public void DeleteRating(int ratingId)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = ratingId
                }
            };
            dbHandler.ExecuteNonQuery("VuduSite_DeleteRating", parameters);
        }
        #endregion
    }
}
