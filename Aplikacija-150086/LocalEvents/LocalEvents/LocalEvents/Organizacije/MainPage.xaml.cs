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

namespace LocalEvents.Organizacije
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        private WebAPIHelper organizacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Organizacija");

        public MainPage ()
		{

            if (Global.PrijavljeniKorisnik != null) { 
                InitializeComponent ();
                BindOrganizacije();
            }
            else
                DisplayAlert("Error!", "You need to be signed in!", "Close");
        }

        private void BindOrganizacije()
        {
            System.Net.Http.HttpResponseMessage response = organizacijaService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<Organizacija> organizacije = JsonConvert.DeserializeObject<List<Organizacija>>(jsonObject.Result);

                organizacijaListView.ItemsSource = organizacije;
            }
            else
            {
                DisplayAlert("greska", "greska", "greska");
            }
        }

        private void organizacijaListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Organizacija o = e.Item as Organizacija;

            this.Navigation.PushAsync(new Organizacije.DetailsPage(o.OrganizacijaID));
        }
    }
}