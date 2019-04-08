using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCL.Models;
using Newtonsoft.Json;
using System.IO;

namespace LocalEvents.Events
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsPage : ContentPage
	{
        private WebAPIHelper eventService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Event");
        private WebAPIHelper eventToVisitService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventToVisit");
        private WebAPIHelper ageRangeService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/AgeRange");
        private WebAPIHelper organizacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Organizacija");

        //public DetailsPage()
        //{
        //  InitializeComponent();
        // LoadPageData(1008);
        // }
        public int eventID;
        string organizacijaNaziv;
       
        public DetailsPage()
        {
            InitializeComponent();
        }
        
        public DetailsPage (int eventID)
		{
            this.eventID = eventID;
			InitializeComponent ();

		}

        protected override void OnAppearing()
        {
            LoadPageData(eventID);
            base.OnAppearing();
        }
        private void LoadPageData(int eventID)
        {
            try
            {
                System.Net.Http.HttpResponseMessage response = eventService.GetActionResponse("GetEventDetails", eventID.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var jsonObject = response.Content.ReadAsStringAsync();
                    PCL.Models.Event @event = JsonConvert.DeserializeObject<Event>(jsonObject.Result);

                    eventImage.Source = ImageSource.FromStream(() => new MemoryStream(@event.SlikaThumb));

                    galleriesBtn.Text = "Galleries";


                    nazivLabel.Text = @event.Naziv;
                   // eventTipLabel.Text = @event.EventTip;
                    lokacijaLabel.Text = @event.Lokacija;
                    lokacija.Text = "Location: ";
                    opisLabel.Text =@event.Opis;
                    opis.Text = "Description: ";

                    statusLabel.Text = @event.Status;
                    
                    status.Text = "Status";

                    organization.Text = "Organizer: ";

                    if (!String.IsNullOrEmpty(@event.Organizacija))
                    {
                        organizationLabel.Text = @event.Organizacija;
                        organizacijaNaziv = @event.Organizacija;
                    }
                    else
                    {
                        organizationLabel.Text = "No Organization";
                        organizacijaNaziv = null;
                        organizationLabel.IsVisible = false;
                    }
                        //Check if event is already marked as TO VISIT
                    System.Net.Http.HttpResponseMessage toVisitResponse = eventToVisitService.GetTwoParameterResponse("IsToVisit", Global.PrijavljeniKorisnik.KorisnikID.ToString(), eventID.ToString());
                    if (toVisitResponse.IsSuccessStatusCode)
                    {
                        var toVisitResponseJsonObj = toVisitResponse.Content.ReadAsStringAsync();
                        bool toVisit = JsonConvert.DeserializeObject<bool>(toVisitResponseJsonObj.Result);

                        if (!toVisit)
                        {
                            toVisitBtn.Text = "To Visit";
                            toVisitBtn.IsVisible = true;
                        }
                        else
                            toVisitBtn.IsVisible = false;

                }
                    else
                        DisplayAlert("error", "error to visit", "error");

                    buttonsLabel.Text = "Option: ";
                    
                    datumLabel.Text = "Event Date: ";
                    datum.Text = @event.DatumOdrzavanja;

                    tipLabel.Text = "Type: ";
                    tip.Text = @event.EventTip;

                    ageRangeLabel.Text = "Age Range: ";

                    System.Net.Http.HttpResponseMessage ageRangeResponse = ageRangeService.GetActionResponse("SelectAllByEvent", @event.EventID.ToString());

                    if (ageRangeResponse.IsSuccessStatusCode)
                    {
                        var jsonObjectAgeRange = ageRangeResponse.Content.ReadAsStringAsync();
                        List<AgeRange> ageRanges = JsonConvert.DeserializeObject<List<AgeRange>>(jsonObjectAgeRange.Result);

                        //rijesiti ovo, korisnik ne moze kliknuti na age range
                        //ageRangeListView.IsEnabled = false;
                        
                        ageRangeListView.ItemsSource = ageRanges;
                    }
                    else
                    {
                        DisplayAlert("error", "error loading age range", "ok");
                    }
                }
                else
                    DisplayAlert("error", "error", "ok");

                System.Net.Http.HttpResponseMessage similarResponse = eventService.GetActionResponse("GetSimilarEvents", eventID.ToString());

                if (similarResponse.IsSuccessStatusCode)
                {
                    //DODAJ TESTNE PODATKE U BAZU...

                    var jsonObjectSimilarEvents = similarResponse.Content.ReadAsStringAsync();
                    List<Event> listOfEvents = JsonConvert.DeserializeObject<List<Event>>(jsonObjectSimilarEvents.Result);
                    
                    similarEventsListVies.ItemsSource = listOfEvents;
                    
                    
                }
                else
                    DisplayAlert("Error loading similar events!", "Error", "Close");
            }
            catch(Exception ex)
            {
                DisplayAlert("error", ex.Message, "ok");
            }
        }

        private void toVisitBtn_Clicked(object sender, EventArgs e)
        {
            EventToVisitIndexModel eventToVisit = new EventToVisitIndexModel
            {
                EventID = this.eventID,
                PosjetilacID = Global.PrijavljeniKorisnik.KorisnikID
            
            };

            //DisplayAlert("nesto", JsonConvert.SerializeObject(eventToVisit), "ok");
            
            try {
                System.Net.Http.HttpResponseMessage response = eventToVisitService.PostResponse(eventToVisit);
            
            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("success", "Oznacili ste dogadjaj sa ToVisit!", "OK");
                toVisitBtn.IsVisible = false;

                this.Navigation.PushAsync(new MainPage());
            }
            else
                DisplayAlert("error", "error", "error");
            }
            catch(Exception ex)
            {
                DisplayAlert("ex", "ex", "ex");
            }
            
        }

        private void galleriesBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EventGalleryPage(eventID));
           
        }

        private void organizationLabel_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(organizacijaNaziv)) {
                System.Net.Http.HttpResponseMessage organizacijaResponse = organizacijaService.GetActionResponse("GetIdByName", organizacijaNaziv);

                if (organizacijaResponse.IsSuccessStatusCode)
                {
                    var json = organizacijaResponse.Content.ReadAsStringAsync();

                    int id = JsonConvert.DeserializeObject<int>(json.Result);

                    this.Navigation.PushAsync(new Organizacije.DetailsPage(id));
                }
            }
        }
    }
}