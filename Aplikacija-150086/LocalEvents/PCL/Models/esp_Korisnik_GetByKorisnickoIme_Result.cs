using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class esp_Korisnik_GetByKorisnickoIme_Result
    {
        public int KorisnikID { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public byte[] SlikaThumb { get; set; }
    }
}