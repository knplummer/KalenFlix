using System;
using KalenFlix.Annotations;

namespace KalenFlix.Domain
{
    public class User
    {
        [DataColumn("User_ID")]
        public int UserId { get; set; }
        [DataColumn("Last_Name")]
        public string LastName { get; set; }
        [DataColumn("First_Name")]
        public string FirstName { get; set; }
        [DataColumn("Password")]
        public string Password { get; set; }
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
