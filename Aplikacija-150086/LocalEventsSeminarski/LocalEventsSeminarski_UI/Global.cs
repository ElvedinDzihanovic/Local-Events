using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalEventsSeminarski_API.Models;

namespace LocalEventsSeminarski_UI
{
    public static class Global
    {
        public static Korisnik prijavljeniKorisnik { get; set; }

        #region API Routes

        public const string KorisnikRoute = "api/Korisnik";
        public const string UlogaRoute = "api/Uloga";
        public const string GradRoute = "api/Grad";
        public const string LokacijaRoute = "api/Lokacija";
        public const string LokacijaTipRoute = "api/LokacijaTip";
        public const string OrganizacijaRoute = "api/Organizacija";
        public const string EventTipRoute = "api/EventTip";
        public const string EventRoute = "api/Event";
        public const string AgeRangeRoute = "api/AgeRange";
        public const string EventGalleryRoute = "api/EventGallery";
        public const string SlikaRoute = "api/Slika";
        public const string PosjetilacRoute = "api/Posjetilac";
        #endregion
    }
}
