using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LocalEventsSeminarski_API.Models;

namespace LocalEventsSeminarski_API.Controllers
{
    public class SlikaController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        // GET: api/Slika
        public IQueryable<Slika> GetSlikas()
        {
            return db.Slikas;
        }

        // GET: api/Slika/5
        [ResponseType(typeof(Slika))]
        public IHttpActionResult GetSlika(int id)
        {
            Slika slika = db.Slikas.Find(id);
            if (slika == null)
            {
                return NotFound();
            }

            return Ok(slika);
        }

        [Route("api/Slika/GetByGalleryID/{galleryID}")]
        public List<esp_Slika_GetByGallery_Result> GetByGalleryID(int galleryID)
        {
            return db.esp_Slika_GetByGallery(galleryID).ToList();
        }

        [HttpGet]
        [Route("api/Slika/GetSlikaByID/{slikaID}")]
        public GetSlikaByID_Result GetSlikaByID(int slikaID)
        {
            return db.GetSlikaByID(slikaID).FirstOrDefault();
        }
        
        // PUT: api/Slika/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSlika(int id, Slika slika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != slika.SlikaID)
            {
                return BadRequest();
            }

            //slika update...
            db.esp_Slika_Update(id, slika.Opis);

            //return StatusCode(HttpStatusCode.NoContent);
            return Ok();
        }

        // POST: api/Slika
        [HttpPost]
        [ResponseType(typeof(Slika))]
        public IHttpActionResult PostSlika(Slika slika)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            slika.SlikaID = Convert.ToInt32(db.esp_Slika_Insert(slika.EventGalleryID, slika.Slika1, slika.SlikaThumb, slika.Opis).FirstOrDefault());

            return CreatedAtRoute("DefaultApi", new { id = slika.SlikaID }, slika);
        }

        // DELETE: api/Slika/5
        [ResponseType(typeof(Slika))]
        public IHttpActionResult DeleteSlika(int id)
        {
            Slika slika = db.Slikas.Find(id);
            if (slika == null)
            {
                return NotFound();
            }

            db.Slikas.Remove(slika);
            db.SaveChanges();

            return Ok(slika);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SlikaExists(int id)
        {
            return db.Slikas.Count(e => e.SlikaID == id) > 0;
        }
    }
}