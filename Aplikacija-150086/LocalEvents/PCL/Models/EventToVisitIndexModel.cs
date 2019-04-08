using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class EventToVisitIndexModel
    {
        /*
        public int PosjetilacID { get; set; }
        public int EventID { get; set; }
        public bool Prisustvovao { get; set; }
        public int? EventRating { get; set; }
        public DateTime? RatingDate { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentDate { get; set; }
        */
        public int PosjetilacID { get; set; }
        public int EventID { get; set; }
        public string EventNaziv { get; set; }
        public byte[] SlikaThumb { get; set; }
        public Nullable<System.DateTime> DatumOdrzavanja { get; set; }
        public string LokacijaNaziv { get; set; }
        public string Status { get; set; }

        
    }
}
