using System;
using System.Data;

namespace KalenFlix.Domain
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImdbLink { get; set; }
        public string VuduLink { get; set; }
        public string TrailerLink { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double ImdbRating { get; set; }
        public string MpaaRating { get; set; }
        public int DirectorId { get; set; }
        public int? CoDirectorId { get; set; }
        public int? SeriesId { get; set; }
        public DateTime AddDate { get; set; }
        public int AddUser { get; set; }
        public DateTime ChgDate { get; set; }
        public int ChgUser { get; set; }

        public Movie(DataRow r)
        {
            MovieId = Convert.ToInt32(r["movieid"]);
            Title = r["title"].ToString();
            ImdbLink = r["imdblink"].ToString();
            VuduLink = r["vudulink"].ToString();
            TrailerLink = r["trailerlink"].ToString();
            Genre = r["genre"].ToString();
            ReleaseYear = Convert.ToInt32(r["releaseyear"]);
            ReleaseDate = Convert.ToDateTime(r["releasedate"]);
            ImdbRating = Convert.ToDouble(r["imdbrating"]);
            MpaaRating = r["mpaarating"].ToString();
            DirectorId = Convert.ToInt32(r["directorid"]);
            CoDirectorId = r["codirectorid"] == DBNull.Value ? null : (int?)r["codirectorid"];
            SeriesId = r["seriesid"] == DBNull.Value ? null : (int?)r["seriesid"];
            AddDate = Convert.ToDateTime(r["adddate"]);
            AddUser = Convert.ToInt32(r["adduser"]);
            ChgDate = Convert.ToDateTime(r["chgdate"]);
            ChgUser = Convert.ToInt32(r["chguser"]);
        }
    }
}
