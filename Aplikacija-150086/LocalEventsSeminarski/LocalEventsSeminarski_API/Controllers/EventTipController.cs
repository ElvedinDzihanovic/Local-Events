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
    public class EventTipController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        // GET: api/EventTip
        public List<esp_EventTip_SelectAll_Result> GetEventTips()
        {
            return db.esp_EventTip_SelectAll().ToList();
        }

        // GET: api/EventTip/5
        [ResponseType(typeof(EventTip))]
        public IHttpActionResult GetEventTip(int id)
        {
            EventTip eventTip = db.EventTips.Find(id);
            if (eventTip == null)
            {
                return NotFound();
            }

            return Ok(eventTip);
        }

        // PUT: api/EventTip/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventTip(int id, EventTip eventTip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTip.EventTipID)
            {
                return BadRequest();
            }

            db.Entry(eventTip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTipExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EventTip
        [ResponseType(typeof(EventTip))]
        public IHttpActionResult PostEventTip(EventTip eventTip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventTips.Add(eventTip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventTip.EventTipID }, eventTip);
        }

        // DELETE: api/EventTip/5
        [ResponseType(typeof(EventTip))]
        public IHttpActionResult DeleteEventTip(int id)
        {
            EventTip eventTip = db.EventTips.Find(id);
            if (eventTip == null)
            {
                return NotFound();
            }

            db.EventTips.Remove(eventTip);
            db.SaveChanges();

            return Ok(eventTip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventTipExists(int id)
        {
            return db.EventTips.Count(e => e.EventTipID == id) > 0;
        }
    }
}