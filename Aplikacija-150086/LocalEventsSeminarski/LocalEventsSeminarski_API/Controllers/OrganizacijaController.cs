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
    public class OrganizacijaController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        // GET: api/Organizacija
        [HttpGet]
        public List<esp_Organizacija_SelectAll_Result> GetOrganizacijas()
        {
            return db.esp_Organizacija_SelectAll("").ToList();
        }

        [HttpGet]
        [Route("api/Organizacija/SearchByName/{naziv?}")]
        public List<esp_Organizacija_SelectAll_Result> SearchByName(string naziv = "")
        {
            return db.esp_Organizacija_SelectAll(naziv).ToList();
        }

        [Route("api/Organizacija/GetById/{organizacijaID}")]
        public esp_Organizacija_GetByID_Result GetById(int organizacijaID)
        {
            return db.esp_Organizacija_GetByID(organizacijaID).FirstOrDefault();
        }

        //mozda dodati HttpGet
        [HttpGet]
        [Route("api/Organizacija/UpdatePosjetilacOrganizacija/{posjetilacID}/{organizacijaID}/{comment}/{rating}")]
        public IHttpActionResult UpdatePosjetilacOrganizacija(int posjetilacID, int organizacijaID, string comment, string rating)
        {
            if (db.PosjetilacOrganizacijas.Any(p => p.OrganizacijaID == organizacijaID && p.PosjetilacID == posjetilacID))
                db.esp_PosjetilacOrganizacija_UpdateAll(posjetilacID, organizacijaID, comment, Convert.ToInt32(rating));
            else
                db.esp_PosjetilacOrganizacija_Insert(posjetilacID, organizacijaID, Convert.ToInt32(rating), comment);

            List<PosjetilacOrganizacija> list = db.PosjetilacOrganizacijas.Where(p => p.OrganizacijaID == organizacijaID && p.LocationRating.HasValue).ToList();

            double ocjena = 0;
            int count = 0;

            if(list.Count > 0)
            {
                count = list.Count;

                foreach(var item in list)
                {
                    if(item.LocationRating.Value > 0)
                        ocjena += item.LocationRating.Value;
                }

                //db.Organizacijas.FirstOrDefault(o=>o.OrganizacijaID == organizacijaID).avera
                //db.SaveChanges();
            }

            return Ok();
        }
        
        [Route("api/Organizacija/GetPosjetilacOrganizacijaByID/{posjetilacID}/{organizacijaID}")]
        public esp_PosjetilacOrganizacija_GetByID_Result GetPosjetilacOrganizacijaByID(int posjetilacID, int organizacijaID)
        {
            return db.esp_PosjetilacOrganizacija_GetByID(posjetilacID, organizacijaID).FirstOrDefault();
        }
        
        [Route("api/Organizacija/GetComments/{organizacijaID}")]
        public List<esp_Organizacija_GetComments_Result> GetComments(int organizacijaID)
        {
            return db.esp_Organizacija_GetComments(organizacijaID).ToList();
        } 
        // GET: api/Organizacija/5
        [ResponseType(typeof(Organizacija))]
        public IHttpActionResult GetOrganizacija(int id)
        {
            Organizacija organizacija = db.Organizacijas.Find(id);
            if (organizacija == null)
            {
                return NotFound();
            }

            return Ok(organizacija);
        }

        // PUT: api/Organizacija/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganizacija(int id, Organizacija organizacija)
        {
            try
            {
                db.esp_Organizacija_Update(id, organizacija.Naziv, organizacija.Opis, organizacija.Tip, organizacija.GradID);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/Organizacija/GetIdByName/{naziv}")]
        public int GetIdByName(string naziv)
        {
            return db.Organizacijas.Where(o => o.Naziv == naziv).FirstOrDefault().OrganizacijaID;
        }

        // POST: api/Organizacija
        [ResponseType(typeof(Organizacija))]
        public IHttpActionResult PostOrganizacija(Organizacija organizacija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try { 
                organizacija.OrganizacijaID = Convert.ToInt32(db.esp_Organizacija_Insert(organizacija.Naziv, organizacija.Opis, organizacija.Tip, organizacija.GradID, organizacija.SlikaLogo).FirstOrDefault());
            }
            catch (EntityException ex)
            {
                if (ex.InnerException != null)
                    throw CreateHttpExceptionMessage(Util.ExceptionHandler.HandleException(ex), HttpStatusCode.Conflict);
            }
            
            return CreatedAtRoute("DefaultApi", new { id = organizacija.OrganizacijaID }, organizacija);
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

        // DELETE: api/Organizacija/5
        [ResponseType(typeof(Organizacija))]
        public IHttpActionResult DeleteOrganizacija(int id)
        {
            Organizacija organizacija = db.Organizacijas.Find(id);
            if (organizacija == null)
            {
                return NotFound();
            }

            db.Organizacijas.Remove(organizacija);
            db.SaveChanges();

            return Ok(organizacija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizacijaExists(int id)
        {
            return db.Organizacijas.Count(e => e.OrganizacijaID == id) > 0;
        }
    }
}