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

namespace LocalEvents
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
        private WebAPIHelper korisnikService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Korisnik");
        private WebAPIHelper gradService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Grad");
        private WebAPIHelper posjetilacService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Posjetilac");
        
        public Register ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            BindGradovi();
            
            base.OnAppearing();
        }

        private void BindGradovi()
        {
            System.Net.Http.HttpResponseMessage gradResponse = gradService.GetResponse();

            if (gradResponse.IsSuccessStatusCode)
            {
                var jsonObject = gradResponse.Content.ReadAsStringAsync();
                List<Grad> gradList = JsonConvert.DeserializeObject<List<Grad>>(jsonObject.Result);


                gradPicker.ItemsSource = gradList;

            }
            else
                DisplayAlert("error", "error loading grad", "error");

        }

        //private void -> original
        //private async Task registracijaBtn_Clicked(object sender, EventArgs e)
        private async Task registracijaBtn_Clicked(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            k.Ime = imeInput.Text;
            k.Prezime = prezimeInput.Text;
            k.KorisnickoIme = usernameInput.Text;
            k.Email = emailInput.Text;

            k.Slika = null;
            k.SlikaThumb = null;

            k.LozinkaSalt = UIHelper.GenerateSalt();
            k.LozinkaHash = UIHelper.GenerateHash(passwordInput.Text, k.LozinkaSalt);

            k.GradID = (gradPicker.SelectedItem as Grad).GradID;

            k.KorisnikUlogas = new List<KorisnikUloga>();

            k.KorisnikUlogas.Add(new KorisnikUloga
            {
                KorisnikID = k.KorisnikID,
                UlogaID = 2,
                DatumIzmjene = DateTime.Now
            });


            System.Net.Http.HttpResponseMessage response = korisnikService.PostResponse(k);

            

            if (response.IsSuccessStatusCode)
            {
                var korisnikResponseJson = response.Content.ReadAsStringAsync();
                int idKorisnika = JsonConvert.DeserializeObject<int>(korisnikResponseJson.Result);
                
                Posjetilac p = new Posjetilac
                {
                    PosjetilacID = idKorisnika,
                    BrojPosjecenihDogadjaja = 0,
                    Zanimanje = zanimanjeInput.Text
                };

                System.Net.Http.HttpResponseMessage response2 = posjetilacService.PostResponse(p);

                if (response2.IsSuccessStatusCode)
                {

                    await this.Navigation.PushAsync(new MainPage());
                }
                else
                    await DisplayAlert("Posjetilac Error", "...", "Ok");
            }
            else
            {
                await DisplayAlert("error", "error", "ok");
            }
            
        }
    }
}