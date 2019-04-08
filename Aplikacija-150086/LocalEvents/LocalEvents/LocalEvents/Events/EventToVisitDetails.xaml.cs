using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCL.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using static Android.App.Usage.UsageEvents;

namespace LocalEvents.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventToVisitDetails : ContentPage
    {
        private WebAPIHelper eventToVisitService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventToVisit");
        private WebAPIHelper eventService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Event");
        private int eventID {get; set;}
        public EventToVisitDetails (int eventToVisitID)
		{
			InitializeComponent ();

            eventID = eventToVisitID;

            LoadEventToVisit();
		}

        private void LoadEventToVisit()
        {
            System.Net.Http.HttpResponseMessage response = eventService.GetActionResponse("GetEventDetails", eventID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                PCL.Models.Event @event = JsonConvert.DeserializeObject<PCL.Models.Event>(jsonObject.Result);

                eventImage.Source = ImageSource.FromStream(() => new MemoryStream(@event.SlikaThumb));

                nazivLabel.Text = @event.Naziv;
                lokacijaLabel.Text = @event.Lokacija;
                lokacijaTitle.Text = "Location: ";
                opisLabel.Text = @event.Opis;
                opisTitle.Text = "Description: ";

                datumOdrzavanjaLabel.Text = @event.DatumOdrzavanja.ToString();
                datumOdrzavanjaTitle.Text = "Event Date: ";

                optionsLabel.Text = "Options: ";

                /*
                if (@event.Status == "Neodrzan") {
                    rateBtn.IsVisible = false;
                    commentSection.IsVisible = false;
                    removeBtn.Text = "Remove";
                }
                */
                //else { 
                //    removeBtn.IsVisible = false;
                removeBtn.Text = "Remove From My Events";
                  //  rateBtn.IsVisible = true;
                    rateBtn.Text = "Rate Event";

                    //commentSection.IsVisible = true;
                    commentSection.Text = "Comment Section";
                //}
            }
            else
            {
                DisplayAlert("error", "error", "ok");
            }
        }

        private void removeBtn_Clicked(object sender, EventArgs e)
        {
            System.Net.Http.HttpResponseMessage response = eventToVisitService.GetTwoParameterResponse("RemoveEventToVisit", Global.PrijavljeniKorisnik.KorisnikID.ToString(), eventID.ToString());

            try { 
                if (response.IsSuccessStatusCode)
                {
                    this.Navigation.PushAsync(new MyEvents());
                }
                else
                    DisplayAlert("error", "error", "ok");
            }
            catch(Exception ex)
                {
                DisplayAlert("exception", ex.Message, "ok");
            }
            }

        private void rateBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RateEvent(eventID));
        }

        private void commentSection_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CommentSectionPage(eventID));
        }
    }
}