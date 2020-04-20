using System;
using System.Data;
using KalenFlix.Annotations;

namespace KalenFlix.Domain
{
    public class Device
    {
        [DataColumn("Device_ID")]
        public int DeviceId { get; set; }
        [DataColumn("User_ID")]
        public int UserId { get; set; }
        [DataColumn("Device_Name")]
        public string DeviceName { get; set; }
        [DataColumn("Device_Type")]
        public string DeviceType { get; set; }
        [DataColumn("Add_Date")]
        public DateTime AddDate { get; set; }
        [DataColumn("Add_User")]
        public int AddUser { get; set; }
        [DataColumn("Chg_Date")]
        public DateTime? ChgDate { get; set; }
        [DataColumn("Chg_User")]
        public int? ChgUser { get; set; }
    }
}
