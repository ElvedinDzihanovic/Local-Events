using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class EventGallery
    {
        public int EventGalleryID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }

        //naknadno dodao...
        public int EventID { get; set; }
    }
}
