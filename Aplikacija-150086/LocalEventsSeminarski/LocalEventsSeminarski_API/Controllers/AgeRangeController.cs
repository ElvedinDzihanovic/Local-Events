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
    public class AgeRangeController : ApiController
    {
        //private LocalEventsEntities db = new LocalEventsEntities();
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        // GET: api/AgeRange
        public List<esp_AgeRange_SelectAll_Result> GetAgeRanges()
        {
            return db.esp_AgeRange_SelectAll().ToList();
        }

        // GET: api/AgeRange/5
        [ResponseType(typeof(AgeRange))]
        public IHttpActionResult GetAgeRange(int id)
        {
            AgeRange ageRange = db.AgeRanges.Find(id);
            if (ageRange == null)
            {
                return NotFound();
            }

            return Ok(ageRange);
        }

        [HttpGet]
        [Route("api/AgeRange/SelectAllByEvent/{eventID}")]
        public List<esp_EventAgeRange_GetByEvent_Result> SelectAllByEvent(int eventID)
        {
            return db.esp_EventAgeRange_GetByEvent(eventID).ToList();
        }
        
        // PUT: api/AgeRange/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgeRange(int id, AgeRange ageRange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ageRange.AgeRangeID)
            {
                return BadRequest();
            }

            db.Entry(ageRange).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeRangeExists(id))
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

        // POST: api/AgeRange
        [ResponseType(typeof(AgeRange))]
        public IHttpActionResult PostAgeRange(AgeRange ageRange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AgeRanges.Add(ageRange);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ageRange.AgeRangeID }, ageRange);
        }

        // DELETE: api/AgeRange/5
        [ResponseType(typeof(AgeRange))]
        public IHttpActionResult DeleteAgeRange(int id)
        {
            AgeRange ageRange = db.AgeRanges.Find(id);
            if (ageRange == null)
            {
                return NotFound();
            }

            db.AgeRanges.Remove(ageRange);
            db.SaveChanges();

            return Ok(ageRange);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgeRangeExists(int id)
        {
            return db.AgeRanges.Count(e => e.AgeRangeID == id) > 0;
        }
    }
}