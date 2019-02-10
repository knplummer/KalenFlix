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
            var dt = await dbHandler.ExecuteQuery("VuduSite_GetAllMovies", parameters);
            return dt.Select(r => new Movie(r)).ToList();
        }
    }
}
