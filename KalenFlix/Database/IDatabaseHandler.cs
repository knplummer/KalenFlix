using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KalenFlix.Database
{
    public interface IDatabaseHandler
    {
        Task<DataTable> ExecuteQueryAsync(string storedProc, List<SqlParameter> parameters);
        DataTable ExecuteQuery(string storedProc, List<SqlParameter> parameters);
        Task<DataRow> ExecuteSingleRowQueryAsync(string storedProc, List<SqlParameter> parameters);
        DataRow ExecuteSingleRowQuery(string storedProc, List<SqlParameter> parameters);
        Task<object> ExecuteScalarAsync(string storedProc, List<SqlParameter> parameters);
        object ExecuteScalar(string storedProc, List<SqlParameter> parameters);
        void ExecuteNonQueryAsync(string storedProc, List<SqlParameter> parameters);
        void ExecuteNonQuery(string storedProc, List<SqlParameter> parameters);
    }
}