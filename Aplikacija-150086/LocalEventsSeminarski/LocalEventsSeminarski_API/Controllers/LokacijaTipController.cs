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
    public class LokacijaTipController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        // GET: api/LokacijaTip
        public List<esp_LokacijaTip_SelectAll_Result> GetLokacijaTips()
        {
            return db.esp_LokacijaTip_SelectAll().ToList();
        }

        // GET: api/LokacijaTip/5
        [ResponseType(typeof(LokacijaTip))]
        public IHttpActionResult GetLokacijaTip(int id)
        {
            LokacijaTip lokacijaTip = db.LokacijaTips.Find(id);
            if (lokacijaTip == null)
            {
                return NotFound();
            }

            return Ok(lokacijaTip);
        }

        // PUT: api/LokacijaTip/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLokacijaTip(int id, LokacijaTip lokacijaTip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lokacijaTip.LokacijaTipID)
            {
                return BadRequest();
            }

            db.Entry(lokacijaTip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokacijaTipExists(id))
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

        // POST: api/LokacijaTip
        [ResponseType(typeof(LokacijaTip))]
        public IHttpActionResult PostLokacijaTip(LokacijaTip lokacijaTip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LokacijaTips.Add(lokacijaTip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lokacijaTip.LokacijaTipID }, lokacijaTip);
        }

        // DELETE: api/LokacijaTip/5
        [ResponseType(typeof(LokacijaTip))]
        public IHttpActionResult DeleteLokacijaTip(int id)
        {
            LokacijaTip lokacijaTip = db.LokacijaTips.Find(id);
            if (lokacijaTip == null)
            {
                return NotFound();
            }

            db.LokacijaTips.Remove(lokacijaTip);
            db.SaveChanges();

            return Ok(lokacijaTip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LokacijaTipExists(int id)
        {
            return db.LokacijaTips.Count(e => e.LokacijaTipID == id) > 0;
        }
    }
}