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
    
    public partial class esp_Event_GetComments_Result
    {
        public int EventID { get; set; }
        public string Naziv { get; set; }
        public string KorisnickoIme { get; set; }
        public Nullable<int> EventRating { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> CommentDate { get; set; }
        public Nullable<System.DateTime> RatingDate { get; set; }
    }
}
