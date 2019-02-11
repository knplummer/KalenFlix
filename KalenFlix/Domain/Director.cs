using System;
using System.Data;

namespace KalenFlix.Domain
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ImdbLink { get; set; }
        public DateTime AddDate { get; set; }
        public int AddUser { get; set; }
        public DateTime ChgDate { get; set; }
        public int ChgUser { get; set; }

        public Director() { }

        public Director(DataRow r)
        {
            DirectorId = Convert.ToInt32(r["directorid"]);
            LastName = r["lastname"].ToString();
            FirstName = r["firstname"].ToString();
            ImdbLink = r["imdblink"].ToString();
            AddDate = Convert.ToDateTime(r["adddate"]);
            AddUser = Convert.ToInt32(r["adduser"]);
            ChgDate = Convert.ToDateTime(r["chgdate"]);
            ChgUser = Convert.ToInt32(r["chguser"]);
        }
    }
}
