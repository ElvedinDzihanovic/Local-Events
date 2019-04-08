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
    public class EventGalleryController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        // GET: api/EventGallery
        public IQueryable<EventGallery> GetEventGalleries()
        {
            return db.EventGalleries;
        }
        
        [Route("api/EventGallery/GetByEvent/{eventID}")]
        public List<esp_EventGallery_GetByEvent_Result> GetByEvent(int eventID)
        {
            return db.esp_EventGallery_GetByEvent(eventID).ToList();
        }

        [HttpGet]
        [Route("api/EventGallery/GetByID/{galleryID}")]
        public esp_EventGallery_GetByID_Result GetByID(int galleryID)
        {
            return db.esp_EventGallery_GetByID(galleryID).FirstOrDefault();
        }

        // GET: api/EventGallery/5
        [ResponseType(typeof(EventGallery))]
        public IHttpActionResult GetEventGallery(int id)
        {
            esp_EventGallery_GetByID_Result eventGallery = db.esp_EventGallery_GetByID(id).FirstOrDefault();

            return Ok(eventGallery);
        }

        // PUT: api/EventGallery/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventGallery(int id, EventGallery editedGallery)
        {
            db.esp_EventGallery_Update(editedGallery.EventGalleryID, editedGallery.Naziv, editedGallery.Opis);

    
            return Ok();
        }


        // POST: api/EventGallery
        [HttpPost]
        [ResponseType(typeof(EventGallery))]
        public IHttpActionResult PostEventGallery(EventGallery eventGallery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            eventGallery.EventGalleryID = Convert.ToInt32(db.esp_EventGallery_Insert(eventGallery.EventID, eventGallery.Naziv, eventGallery.Opis, eventGallery.DatumKreiranja).FirstOrDefault());


            return CreatedAtRoute("DefaultApi", new { id = eventGallery.EventGalleryID }, eventGallery);
        }

        // DELETE: api/EventGallery/5
        [ResponseType(typeof(EventGallery))]
        public IHttpActionResult DeleteEventGallery(int id)
        {
            EventGallery eventGallery = db.EventGalleries.Find(id);
            if (eventGallery == null)
            {
                return NotFound();
            }

            db.EventGalleries.Remove(eventGallery);
            db.SaveChanges();

            return Ok(eventGallery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventGalleryExists(int id)
        {
            return db.EventGalleries.Count(e => e.EventGalleryID == id) > 0;
        }
    }
}