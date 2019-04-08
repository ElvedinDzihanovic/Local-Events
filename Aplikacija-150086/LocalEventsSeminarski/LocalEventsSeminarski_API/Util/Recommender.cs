using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocalEventsSeminarski_API.Models;

namespace LocalEventsSeminarski_API.Util
{
    public class Recommender
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();

        private Dictionary<int, List<EventToVisit>> events = new Dictionary<int, List<EventToVisit>>();
        private Dictionary<int, List<PosjetilacLokacija>> lokacije = new Dictionary<int, List<PosjetilacLokacija>>();

        public List<esp_Event_OrderByDatum_Result> GetSimilarEvents(int currentEventID)
        {
            GetEventsData(currentEventID);

            List<EventToVisit> currentEventRatings = db.EventToVisits
                .Where(x => x.EventID == currentEventID 
                && x.EventRating.HasValue && x.EventRating.Value > 0)
                .OrderBy(x => x.PosjetilacID).ToList();

            List<EventToVisit> commonRatings1 = new List<EventToVisit>();
            List<EventToVisit> commonRatings2 = new List<EventToVisit>();


            List<esp_Event_OrderByDatum_Result> similarEvents = new List<esp_Event_OrderByDatum_Result>();

            foreach(var e in events)
            {
                foreach (var r in currentEventRatings)
                {
                    if(e.Value.Where(x=>x.PosjetilacID == r.PosjetilacID).Count() > 0)
                    {
                        commonRatings1.Add(r);
                        commonRatings2.Add(e.Value.Where(x => x.PosjetilacID == r.PosjetilacID).First());
                    }
                }
                double sim = CalculateSimilarity(commonRatings1, commonRatings2);

                    if (sim > 0.6)
                    {
                        //similarEvents.Add(db.esp_Event_GetByID(e.Key).First());

                        var result = db.esp_Event_GetByID(e.Key).FirstOrDefault();
                        esp_Event_OrderByDatum_Result similarEvent = new esp_Event_OrderByDatum_Result()
                        {
                            EventID = result.EventID,
                            Naziv = result.Naziv,
                            SlikaThumb = result.SlikaThumb,
                            DatumOdrzavanja = result.DatumOdrzavanja.Date
                        };

                    similarEvents.Add(similarEvent);
                    }

               

                commonRatings1.Clear();
                commonRatings2.Clear();
            }

            //return similarEvents;
            return similarEvents.Take(5).ToList(); //vrati maximalno 5 elemenata

        }

        public List<esp_Lokacija_GetLokacijaList_Result> GetSimilarLokacijas(int currentLokacijaID)
        {
            GetLokacijaData(currentLokacijaID);

            List<PosjetilacLokacija> currentLokacijaRating = db.PosjetilacLokacijas
                .Where(x => x.LokacijaID == currentLokacijaID
                && x.LocationRating.HasValue && x.LocationRating.Value > 0)
                .OrderBy(x => x.PosjetilacID).ToList();

            List<PosjetilacLokacija> commonRatings11 = new List<PosjetilacLokacija>();
            List<PosjetilacLokacija> commonRatings22 = new List<PosjetilacLokacija>();


            List<esp_Lokacija_GetLokacijaList_Result> similarLokacijas = new List<esp_Lokacija_GetLokacijaList_Result>();

            foreach (var e in lokacije)
            {
                foreach (var r in currentLokacijaRating)
                {
                    if (e.Value.Where(x => x.PosjetilacID == r.PosjetilacID).Count() > 0)
                    {
                        commonRatings11.Add(r);
                        commonRatings22.Add(e.Value.Where(x => x.PosjetilacID == r.PosjetilacID).First());
                    }
                }
                    double sim = CalculateSimilarity(commonRatings11, commonRatings22);

                    if (sim > 0.6)
                    {
                        //similarEvents.Add(db.esp_Event_GetByID(e.Key).First());

                        var result = db.esp_Lokacija_GetByID(e.Key).FirstOrDefault();
                        esp_Lokacija_GetLokacijaList_Result similarLokacija = new esp_Lokacija_GetLokacijaList_Result()
                        {
                            LokacijaID = result.LokacijaID,
                            Naziv = result.Naziv,
                            SlikaThumb = result.SlikaThumb,
                            LokacijaTipNaziv = result.LokacijaTip
                        };

                        similarLokacijas.Add(similarLokacija);
                    }
                    
                commonRatings11.Clear();
                commonRatings22.Clear();
            }

            //return similarLokacijas;
            return similarLokacijas.Take(5).ToList(); //maximalno 5 elemenata
        }

