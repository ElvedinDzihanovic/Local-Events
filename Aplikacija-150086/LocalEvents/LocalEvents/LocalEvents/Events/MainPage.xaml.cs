using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCL.Models;
using PCL.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalEvents.Events
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        private WebAPIHelper eventTypeService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventTip");
        private WebAPIHelper eventService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Event");

		public MainPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            if(Global.PrijavljeniKorisnik == null)
            {
                DisplayAlert("Error", "You need to be signed in!", "Close");
            }
            else
                BindList();
                    
                    base.OnAppearing();
       
        }
        

        private void BindList()
        {
            
            try
            {
                System.Net.Http.HttpResponseMessage response = eventService.GetActionResponse("GetEventsOrderByDatum");
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonObject = response.Content.ReadAsStringAsync();
                    List<PCL.Models.EventFilteredResult> eventi = JsonConvert.DeserializeObject<List<EventFilteredResult>>(jsonObject.Result);
                    eventList.ItemsSource = eventi;                   
                }
                else
                    DisplayAlert("Error", "Error loading events: " + response.StatusCode.ToString(), "error");
            }
            catch(Exception ex) {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void eventList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            EventFilteredResult @event = e.Item as EventFilteredResult;
            this.Navigation.PushAsync(new Events.DetailsPage(@event.EventID));
        }

        
    }
}