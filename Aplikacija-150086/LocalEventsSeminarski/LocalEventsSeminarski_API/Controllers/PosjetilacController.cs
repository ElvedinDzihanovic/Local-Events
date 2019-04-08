using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LocalEventsSeminarski_API.Models;

namespace LocalEventsSeminarski_API.Controllers
{
    public class PosjetilacController : ApiController
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        
        [HttpGet]
        [Route("api/Posjetilac/GetByID/{posjetilacID}")]
        public esp_Posjetilac_GetByID_Result GetByID(int posjetilacID){
            return db.esp_Posjetilac_GetByID(posjetilacID).FirstOrDefault();
        }

        [HttpPost]
        public IHttpActionResult PostPosjetilac(Posjetilac posjetilac)
        {
            db.Posjetilacs.Add(new Posjetilac
            {
                PosjetilacID = posjetilac.PosjetilacID,
                BrojPosjecenihDogadjaja = posjetilac.BrojPosjecenihDogadjaja,
                Zanimanje = posjetilac.Zanimanje
            });

            db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("api/Posjetilac/UpdateZanimanje/{posjetilacID}/{zanimanje}")]
        public IHttpActionResult UpdateZanimanje(int posjetilacID, string zanimanje)
        {
            db.Posjetilacs.FirstOrDefault(p => p.PosjetilacID == posjetilacID).Zanimanje = zanimanje;
            db.SaveChanges();

            return Ok();
        }


    }
}
