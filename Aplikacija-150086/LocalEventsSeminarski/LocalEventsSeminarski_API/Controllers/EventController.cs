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
    public class EventController : ApiController
    {
        //private LocalEventsEntities db = new LocalEventsEntities();
        private LocalEventsEntities2 db = new LocalEventsEntities2();
        // GET: api/Event
        [HttpGet]
        public List<esp_Event_GetEvents_Result> GetEvents()
        {
            return db.esp_Event_GetEvents("").ToList();
        }

        [HttpGet]
        [Route("api/Event/GetByNaziv/{naziv?}")]
        public List<esp_Event_GetEvents_Result> GetByNaziv(string naziv = "")
        {
            return db.esp_Event_GetEvents(naziv).ToList();
        }

        [Route("api/Event/GetByEventTip/{eventTipID?}")]
        public List<esp_Event_GetByEventTip_Result> GetByEventTip(int eventTipID)
        {
            return db.esp_Event_GetByEventTip(eventTipID).ToList();
        }



        // GET: api/Event/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            

            esp_Event_GetByID_Result trazeniEvent =  db.esp_Event_GetByID(id).FirstOrDefault();

            if (trazeniEvent == null)
                return NotFound();

            return Ok(trazeniEvent);
        }
        
        [Route("api/Event/GetEventDetails/{eventID}")]
        public esp_Event_GetDetails_Result GetEventDetails(int eventID)
        {
            return db.esp_Event_GetDetails(eventID).FirstOrDefault();
        }

        //[Route("api/Event/GetEventsOrderByDatum")]
        [Route("api/Event/GetEventsOrderByDatum")]
        public List<esp_Event_OrderByDatum_Result> GetEventsOrderByDatum()
        {
            return db.esp_Event_OrderByDatum().OrderBy(e=>e.DatumOdrzavanja).ToList();
        }

        [Route("api/Event/GetEventsOrderByNaziv")]
        public List<esp_Event_OrderByLokacija_Result> GetEventsOrderByNaziv()
        {
            return db.esp_Event_OrderByLokacija().OrderBy(e=>e.Naziv).ToList();
        }

        //[Route("api/Event/EventAgeRangeInsert/{eventID}")]
        public IHttpActionResult EventAgeRangeInsert(int eventID, int ageRangeID)
        {
            int eventAgeRangeID = Convert.ToInt32(db.esp_EventAgeRange_Insert(ageRangeID, eventID).FirstOrDefault());

            return Ok(eventAgeRangeID);
        }

        [HttpGet]
        [Route("api/Event/GetTopFive/{gradID}/{mjesec}")]
        public List<esp_Event_Top5ByGradMjesec_Result> GetTopFive(int gradID, int mjesec)
        {
            return db.esp_Event_Top5ByGradMjesec(gradID, mjesec).ToList();
        }
        
        [HttpGet]
        [Route("api/Event/GetSimilarEvents/{eventID}")]
        public List<esp_Event_OrderByDatum_Result> GetSimilarEvents(int eventID)
        {
            Recommender r = new Recommender();
            return r.GetSimilarEvents(eventID);
        }

        // PUT: api/Event/5
        //[ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutEvent(int id, Event putEvent)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != putEvent.EventID)
                return BadRequest();

            db.esp_Event_Update(putEvent.EventID, putEvent.Naziv, putEvent.Opis, putEvent.LokacijaID, putEvent.OrganizacijaID, putEvent.EventTipID, putEvent.VrijemePocetka, putEvent.VrijemeZavrsetka, putEvent.DatumOdrzavanja, putEvent.Status);
            
            return Ok();
        }

        //POST: api/Event

        [HttpPost]
        public IHttpActionResult PostEvent(Event noviEvent)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try { 
            noviEvent.EventID = Convert.ToInt32(db.esp_Event_Insert(noviEvent.KreatorID, noviEvent.Naziv, noviEvent.Opis, noviEvent.DatumKreiranja, noviEvent.DatumOdrzavanja, noviEvent.VrijemePocetka, noviEvent.VrijemeZavrsetka, noviEvent.Slika, noviEvent.SlikaThumb, noviEvent.Status, noviEvent.EventTipID, noviEvent.OrganizacijaID, noviEvent.LokacijaID).FirstOrDefault());
            }
                catch (EntityException ex)
            {
                if (ex.InnerException != null)
                    throw CreateHttpExceptionMessage(Util.ExceptionHandler.HandleException(ex), HttpStatusCode.Conflict);
            }
        
            foreach (var item in noviEvent.AgeRanges)
            {
                db.esp_EventAgeRange_Insert(item.AgeRangeID, noviEvent.EventID);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/Event/GetReport/{eventID}")]
        public List<esp_Event_GetReport_Result> GetReport(int eventID)
        {
            return db.esp_Event_GetReport(eventID).ToList();
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
        [Route("api/Event/GetComments/{eventID}")]
        public List<esp_Event_GetComments_Result> GetComments(int eventID)
        {
            return db.esp_Event_GetComments(eventID).ToList();
        }
        

        // DELETE: api/Event/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.EventID == id) > 0;
        }
    }
}