using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class EventFilteredResult
    {
        public int EventID { get; set; }
        public int LokacijaID { get; set; }
        public string Naziv { get; set; }
        public string LokacijaNaziv { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public byte[] SlikaThumb { get; set; }
    }
}
