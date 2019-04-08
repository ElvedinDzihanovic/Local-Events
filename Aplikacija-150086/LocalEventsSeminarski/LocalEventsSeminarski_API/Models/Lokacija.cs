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
    using System.Collections.Generic;
    
    public partial class Lokacija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lokacija()
        {
            this.Events = new HashSet<Event>();
            this.PosjetilacLokacijas = new HashSet<PosjetilacLokacija>();
        }
    
        public int LokacijaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public Nullable<int> Kapacitet { get; set; }
        public string Adresa { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public Nullable<double> AverageRating { get; set; }
        public int GradID { get; set; }
        public int LokacijaTipID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual LokacijaTip LokacijaTip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PosjetilacLokacija> PosjetilacLokacijas { get; set; }
    }
}