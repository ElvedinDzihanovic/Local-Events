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

namespace LocalEvents.Lokacije
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyFavLocationsPage : ContentPage
	{
        private WebAPIHelper lokacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Lokacija");

        public MyFavLocationsPage()
        {
            if(Global.PrijavljeniKorisnik != null)
                InitializeComponent();

        }

        protected override void OnAppearing()
        {
            if (Global.PrijavljeniKorisnik != null)
                BindLokacije();
            else
                DisplayAlert("Error!", "You are not signed in!", "Close");

            base.OnAppearing();

        }

        private void BindLokacije()
        {
            System.Net.Http.HttpResponseMessage response = lokacijaService.GetActionResponse("GetFavoriteLokacijas", Global.PrijavljeniKorisnik.KorisnikID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Lokacija> lokacije = JsonConvert.DeserializeObject<List<Lokacija>>(jsonObject.Result);

                lokacijaList.ItemsSource = lokacije;
            }
            else
                DisplayAlert("error", "error", "error");
        }

        private void lokacijaList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Lokacija l = e.Item as Lokacija;
            this.Navigation.PushAsync(new DetailsPage(l.LokacijaID));
        }
    }
}