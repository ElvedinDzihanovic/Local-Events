using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCL.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCL.Models;

namespace LocalEvents.Events
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyEvents : ContentPage
	{
        private WebAPIHelper eventToVisitService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventToVisit");

		public MyEvents ()
		{
            if (Global.PrijavljeniKorisnik != null)
            {
                InitializeComponent();

                LoadEvents();
            }
            else
                DisplayAlert("Error!", "You are not signed in!", "Close");
        }
        
        private void LoadEvents()
        {
            try {

                System.Net.Http.HttpResponseMessage response = eventToVisitService.GetActionResponse("GetByPosjetilacID", Global.PrijavljeniKorisnik.KorisnikID.ToString());

            if (response.IsSuccessStatusCode)
            {
                    var jsonObject = response.Content.ReadAsStringAsync();
                    List<PCL.Models.EventToVisitIndexModel> events = JsonConvert.DeserializeObject<List<PCL.Models.EventToVisitIndexModel>>(jsonObject.Result);
                    eventList.ItemsSource = events;
                    
                }
            else
            {
                DisplayAlert("Error", "Error loading My Events!", "Close");
            }
            }

            catch(Exception ex)
            {
                DisplayAlert("exception", ex.Message, "ok");
            }
        }

        private void eventList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            EventToVisitIndexModel eventToVisit = e.Item as EventToVisitIndexModel;

            this.Navigation.PushAsync(new Events.EventToVisitDetails(eventToVisit.EventID));
        }
    }
}