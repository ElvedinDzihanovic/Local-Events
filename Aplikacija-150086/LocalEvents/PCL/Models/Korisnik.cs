using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public bool Status { get; set; }
        public int GradID { get; set; }
        public List<KorisnikUloga> KorisnikUlogas { get; set; }
        
    }
    public class KorisnikUloga
    {
        public int KorisnikUlogaID { get; set; }
        public int KorisnikID { get; set; }
        public int UlogaID { get; set; }
        public DateTime DatumIzmjene { get; set; }
    }
}
