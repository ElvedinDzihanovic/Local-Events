using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LocalEventsSeminarski_API.Models;

namespace LocalEventsSeminarski_API.Controllers
{
    public class KorisnikController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        [HttpGet]
        public List<esp_Korisnik_SelectAll_Result> GetKorisnici()
        {
            return db.esp_Korisnik_SelectAll().ToList();
        }

        [HttpGet]
        [Route("api/Korisnik/GetAllKorisnici/")]
        public List<esp_Korisnik_SelectAll_Result> GetAllKorisnici()
        {
            return db.esp_Korisnik_SelectAll().ToList();
        }
        
        [ResponseType(typeof(esp_Korisnik_GetByUsername_Result))]
        [Route("api/Korisnik/GetByUsername/{korisnickoIme}")]
        public IHttpActionResult GetByUsername(string korisnickoIme)
        {

            esp_Korisnik_GetByUsername_Result k =  db.esp_Korisnik_GetByUsername(korisnickoIme).FirstOrDefault();

            if (k == null)
                return NotFound();


            return Ok(k);
        }

        [Route("api/Korisnik/GetByID/{korisnikID}")]
        public esp_Korisnik_GetByID_Result GetByID(int korisnikID)
        {
            esp_Korisnik_GetByID_Result k = db.esp_Korisnik_GetByID(korisnikID).FirstOrDefault();

            return k;
        }
        //[ResponseType(typeof(esp_Korisnik_GetByKorisnickoIme_Result))]
        [Route("api/Korisnik/GetByKorisnickoIme/{korisnickoIme?}")]
        public esp_Korisnik_GetByKorisnickoIme_Result GetByKorisnickoIme(string korisnickoIme = "")
        {


            esp_Korisnik_GetByKorisnickoIme_Result k = db.esp_Korisnik_GetByKorisnickoIme(korisnickoIme).FirstOrDefault();
            
            return k;
        }

        private HttpResponseException CreateHttpExceptionMessage(string reason, HttpStatusCode code)
        {
            HttpResponseMessage msg = new HttpResponseMessage()
            {
                ReasonPhrase = reason,
                StatusCode = code,
                Content = new StringContent(reason)
            };

            return new HttpResponseException(msg);
        }

        [HttpGet]
        [Route("api/Korisnik/SearchByName/{name?}")]
        public List<esp_Korisnik_SelectByImePrezime_Result> SearchByName(string name = "")
        {
            return db.esp_Korisnik_SelectByImePrezime(name).ToList();
        }
        
        // POST: api/Korisnik
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult PostKorisnik(Korisnik k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                k.KorisnikID = Convert.ToInt32(db.esp_Korisnik_Insert(k.Ime, k.Prezime, k.Email,
                           k.Telefon, k.KorisnickoIme, k.LozinkaSalt, k.LozinkaHash, k.GradID, k.Slika, k.SlikaThumb).FirstOrDefault());

                foreach(var item in k.KorisnikUlogas)
                {
                    db.KorisnikUlogas.Add(new KorisnikUloga
                    {
                        KorisnikID = k.KorisnikID,
                        UlogaID = item.UlogaID,
                        DatumIzmjene = DateTime.Now
                    });
                }
                db.SaveChanges();
                
            }
            catch (EntityException ex)
            {
                if(ex.InnerException != null)
                    throw CreateHttpExceptionMessage(Util.ExceptionHandler.HandleException(ex), HttpStatusCode.Conflict);
            }

            return Ok(k.KorisnikID);

            //return CreatedAtRoute("DefaultApi", new { id = k.KorisnikID }, k);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKorisnik(int id, Korisnik editedKorisnik)
        {
            if (id != editedKorisnik.KorisnikID)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //update korisnik...
            db.esp_Korisnik_Update(editedKorisnik.KorisnikID, editedKorisnik.Ime, editedKorisnik.Prezime, editedKorisnik.Email, editedKorisnik.Telefon, editedKorisnik.KorisnickoIme, editedKorisnik.LozinkaSalt, editedKorisnik.LozinkaHash, editedKorisnik.Status, editedKorisnik.GradID);

            return Ok();
        }

        [HttpGet]
        [Route("api/Korisnik/UpdateKorisnik/{korisnikID}/{ime}/{prezime}/{email}/{gradID}/{korisnickoIme}/{lozinkaSalt}/{lozinkaHash}")]
        public IHttpActionResult UpdateKorisnik(int korisnikID, string ime, string prezime, string email, int gradID, string korisnickoIme, string lozinkaSalt, string lozinkaHash)
        {
            Korisnik kor = db.Korisniks.FirstOrDefault(k => k.KorisnikID == korisnikID);

            db.esp_Korisnik_Update(kor.KorisnikID, ime, prezime, email, kor.Telefon, korisnickoIme, lozinkaSalt, lozinkaHash, kor.Status, gradID);


            return Ok();
        }
    }
}
