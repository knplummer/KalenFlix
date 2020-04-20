using System;
using KalenFlix.Annotations;

namespace KalenFlix.Domain
{
    public class Rating
    {
        [DataColumn("Rating_ID")]
        public int RatingId { get; set; }
        [DataColumn("Movie_ID")]
        public int MovieId { get; set; }
        [DataColumn("User_ID")]
        public int UserId { get; set; }
        [DataColumn("Rating_Value")]
        public double RatingValue { get; set; }
        [DataColumn("Comments")]
        public string Comments { get; set; }
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
