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
	public partial class LoginPage : ContentPage
	{
        private WebAPIHelper korisnikService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Korisnik");
        private WebAPIHelper ulogaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Uloga");

        public LoginPage ()
		{
			InitializeComponent ();

            //dodano naknadno
            //u slucaju da korisnik pritisne sign out na kraju, prijavljeni korisnik postaje NULL
            
            Global.PrijavljeniKorisnik = null;

		}

        private void loginBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                System.Net.Http.HttpResponseMessage response = korisnikService.GetActionResponse("GetByKorisnickoIme", korisnickoImeInput.Text);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) { 
                    DisplayAlert("Login Error", response.StatusCode.ToString(), "OK");
                }
                else { 
                
                if (response.IsSuccessStatusCode)
                {

                    var jsonObject = response.Content.ReadAsStringAsync();
                    esp_Korisnik_GetByKorisnickoIme_Result korisnik = JsonConvert.DeserializeObject<esp_Korisnik_GetByKorisnickoIme_Result>(jsonObject.Result);

                    if (korisnik.LozinkaHash == UIHelper.GenerateHash(lozinkaInput.Text, korisnik.LozinkaSalt))
                    {
                        //Global.prijavljeniKupac = kupac;
                        System.Net.Http.HttpResponseMessage ulogaResponse = ulogaService.GetActionResponse("IsPosjetilac", korisnik.KorisnikID.ToString());

                        if (ulogaResponse.IsSuccessStatusCode) {

                            var ulogaJson = ulogaResponse.Content.ReadAsStringAsync();

                            bool isPosjetilac = JsonConvert.DeserializeObject<bool>(ulogaJson.Result);

                            if (isPosjetilac)
                            {
                                Global.PrijavljeniKorisnik = new Korisnik
                                {
                                    KorisnickoIme = korisnik.KorisnickoIme,
                                    KorisnikID = korisnik.KorisnikID,
                                    LozinkaHash = korisnik.LozinkaHash,
                                    LozinkaSalt = korisnik.LozinkaSalt
                                };
                                this.Navigation.PushAsync(new Navigation.NavPage());
                                
                            }
                            else
                                DisplayAlert("Login Error", "You do not have the permission to access mobile app.", "Ok");
                        }
            }
    
        
                    else
                    {
                        DisplayAlert("Login Error", response.StatusCode.ToString(), "OK");
                        lozinkaInput.Text = String.Empty;
                    
                    }
                      

                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Exception Message", "Password or username are incorrect!", "OK");
            }
        }

        private void registerButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Register());
        }
    }
}
 