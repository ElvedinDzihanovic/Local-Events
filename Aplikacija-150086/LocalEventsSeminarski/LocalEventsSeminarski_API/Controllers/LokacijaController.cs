using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LocalEventsSeminarski_API.Models;
using LocalEventsSeminarski_API.Util;

namespace LocalEventsSeminarski_API.Controllers
{
    public class LokacijaController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        // GET: api/Lokacija
        
        public List<esp_Lokacija_SelectAll_Result> GetLokacijas()
        {
            return db.esp_Lokacija_SelectAll("").ToList();
        }
        
        [Route("api/Lokacija/GetById/{lokacijaID}")]
        public esp_Lokacija_GetByID_Result GetById(int lokacijaID)
        {
            return db.esp_Lokacija_GetByID(lokacijaID).FirstOrDefault();
        }

        
        [HttpGet]
        [Route ("api/Lokacija/GetLokacijaList/")]
        public List<esp_Lokacija_GetLokacijaList_Result> GetLokacijaList()
        {
            return db.esp_Lokacija_GetLokacijaList().ToList();
        }
        
        [HttpGet]
        [Route("api/Lokacija/UpdateIsFavorite/{posjetilacID}/{lokacijaID}/{isFavorite}/{something}")]
        public IHttpActionResult UpdateIsFavorite(int posjetilacID, int lokacijaID, int isFavorite, string something)
        {
            if (db.PosjetilacLokacijas.Any(p => p.PosjetilacID == posjetilacID && p.LokacijaID == lokacijaID))
                db.esp_PosjetilacLokacija_UpdateFavoriteStatus(posjetilacID, lokacijaID, Convert.ToBoolean(isFavorite));
            else { 
                db.esp_PosjetilacLokacija_Insert(posjetilacID, lokacijaID, null, null);
                db.esp_PosjetilacLokacija_UpdateFavoriteStatus(posjetilacID, lokacijaID, Convert.ToBoolean(isFavorite));
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/Lokacija/GetFavoriteLokacijas/{posjetilacID}")]
        public List<esp_Lokacija_GetFavoriteLokacijas_Result> GetFavoriteLokacijas(int posjetilacID) 
        {
            return db.esp_Lokacija_GetFavoriteLokacijas(posjetilacID).ToList();
        }

        [HttpGet]
        [Route("api/Lokacija/GetTopFive/{gradID}")]
        public List<esp_Lokacija_GetTop5ByGrad_Result> GetTopFive(int gradID)
        {
            return db.esp_Lokacija_GetTop5ByGrad(gradID).ToList();
        }


        [HttpGet]
        [Route("api/Lokacija/UpdatePosjetilacLokacija/{posjetilacID}/{lokacijaID}/{comment}/{rating}")]
        public IHttpActionResult UpdatePosjetilacLokacija(int posjetilacID, int lokacijaID, string comment, string rating)
        {
            if (db.PosjetilacLokacijas.Any(p => p.LokacijaID == lokacijaID && p.PosjetilacID == posjetilacID))
                db.esp_PosjetilacLokacija_UpdateAll(posjetilacID, lokacijaID, comment, Convert.ToInt32(rating));
            else
                db.esp_PosjetilacLokacija_Insert(posjetilacID, lokacijaID, Convert.ToInt32(rating), comment);


            List<PosjetilacLokacija> lokacijaRatings = db.PosjetilacLokacijas.Where(p => p.LokacijaID == lokacijaID && p.LocationRating.HasValue).ToList();

            if (lokacijaRatings.Count > 0)
            {
                double ocjena = 0;
                int count = lokacijaRatings.Count;

                foreach (var item in lokacijaRatings)
                {
                    if(item.LocationRating.Value > 0)
                        ocjena += item.LocationRating.Value;
                }

                db.Lokacijas.FirstOrDefault(l => l.LokacijaID == lokacijaID).AverageRating = ocjena / count;
                db.SaveChanges();
            }


            return Ok();
        }
        
        [Route("api/Lokacija/GetPosjetilacLokacijaByID/{posjetilacID}/{lokacijaID}")]
        public esp_PosjetilacLokacija_GetByID_Result GetPosjetilacLokacijaByID(int posjetilacID, int lokacijaID)
        {
            //if (db.PosjetilacLokacijas.Any(p => p.LokacijaID == lokacijaID && p.PosjetilacID == posjetilacID))
                return db.esp_PosjetilacLokacija_GetByID(posjetilacID, lokacijaID).FirstOrDefault();
        }

        [Route("api/Lokacija/GetComments/{lokacijaID}")]
        public List<esp_Lokacija_GetComments_Result> GetComments(int lokacijaID)
        {
            return db.esp_Lokacija_GetComments(lokacijaID).ToList();
        }
        // GET: api/Lokacija/5
        [ResponseType(typeof(Lokacija))]
        public IHttpActionResult GetLokacija(int id)
        {
            Lokacija lokacija = db.Lokacijas.Find(id);
            if (lokacija == null)
            {
                return NotFound();
            }

            return Ok(lokacija);
        }

        
        [HttpGet]
        [Route("api/Lokacija/SelectAll/{naziv?}")]
        public List<esp_Lokacija_SelectAll_Result> SelectAll(string naziv="")
        {
            return db.esp_Lokacija_SelectAll(naziv).ToList();
        }
        
        [HttpGet]
        [Route("api/Lokacija/GetSimilarLokacijas/{lokacijaID}")]
        public List<esp_Lokacija_GetLokacijaList_Result> GetSimilarLokacijas(int lokacijaID)
        {
            Recommender r = new Recommender();
            return r.GetSimilarLokacijas(lokacijaID);
        }

        // PUT: api/Lokacija/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLokacija(int id, Lokacija lokacija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lokacija.LokacijaID)
            {
                return BadRequest();
            }
            
            db.esp_Lokacija_Update(lokacija.LokacijaID, lokacija.Naziv, lokacija.Opis, 
                lokacija.Kapacitet, lokacija.Adresa, lokacija.GradID, lokacija.LokacijaTipID);

            return StatusCode(HttpStatusCode.NoContent);
        }
        
        // POST: api/Lokacija
        [ResponseType(typeof(Lokacija))]
        public IHttpActionResult PostLokacija(Lokacija lokacija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                lokacija.LokacijaID = Convert.ToInt32(db.esp_Lokacija_Input(lokacija.Naziv, lokacija.Opis, lokacija.Kapacitet, lokacija.Adresa, lokacija.Slika, lokacija.SlikaThumb, lokacija.AverageRating, lokacija.GradID, lokacija.LokacijaTipID).FirstOrDefault());
            }
            catch (EntityException ex)
            {
                if (ex.InnerException != null)
                    throw CreateHttpExceptionMessage(Util.ExceptionHandler.HandleException(ex), HttpStatusCode.Conflict);
            }

            return CreatedAtRoute("DefaultApi", new { id = lokacija.LokacijaID }, lokacija);
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


        // DELETE: api/Lokacija/5
        [ResponseType(typeof(Lokacija))]
        public IHttpActionResult DeleteLokacija(int id)
        {
            Lokacija lokacija = db.Lokacijas.Find(id);
            if (lokacija == null)
            {
                return NotFound();
            }

            db.Lokacijas.Remove(lokacija);
            db.SaveChanges();

            return Ok(lokacija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LokacijaExists(int id)
        {
            return db.Lokacijas.Count(e => e.LokacijaID == id) > 0;
        }
    }
}