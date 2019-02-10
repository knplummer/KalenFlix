﻿using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KalenFlix
{
    public class DatabaseHandeler
    {

        public async Task<List<DataRow>> ExecuteQuery(string storedProc, List<MySqlParameter> parameters)
        {
            using (var db = new DatabaseConnection())
            {
                await db.Connection.OpenAsync();
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProc;
                foreach(var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                return await DtEnumberable(await cmd.ExecuteReaderAsync());
            }
        }
        public async Task<List<DataRow>> DtEnumberable(DbDataReader reader)
        {
            DataTable dt = new DataTable("SqlTable");
            List<DataRow> rows = new List<DataRow>();
            using (reader)
            {
                for (int f = 0; f < reader.FieldCount; f++)
                {
                    DataColumn col = new DataColumn();
                    col.DataType = typeof(object);
                    col.ColumnName = reader.GetName(f);
                    dt.Columns.Add(col);

                }
                while (await reader.ReadAsync())
                {
                    DataRow r = dt.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var type = reader.GetFieldType(i);
                        r[reader.GetName(i)] = reader.GetFieldValueAsync<object>(i);
                    }
                    rows.Add(r);
                }
                return rows;
            }
        }
    }
}