        private double CalculateSimilarity(List<PosjetilacLokacija> commonRatings11, List<PosjetilacLokacija> commonRatings22)
        {
            if (commonRatings11.Count != commonRatings22.Count)
                return 0;

            double numerator = 0, int1 = 0, int2 = 0;

            for (int i = 0; i < commonRatings11.Count; i++)
            {
                numerator += commonRatings11[i].LocationRating.Value * commonRatings22[i].LocationRating.Value;
                int1 += Math.Pow(commonRatings11[i].LocationRating.Value, 2);
                int2 += Math.Pow(commonRatings22[i].LocationRating.Value, 2);
            }

            int1 = Math.Sqrt(int1);
            int2 = Math.Sqrt(int2);

            if (int1 * int2 != 0)
                return numerator / (int1 * int2);

            return 0;
        }

        private void GetLokacijaData(int currentLokacijaID)
        {

            //x.AverageRating > 0 -> iskljucivanje svih lokacija koje jos nijednom nisu ocijenjene. 
            //Po defaultu, minimalna ocjena je 1. Ocjenu nula imaju samo lokacije koje su tek dodane.
            List<Lokacija> getLokacijas = db.Lokacijas.Where(x => x.LokacijaID != currentLokacijaID).ToList();
            List<PosjetilacLokacija> ratings; 

            foreach (var item in getLokacijas)
            {
                ratings = db.PosjetilacLokacijas.Where(x => x.LokacijaID == item.LokacijaID && x.LocationRating.HasValue).OrderBy(x => x.PosjetilacID).ToList();

                if (ratings.Count > 0)
                {
                    lokacije.Add(item.LokacijaID, ratings);
                }
            }
        }

        private double CalculateSimilarity(List<EventToVisit> commonRatings1, List<EventToVisit> commonRatings2)
        {
            if (commonRatings1.Count != commonRatings2.Count)
                return 0;

            double numerator = 0, int1 = 0, int2 = 0;

            for(int i = 0; i < commonRatings1.Count; i++)
            {
                numerator += commonRatings1[i].EventRating.Value * commonRatings2[i].EventRating.Value;
                int1 += Math.Pow(commonRatings1[i].EventRating.Value, 2);
                int2 += Math.Pow(commonRatings2[i].EventRating.Value, 2);
            }

            int1 = Math.Sqrt(int1);
            int2 = Math.Sqrt(int2);

            if (int1 * int2 != 0)
                return numerator / (int1 * int2);

            return 0;
        }

        private void GetEventsData(int currentEventID)
        {
            //x.AverageRating > 0 -> iskljucivanje svih evenata koji jos nijednom nisu ocijenjeni. 
            //Po defaultu, minimalna ocjena je 1. Ocjenu 0 imaju samo eventi koji su tek dodani.
            List<Event> getEvents = db.Events.Where(x => x.EventID != currentEventID && x.AverageRating > 0).ToList();
            List<EventToVisit> ratings; //event to visit u sebi cuva komentar i ocjenu

            foreach(var item in getEvents)
            {
                ratings = db.EventToVisits.Where(x => x.EventID == item.EventID && x.EventRating.HasValue).OrderBy(x => x.PosjetilacID).ToList();

                if (ratings.Count > 0)
                { 
                    events.Add(item.EventID, ratings);
                }
            }
        }
    }
}