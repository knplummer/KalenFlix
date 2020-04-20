using System;
using System.Configuration;
using System.Data.SqlClient;

namespace KalenFlix.Database
{
    class DatabaseConnection : IDisposable
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["KalenFlixDB"].ConnectionString;
        public SqlConnection Connection;

        public DatabaseConnection()
        {
            Connection = new SqlConnection(ConnectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
