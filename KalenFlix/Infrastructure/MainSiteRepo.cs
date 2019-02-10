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
                    ParameterName = "@movieid",
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
                    ParameterName = "@title",
                    Value = m.Title
                },
                new MySqlParameter()
                {
                    ParameterName = "@imdblink",
                    Value = m.ImdbLink
                },
                new MySqlParameter()
                {
                    ParameterName = "@vudulink",
                    Value = m.VuduLink
                },
                new MySqlParameter()
                {
                    ParameterName = "@trailerlink",
                    Value = m.TrailerLink
                },
                new MySqlParameter()
                {
                    ParameterName = "@genre",
                    Value = m.Genre
                },
                new MySqlParameter()
                {
                    ParameterName = "@releaseyear",
                    Value = m.ReleaseYear
                },
                new MySqlParameter()
                {
                    ParameterName = "@imdbrating",
                    Value = m.ImdbRating
                },
                new MySqlParameter()
                {
                    ParameterName = "@mpaarating",
                    Value = m.MpaaRating
                },
                new MySqlParameter()
                {
                    ParameterName = "@directorid",
                    Value = m.DirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "@codirectorid",
                    Value = m.CoDirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "@seriesid",
                    Value = m.SeriesId
                },
                new MySqlParameter()
                {
                    ParameterName = "@adduser",
                    Value = m.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "@adddate",
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
                    ParameterName = "@movieid",
                    Value = m.MovieId
                },
                new MySqlParameter()
                {
                    ParameterName = "@title",
                    Value = m.Title
                },
                new MySqlParameter()
                {
                    ParameterName = "@imdblink",
                    Value = m.ImdbLink
                },
                new MySqlParameter()
                {
                    ParameterName = "@vudulink",
                    Value = m.VuduLink
                },
                new MySqlParameter()
                {
                    ParameterName = "@trailerlink",
                    Value = m.TrailerLink
                },
                new MySqlParameter()
                {
                    ParameterName = "@genre",
                    Value = m.Genre
                },
                new MySqlParameter()
                {
                    ParameterName = "@releaseyear",
                    Value = m.ReleaseYear
                },
                new MySqlParameter()
                {
                    ParameterName = "@imdbrating",
                    Value = m.ImdbRating
                },
                new MySqlParameter()
                {
                    ParameterName = "@mpaarating",
                    Value = m.MpaaRating
                },
                new MySqlParameter()
                {
                    ParameterName = "@directorid",
                    Value = m.DirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "@codirectorid",
                    Value = m.CoDirectorId
                },
                new MySqlParameter()
                {
                    ParameterName = "@seriesid",
                    Value = m.SeriesId
                },
                new MySqlParameter()
                {
                    ParameterName = "@adduser",
                    Value = m.AddUser
                },
                new MySqlParameter()
                {
                    ParameterName = "@adddate",
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
                    ParameterName = "@movieid",
                    Value = movieId
                }
            };
            dbHandler.ExecuteNonQuery("VuduSite_DeleteMovie", parameters);
        }
    }
}
