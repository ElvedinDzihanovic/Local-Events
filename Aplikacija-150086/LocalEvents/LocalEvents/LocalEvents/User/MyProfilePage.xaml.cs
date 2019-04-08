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

namespace LocalEvents.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyProfilePage : ContentPage
	{
        private WebAPIHelper korisnikService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Korisnik");
        private WebAPIHelper gradService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Grad");
        private WebAPIHelper posjetilacService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Posjetilac");
        private Korisnik k { get; set; }
        private Posjetilac p { get; set; }
        private int korisnikID { get; set; }

        public MyProfilePage ()
		{


            if (Global.PrijavljeniKorisnik != null)
                InitializeComponent();

            

		}

        protected override void OnAppearing()
        {
            if (Global.PrijavljeniKorisnik == null)
                DisplayAlert("Error!", "You are not signed in!", "Close");
            else { 
            korisnikID = Global.PrijavljeniKorisnik.KorisnikID;

            BindGradovi();
            BindUserData();
            BindPosjetilac();
            }
            base.OnAppearing();
        }

        private void BindPosjetilac()
        {
            System.Net.Http.HttpResponseMessage posjetilacResponse = posjetilacService.GetActionResponse("GetByID", korisnikID.ToString());

            if (posjetilacResponse.IsSuccessStatusCode)
            {
                var jsonObj1 = posjetilacResponse.Content.ReadAsStringAsync();
                p = JsonConvert.DeserializeObject<Posjetilac>(jsonObj1.Result);

                zanimanjeInput.Text = p.Zanimanje;
                brojDogadjajaInput.Text = p.BrojPosjecenihDogadjaja.ToString();
                
                
            }
        }

        private void BindUserData()
        {
            System.Net.Http.HttpResponseMessage korisnikResponse = korisnikService.GetActionResponse("GetByID", korisnikID.ToString());

            if (korisnikResponse.IsSuccessStatusCode)
            {
                var jsonObj = korisnikResponse.Content.ReadAsStringAsync();
                k = JsonConvert.DeserializeObject<Korisnik>(jsonObj.Result);

                imeInput.Text = k.Ime;
                prezimeInput.Text = k.Prezime;
                emailInput.Text = k.Email;
                usernameInput.Text = k.KorisnickoIme;
            }
            else
                DisplayAlert("error", "error", "ok");
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

        private bool Validate()
        {
            if (String.IsNullOrEmpty(imeInput.Text)
                || String.IsNullOrEmpty(prezimeInput.Text)
                || String.IsNullOrEmpty(emailInput.Text)
                || String.IsNullOrEmpty(zanimanjeInput.Text)
                || String.IsNullOrEmpty(usernameInput.Text))
            {
                DisplayAlert("Validation Message!", "Required Fields Are Empty", "Ok");
                return false;
            }
            if (usernameInput.Text.Length < 5)
            {
                DisplayAlert("Validation Message!", "Username must be at least 5 characters long!", "Ok");
                return false;
            }
            if (!String.IsNullOrEmpty(passwordInput.Text))
            {
                if (passwordInput.Text.Length < 8)
                {
                    DisplayAlert("Validation Message!", "Password must be at least 8 characters long!", "Ok");
                    return false;
                }
                else if (!passwordInput.Text.Any(char.IsDigit) || !passwordInput.Text.Any(char.IsLetter))
                {
                    DisplayAlert("Validation Message", "Password must contain letters and numbers", "Ok");
                    return false;
                }
            }
            return true;
        }

        private void saveChangesBtn_Clicked(object sender, EventArgs e)
        {
            bool result = Validate();

            if (result == true)
            {

                Korisnik updatedKorisnik = new Korisnik();
                updatedKorisnik.Ime = imeInput.Text;
                updatedKorisnik.Prezime = prezimeInput.Text;
                updatedKorisnik.Email = emailInput.Text;
                updatedKorisnik.KorisnickoIme = usernameInput.Text;
                updatedKorisnik.LozinkaHash = k.LozinkaHash;
                updatedKorisnik.LozinkaSalt = k.LozinkaSalt;

                if (!String.IsNullOrEmpty(passwordInput.Text))
                {
                    updatedKorisnik.LozinkaSalt = UIHelper.GenerateSalt();
                    updatedKorisnik.LozinkaHash = UIHelper.GenerateHash(passwordInput.Text, updatedKorisnik.LozinkaSalt);
                }

                updatedKorisnik.GradID = k.GradID;
                updatedKorisnik.KorisnikID = k.KorisnikID;

                int id = korisnikID;

                System.Net.Http.HttpResponseMessage putResponse = korisnikService.GetMultipleParameterResponse2("UpdateKorisnik", updatedKorisnik.KorisnikID.ToString(), updatedKorisnik.Ime, updatedKorisnik.Prezime, updatedKorisnik.Email, updatedKorisnik.GradID.ToString(), updatedKorisnik.KorisnickoIme, updatedKorisnik.LozinkaSalt, updatedKorisnik.LozinkaHash);

                if (putResponse.IsSuccessStatusCode)
                {
                    DisplayAlert("Success!", "Saved Changes!", "Ok");
                }
                else
                    DisplayAlert("Error", "Error", "Ok");

                if (zanimanjeInput.Text != p.Zanimanje)
                {
                    System.Net.Http.HttpResponseMessage putResponse2 = posjetilacService.GetTwoParameterResponse("UpdateZanimanje", korisnikID.ToString(), zanimanjeInput.Text);

                    if (!putResponse2.IsSuccessStatusCode)
                    {
                        DisplayAlert("Error", putResponse2.StatusCode.ToString(), "Ok");
                    }
                }
            }
        }
    }
}