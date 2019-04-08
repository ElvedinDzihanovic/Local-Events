using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class Lokacija
    {
        public int LokacijaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? Kapacitet { get; set; }
        public string Adresa { get; set; }
        public string GradNaziv { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public float AverageRating { get; set; }
        public string LokacijaTipNaziv { get; set; }
        public string LokacijaTip { get; set; }
    }
}
