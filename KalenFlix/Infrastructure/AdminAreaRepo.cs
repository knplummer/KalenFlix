using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using KalenFlix.Domain;
using KalenFlix.Database;

namespace KalenFlix.Infrastructure
{
    public class AdminAreaRepo : IAdminAreaRepo
    {
        private IDatabaseHandler _dbHandler { get; set; }
        
        public AdminAreaRepo(IDatabaseHandler dbHandler)
        {
            dbHandler = _dbHandler;
        }

        #region profile
        public async Task<User> SelectUser(int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = userId
                }
            };
            return new DataMapper<User>().Map(await _dbHandler.ExecuteSingleRowQueryAsync("VuduSite_AdminArea_GetUser", parameters));
        }

        public void UpdateUser(User u)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = u.UserId
                },
                new SqlParameter()
                {
                    ParameterName = "lastname",
                    Value = u.LastName
                },
                new SqlParameter()
                {
                    ParameterName = "firstname",
                    Value = u.FirstName
                },
                new SqlParameter()
                {
                    ParameterName = "password",
                    Value = u.Password
                },
                new SqlParameter()
                {
                    ParameterName = "chguser",
                    Value = u.ChgUser
                },
                new SqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_UpdateUser", parameters);
        }

        public void DeleteUser(int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = userId
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_DeleteUser", parameters);
        }
        #endregion

        #region Devices
        public async Task<IEnumerable<Device>> SelectAllDevices()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return new DataMapper<Device>().Map(await _dbHandler.ExecuteQueryAsync("VuduSite_AdminArea_GeAllDevices", parameters));
        }

        public async Task<Device> GetDevice(int deviceId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = deviceId
                }
            };
            return new DataMapper<Device>().Map(await _dbHandler.ExecuteSingleRowQueryAsync("VuduSite_AdminArea_GetDevice", parameters));
        }

        public async Task<int> InsertDevice(Device d)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "userid",
                    Value = d.UserId
                },
                new SqlParameter()
                {
                    ParameterName = "devicename",
                    Value = d.DeviceName
                },
                new SqlParameter()
                {
                    ParameterName = "devicetype",
                    Value = d.DeviceType
                },
                new SqlParameter()
                {
                    ParameterName = "adduser",
                    Value = d.AddUser
                },
                new SqlParameter()
                {
                    ParameterName = "adddate",
                    Value = DateTime.Now
                }
            };
            return Convert.ToInt32(await _dbHandler.ExecuteScalarAsync("VuduSite_AdminArea_AddDevice", parameters));
        }

        public void UpdateDevice(Device d)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = d.DeviceId
                },
                new SqlParameter()
                {
                    ParameterName = "userid",
                    Value = d.UserId
                },
                new SqlParameter()
                {
                    ParameterName = "devicename",
                    Value = d.DeviceName
                },
                new SqlParameter()
                {
                    ParameterName = "devicetype",
                    Value = d.DeviceType
                },
                new SqlParameter()
                {
                    ParameterName = "chguser",
                    Value = d.ChgUser
                },
                new SqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_UpdateDevice", parameters);
        }

        public void DeleteDevice(int deviceId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = deviceId
                }
            };
            _dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_DeleteDevice", parameters);
        }

        internal async Task<IEnumerable<Device>> SelectUserDevices(int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "id",
                    Value = userId
                }
            };
            return new DataMapper<Device>().Map(await _dbHandler.ExecuteQueryAsync("VuduSite_AdminArea_GetUserDevices", parameters));
        }
        #endregion
    }
}
