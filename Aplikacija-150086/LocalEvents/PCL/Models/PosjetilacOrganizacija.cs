using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class PosjetilacOrganizacija
    {
        public int PosjetilacID { get; set; }
        public int OrganizacijaID { get; set; }
        public int? LocationRating { get; set; }
        public DateTime? RatingDate { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentDate { get; set; }
        public string OrganizacijaNaziv { get; set; }
    }
}
