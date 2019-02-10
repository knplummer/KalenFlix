using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace KalenFlix
{
    public class DatabaseConnection : IDisposable
    {
        public MySqlConnection Connection;

        string connectionString = "server=127.0.0.1;port=3306;user=root;password=Uoflcards1!;database=vudu_site;";

        public DatabaseConnection()
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
