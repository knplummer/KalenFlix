using System;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using KalenFlix.Domain;

namespace KalenFlix.Infrastructure
{
    public class AdminAreaRepo
    {
        private DatabaseHandler dbHandler { get; set; }
        
        public AdminAreaRepo()
        {
            dbHandler = new DatabaseHandler();
        }

        #region profile
        public async Task<User> SelectUser(int userId)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = userId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_AdminArea_GetUser", parameters);
            return dt.Select(r => new User(r)).FirstOrDefault();
        }

        public void UpdateUser(User u)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = u.UserId
                },
                new MySqlParameter()
                {
                    ParameterName = "lastname",
                    Value = u.LastName
                },
                new MySqlParameter()
                {
                    ParameterName = "firstname",
                    Value = u.FirstName
                },
                new MySqlParameter()
                {
                    ParameterName = "password",
                    Value = u.Password
                },
                new MySqlParameter()
                {
                    ParameterName = "chguser",
                    Value = u.ChgUser
                },
                new MySqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_UpdateUser", parameters);
        }

        public void DeleteUser(int userId)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = userId
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_DeleteUser", parameters);
        }
        #endregion

        #region Devices
        public async Task<List<Device>> SelectAllDevices()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_AdminArea_GeAllDevices", parameters);
            return dt.Select(r => new Device(r)).ToList();
        }

        public async Task<Device> GetDevice(int deviceId)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = deviceId
                }
            };
            var dt = await dbHandler.ExecuteQueryAsync("VuduSite_AdminArea_GetDevice", parameters);
            return dt.Select(r => new Device(r)).FirstOrDefault();
        }

        public async Task<int> InsertDevice(Device d)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "userid",
                    Value = d.UserId
                },
                new MySqlParameter()
                {
                    ParameterName = "devicename",
                    Value = d.DeviceName
                },
                new MySqlParameter()
                {
                    ParameterName = "devicetype",
                    Value = d.DeviceType
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
            return Convert.ToInt32(await dbHandler.ExecuteScalarAsync("VuduSite_AdminArea_AddDevice", parameters));
        }

        public void UpdateDevice(Device d)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = d.DeviceId
                },
                new MySqlParameter()
                {
                    ParameterName = "userid",
                    Value = d.UserId
                },
                new MySqlParameter()
                {
                    ParameterName = "devicename",
                    Value = d.DeviceName
                },
                new MySqlParameter()
                {
                    ParameterName = "devicetype",
                    Value = d.DeviceType
                },
                new MySqlParameter()
                {
                    ParameterName = "chguser",
                    Value = d.ChgUser
                },
                new MySqlParameter()
                {
                    ParameterName = "chgdate",
                    Value = DateTime.Now
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_UpdateDevice", parameters);
        }

        public void DeleteDevice(int deviceId)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = deviceId
                }
            };
            dbHandler.ExecuteNonQueryAsync("VuduSite_AdminArea_DeleteDevice", parameters);
        }

        internal async Task<List<Device>> SelectUserDevices(int userId)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter()
                {
                    ParameterName = "id",
                    Value = userId
                }
            };
            var db = await dbHandler.ExecuteQueryAsync("VuduSite_AdminArea_GetUserDevices", parameters);
            return db.Select(r => new Device(r)).ToList();
        }
        #endregion
    }
}
