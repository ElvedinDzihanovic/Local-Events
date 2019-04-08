using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class EventComment
    {
        public int EventID { get; set; }
        public string Naziv { get; set; }
        public string KorisnickoIme { get; set; }
        public int? EventRating { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentDate { get; set; }
        public DateTime? RatingDate { get; set; }
    }
}
