//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocalEventsSeminarski_API.Models
{
    using System;
    
    public partial class esp_Event_GetDetails_Result
    {
        public int EventID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string DatumKreiranja { get; set; }
        public string DatumOdrzavanja { get; set; }
        public string KorisnickoIme { get; set; }
        public double AverageRating { get; set; }
        public string VrijemePocetka { get; set; }
        public string VrijemeZavrsetka { get; set; }
        public byte[] SlikaThumb { get; set; }
        public string Status { get; set; }
        public Nullable<int> OrganizacijaID { get; set; }
        public int LokacijaID { get; set; }
        public string EventTip { get; set; }
        public string Organizacija { get; set; }
        public string Lokacija { get; set; }
    }
}
