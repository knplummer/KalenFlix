using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalenFlix.Domain;

namespace KalenFlix.Infrastructure
{
    public interface IAdminAreaRepo
    {
        Task<User> SelectUser(int userId);
        void UpdateUser(User u);
        void DeleteUser(int userId);
        Task<IEnumerable<Device>> SelectAllDevices();
        Task<Device> GetDevice(int deviceId);
        Task<int> InsertDevice(Device d);
        void UpdateDevice(Device d);
        void DeleteDevice(int deviceId);
        Task<IEnumerable<Device>> SelectUserDevices(int userId);
    }
}
