using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Models
{
    public class Organizacija
    {
        public int OrganizacijaID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Opis { get; set; }
        public string GradNaziv { get; set; }
        public byte[] SlikaLogo { get; set; }
    }
}
