using System;
using System.Data;

namespace KalenFlix.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public DateTime AddDate { get; set; }
        public int AddUser { get; set; }
        public DateTime ChgDate { get; set; }
        public int ChgUser { get; set; }

        public User() { }

        public User(DataRow r)
        {
            UserId = Convert.ToInt32(r["userid"]);
            LastName = r["lastname"].ToString();
            FirstName = r["firstname"].ToString();
            Password = r["password"].ToString();
            AddDate = Convert.ToDateTime(r["adddate"]);
            AddUser = Convert.ToInt32(r["adduser"]);
            ChgDate = Convert.ToDateTime(r["chgdate"]);
            ChgUser = Convert.ToInt32(r["chguser"]);
        }
    }
}
