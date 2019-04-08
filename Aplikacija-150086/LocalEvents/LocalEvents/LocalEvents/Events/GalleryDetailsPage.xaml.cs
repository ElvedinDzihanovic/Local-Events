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
	public partial class GalleryDetailsPage : ContentPage
	{
        private WebAPIHelper eventGalleryService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventGallery");
        private WebAPIHelper slikaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Slika");

        public int galleryID { get; set; }

        public GalleryDetailsPage (int eventGalleryID)
		{
			InitializeComponent ();

            galleryID = eventGalleryID;

		}

        protected override void OnAppearing()
        {
            System.Net.Http.HttpResponseMessage response1 = slikaService.GetActionResponse("GetByGalleryID", galleryID.ToString());
            System.Net.Http.HttpResponseMessage response2 = eventGalleryService.GetActionResponse("GetByID", galleryID.ToString());

            if (response1.IsSuccessStatusCode)
            {
                var jsonObject = response1.Content.ReadAsStringAsync();
                List<Slika> slike = JsonConvert.DeserializeObject<List<Slika>>(jsonObject.Result);
                slikeListView.ItemsSource = slike;
            }
            else
            {
                DisplayAlert("error", "error", "ok");
            }

            if (response2.IsSuccessStatusCode)
            {
                var jsonObject2 = response2.Content.ReadAsStringAsync();
                EventGallery galerija = JsonConvert.DeserializeObject<EventGallery>(jsonObject2.Result);

                naziv.Text = galerija.Naziv;
                opis.Text = galerija.Opis;
                datum.Text = galerija.DatumKreiranja.ToString();

                nazivLabel.Text = "Name: ";
                opis.Text = "Description: ";
                datumLabel.Text = "Created Date: ";
            }
            else
                DisplayAlert("error", "error", "ok");

            base.OnAppearing();
        }
    }
}