using System;
using System.Data;
using KalenFlix.Annotations;

namespace KalenFlix.Domain
{
    public class Director
    {
        [DataColumn("Director_ID")]
        public int DirectorId { get; set; }
        [DataColumn("Last_Name")]
        public string LastName { get; set; }
        [DataColumn("First_Name")]
        public string FirstName { get; set; }
        [DataColumn("Imdb_Link")]
        public string ImdbLink { get; set; }
        [DataColumn("Add_Date")]
        public DateTime AddDate { get; set; }
        [DataColumn("Add_User")]
        public int AddUser { get; set; }
        [DataColumn("Chg_Date")]
        public DateTime? ChgDate { get; set; }
        [DataColumn("Chg_Date")]
        public int? ChgUser { get; set; }
    }
}
