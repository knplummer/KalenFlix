using System;
using KalenFlix.Annotations;

namespace KalenFlix.Domain
{
    public class Series
    {
        [DataColumn("Series_ID")]
        public int SeriesId { get; set; }
        [DataColumn("Series_Title")]
        public string SeriesTitle { get; set; }
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
