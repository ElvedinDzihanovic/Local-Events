using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LocalEventsSeminarski_API.Models;

namespace LocalEventsSeminarski_API.Controllers
{
    public class EventToVisitController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();
        
        public IHttpActionResult PostEventToVisit(EventToVisit eventToVisit)
        {
            db.esp_Event_ToVisit(eventToVisit.EventID, eventToVisit.PosjetilacID);

            db.Posjetilacs.FirstOrDefault(p => p.PosjetilacID == eventToVisit.PosjetilacID).BrojPosjecenihDogadjaja += 1;
            db.SaveChanges();

            return Ok();
        }
        
        [HttpGet]
        [Route("api/EventToVisit/RemoveEventToVisit/{posjetilacID}/{eventID}")]
        public IHttpActionResult RemoveEventToVisit(int posjetilacID, int eventID)
        {
            db.esp_EventToVisit_Remove(eventID, posjetilacID);
            //db.SaveChanges();

            db.Posjetilacs.FirstOrDefault(p => p.PosjetilacID == posjetilacID).BrojPosjecenihDogadjaja -= 1;
            db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("api/EventToVisit/GetByPosjetilacID/{posjetilacID}")]
        public List<esp_EventToVisit_GetByPosjetilacID_Result> GetByPosjetilacID(int posjetilacID)
        {
            return db.esp_EventToVisit_GetByPosjetilacID(posjetilacID).ToList();
        }

        [Route("api/EventToVisit/GetDetails/{posjetilacID}/{eventID}")]
         public esp_EventToVisit_GetDetails_Result GetDetails(int posjetilacID, int eventID){
            return db.esp_EventToVisit_GetDetails(posjetilacID, eventID).FirstOrDefault();
            //return Ok();
        }
        
        [HttpGet]
        [Route("api/EventToVisit/IsToVisit/{posjetilacID}/{eventID}")]
        public bool IsToVisit(int posjetilacID, int eventID)
        {
            return (db.EventToVisits.Any(e => e.PosjetilacID == posjetilacID && e.EventID == eventID));
        }

        [HttpGet]
        [Route("api/EventToVisit/UpdateEventToVisit/{posjetilacID}/{eventID}/{rating}/{comment}")]
        public IHttpActionResult UpdateEventToVisit(int posjetilacID, int eventID, string rating, string comment)
        {
            db.esp_EventToVisit_UpdateAll(posjetilacID, eventID, comment, Convert.ToInt32(rating));

            List<EventToVisit> eventRatings = db.EventToVisits.Where(e => e.EventID == eventID && e.EventRating.HasValue).ToList();

            if (eventRatings.Count > 0)
            {
                double ocjena = 0;

                int erCount = 0;

                foreach (var er in eventRatings)
                {
                    if(er.EventRating.Value > 0)
                        ocjena += er.EventRating.Value;
                }

                erCount = eventRatings.Count;

                db.Events.FirstOrDefault(e => e.EventID == eventID).AverageRating = ocjena / erCount;
                db.SaveChanges();
            }
            else
                db.Events.FirstOrDefault(e => e.EventID == eventID).AverageRating = 0;

            return Ok();
        }
        
    }
}
