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
    
    public partial class Organizacija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organizacija()
        {
            this.Events = new HashSet<Event>();
            this.PosjetilacOrganizacijas = new HashSet<PosjetilacOrganizacija>();
        }
    
        public int OrganizacijaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Tip { get; set; }
        public byte[] SlikaLogo { get; set; }
        public int GradID { get; set; }
        public Nullable<double> AverageRating { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
        public virtual Grad Grad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PosjetilacOrganizacija> PosjetilacOrganizacijas { get; set; }
    }
}