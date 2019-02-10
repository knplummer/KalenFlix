using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace KalenFlix
{
    public class DatabaseConnection : IDisposable
    {
        public MySqlConnection Connection;
        public IConfiguration Configuration { get; }

        public DatabaseConnection()
        {
            Connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
