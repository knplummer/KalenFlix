using System;
using KalenFlix.Annotations;

namespace KalenFlix.Domain
{
    public class Movie
    {
        [DataColumn("Movie_ID")]
        public int MovieId { get; set; }
        [DataColumn("Title")]
        public string Title { get; set; }
        [DataColumn("Imdb_Link")]
        public string ImdbLink { get; set; }
        [DataColumn("Vudu_Link")]
        public string VuduLink { get; set; }
        [DataColumn("Trailer_Link")]
        public string TrailerLink { get; set; }
        [DataColumn("Release_Year")]
        public int ReleaseYear { get; set; }
        [DataColumn("Release_Date")]
        public DateTime ReleaseDate { get; set; }
        [DataColumn("Imdb_Rating")]
        public double ImdbRating { get; set; }
        [DataColumn("Mpaa_Rating")]
        public string MpaaRating { get; set; }
        [DataColumn("Director_ID")]
        public int DirectorId { get; set; }
        [DataColumn("Co_Directore_ID")]
        public int? CoDirectorId { get; set; }
        [DataColumn("Series_ID")]
        public int? SeriesId { get; set; }
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
