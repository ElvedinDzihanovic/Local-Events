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
	public partial class EventGalleryPage : ContentPage
	{
        private WebAPIHelper eventGalleryService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventGallery");
        private WebAPIHelper eventService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Event");

        private int eventID { get; set; }

        public EventGalleryPage (int selectedEventID)
		{
			InitializeComponent ();
            eventID = selectedEventID;
        }

        protected override void OnAppearing()
        {
            System.Net.Http.HttpResponseMessage response = eventGalleryService.GetActionResponse("GetByEvent", eventID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<EventGallery> eventGallery = JsonConvert.DeserializeObject<List<EventGallery>>(jsonObject.Result);

                eventGalleryList.ItemsSource = eventGallery;
            }
            else
                DisplayAlert("error", "error", "ok");


            base.OnAppearing();
        }

        private void eventGalleryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            EventGallery galerija = e.Item as EventGallery;

            this.Navigation.PushAsync(new Events.GalleryDetailsPage(galerija.EventGalleryID));
        }
    }
}