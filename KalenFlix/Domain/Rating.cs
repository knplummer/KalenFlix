using System;
using System.Data;

namespace KalenFlix.Domain
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public double RatingValue { get; set; }
        public string Comments { get; set; }
        public DateTime AddDate { get; set; }
        public int AddUser { get; set; }
        public DateTime ChgDate { get; set; }
        public int ChgUser { get; set; }

        public Rating() { }

        public Rating(DataRow r)
        {
            RatingId = Convert.ToInt32(r["ratingid"]);
            MovieId = Convert.ToInt32(r["movieid"]);
            UserId = Convert.ToInt32(r["userid"]);
            RatingValue = Convert.ToDouble(r["rating"]);
            Comments = r["comments"]?.ToString();
            AddDate = Convert.ToDateTime(r["adddate"]);
            AddUser = Convert.ToInt32(r["adduser"]);
            ChgDate = Convert.ToDateTime(r["chgdate"]);
            ChgUser = Convert.ToInt32(r["chguser"]);
        }
    }
}
