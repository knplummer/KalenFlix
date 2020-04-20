using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KalenFlix.Database
{
    public class DatabaseHandler : IDatabaseHandler
    {
        public async Task<DataTable> ExecuteQueryAsync(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                await db.Connection.OpenAsync();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                DataTable dt = new DataTable();
                dt.Load(await cmd.ExecuteReaderAsync());
                return dt;
            }
        }

        public async Task<DataRow> ExecuteSingleRowQueryAsync(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                await db.Connection.OpenAsync();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                DataTable dt = new DataTable();
                dt.Load(await cmd.ExecuteReaderAsync());
                return dt.Rows.Count > 0 ? dt.Rows[0] : dt.NewRow();
            }
        }

        public DataRow ExecuteSingleRowQuery(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                db.Connection.Open();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count > 0 ? dt.Rows[0] : dt.NewRow();
            }
        }

        public DataTable ExecuteQuery(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                db.Connection.Open();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public async Task<object> ExecuteScalarAsync(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                await db.Connection.OpenAsync();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                return await cmd.ExecuteScalarAsync();
            }
        }

        public object ExecuteScalar(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                db.Connection.Open();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                return cmd.ExecuteScalar();
            }
        }

        public async void ExecuteNonQueryAsync(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                await db.Connection.OpenAsync();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public void ExecuteNonQuery(string storedProc, List<SqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                db.Connection.Open();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }
}