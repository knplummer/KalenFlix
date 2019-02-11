using System;
using System.Data;

namespace KalenFlix.Domain
{
    public class Series
    {
        public int SeriesId { get; set; }
        public string SeriesTitle { get; set; }
        public DateTime AddDate { get; set; }
        public int AddUser { get; set; }
        public DateTime ChgDate { get; set; }
        public int ChgUser { get; set; }

        public Series() { }

        public Series(DataRow r)
        {
            SeriesId = Convert.ToInt32(r["seriesid"]);
            SeriesTitle = r["seriestitle"].ToString();
            AddDate = Convert.ToDateTime(r["adddate"]);
            AddUser = Convert.ToInt32(r["adduser"]);
            ChgDate = Convert.ToDateTime(r["chgdate"]);
            ChgUser = Convert.ToInt32(r["chguser"]);
        }
    }
}
