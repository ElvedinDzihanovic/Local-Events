using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class EventToVisit
    {
        public int? EventID { get; set; }
        public int? PosjetilacID { get; set; }
        public int? EventRating { get; set; }
        public DateTime? RatingDate { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
