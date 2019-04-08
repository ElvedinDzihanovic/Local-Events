using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string DatumKreiranja { get; set; }
        public string DatumOdrzavanja { get; set; }
        public string Kreator { get; set; }
        public double AverageRating { get; set; }
        public string VrijemePocetka { get; set; }
        public string VrijemeZavrsetka { get; set; }
        public byte[] SlikaThumb { get; set; }
        public string Status { get; set; }
        public string EventTip { get; set; }
        public string Organizacija { get; set; }
        public string Lokacija { get; set; }
    }
}
