using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LocalEventsSeminarski_API.Models;

namespace LocalEventsSeminarski_API.Controllers
{
    public class UlogaController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        [HttpGet]
        public List<esp_Uloga_SelectAll_Result> GetUlogas()
        {
            return db.esp_Uloga_SelectAll().ToList();
        }
        
        [HttpGet]
        [Route("api/Uloga/IsPosjetilac/{korisnikID}")]
        public bool IsPosjetilac(int korisnikID)
        {
            return db.KorisnikUlogas.Any(k => k.KorisnikID == korisnikID && k.UlogaID == 2);
        }

        [HttpGet]
        [Route("api/Uloga/IsAdmin/{korisnikID}")]
        public bool IsAdmin(int korisnikID)
        {
            return db.KorisnikUlogas.Any(k => k.KorisnikID == korisnikID && k.UlogaID == 1);
        }
    }
}
