using System;
using System.Data;

namespace KalenFlix.Domain
{
    public class Device
    {
        public int DeviceId { get; set; }
        public int UserId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public DateTime AddDate { get; set; }
        public int AddUser { get; set; }
        public DateTime ChgDate { get; set; }
        public int ChgUser { get; set; }

        public Device() { }

        public Device(DataRow r)
        {
            DeviceId = Convert.ToInt32(r["deviceid"]);
            UserId = Convert.ToInt32(r["userid"]);
            DeviceName = r["devicename"].ToString();
            DeviceType = r["devicetype"].ToString();
            AddDate = Convert.ToDateTime(r["adddate"]);
            AddUser = Convert.ToInt32(r["adduser"]);
            ChgDate = Convert.ToDateTime(r["chgdate"]);
            ChgUser = Convert.ToInt32(r["chguser"]);
        }
    }
}
