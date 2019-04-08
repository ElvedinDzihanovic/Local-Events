using System;
using System.Collections.Generic;
using System.IO;
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
	public partial class DetailsPage : ContentPage
	{
        private WebAPIHelper lokacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Lokacija");


        private int lokacijaID { get; set; }
        private bool? isFavorite { get; set; }

        public DetailsPage (int parametarID)
		{
			InitializeComponent ();

            lokacijaID = parametarID;

		}

        protected override void OnAppearing()
        {

            BindLokacija();
            BindSimilarLokacijas();
            base.OnAppearing();
        }

        private void BindSimilarLokacijas()
        {
            System.Net.Http.HttpResponseMessage similarResponse = lokacijaService.GetActionResponse("GetSimilarLokacijas", lokacijaID.ToString());

            if (similarResponse.IsSuccessStatusCode)
            {
                //DODAJ TESTNE PODATKE U BAZU...

                var jsonObjectSimilarLocations = similarResponse.Content.ReadAsStringAsync();
                List<Lokacija> listOfLokacijas = JsonConvert.DeserializeObject<List<Lokacija>>(jsonObjectSimilarLocations.Result);

                similarLokacijasListView.ItemsSource = listOfLokacijas;
            }
            else
                DisplayAlert("Error", "Could not load similar locations!", "Close");
        }

        private void BindLokacija()
        {
            try { 
            System.Net.Http.HttpResponseMessage response = lokacijaService.GetActionResponse("GetById", lokacijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                Lokacija lokacija = JsonConvert.DeserializeObject<Lokacija>(jsonObject.Result);
                    
                slikaThumb.Source = ImageSource.FromStream(() => new MemoryStream(lokacija.SlikaThumb));

                NazivLabel.Text = lokacija.Naziv;

                TipLabel.Text = "Type: ";
                tip.Text = lokacija.LokacijaTip;

                KapacitetLabel.Text = "Capacity: ";
                    kapacitet.Text = lokacija.Kapacitet.ToString();

                    AdresaLabel.Text = "Address: ";
                    Adresa.Text = lokacija.Adresa + ", " + lokacija.GradNaziv; 

                    OpisLabel.Text = "Description: ";
                    opis.Text = lokacija.Opis;

                    optionsLabel.Text = "Options: ";
                    rateBtn.Text = "Rate Location";
                    
                    commentSectionBtn.Text = "Comment Section";

                    System.Net.Http.HttpResponseMessage posjetilacLokacijaResponse = lokacijaService.GetTwoParameterResponse("GetPosjetilacLokacijaByID", Global.PrijavljeniKorisnik.KorisnikID.ToString(), lokacijaID.ToString());

                    if (posjetilacLokacijaResponse.IsSuccessStatusCode)
                    {
                        
                        var jsonObject2 = posjetilacLokacijaResponse.Content.ReadAsStringAsync();
                        
                        PosjetilacLokacija pl = JsonConvert.DeserializeObject<PosjetilacLokacija>(jsonObject2.Result);
                        
                        if (pl != null)
                        {
                            isFavorite = pl.IsFavorite;

                            if (isFavorite.HasValue)
                            {
                                if (isFavorite.Value == true)
                                    favoriteBtn.Text = "Remove From Favorites";
                                else
                                    favoriteBtn.Text = "Add To Favorites ♥";
                            }
                            else
                                favoriteBtn.Text = "Add To Favorites ♥";
                        }
                        else
                        { 
                            favoriteBtn.Text = "Add To Favorites ♥";
                            isFavorite = false;
                        }
                    }
                    else
                        DisplayAlert("error", "error loading posjetilac lokacija", "ok");
                }
            else
                DisplayAlert("error", "error", "error");
            }
            catch(Exception ex)
            {
                DisplayAlert("error", ex.Message, "ok");
            }
            }

        private void rateBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RateLokacijaPage(lokacijaID));
        }

        private void favoriteBtn_Clicked(object sender, EventArgs e)
        {

            if(isFavorite == null ||  isFavorite.Value == false) { 

            System.Net.Http.HttpResponseMessage response = lokacijaService.GetMultipleParameterResponse("UpdateIsFavorite", Global.PrijavljeniKorisnik.KorisnikID.ToString(), lokacijaID.ToString(), "1", "something");

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Success", "Dodali ste lokaciju u favorites!", "OK");
                    
                    //favoriteBtn.IsVisible = false;
                    favoriteBtn.Text = "Remove From Favorites";
                    isFavorite = true;
            }
            else
                DisplayAlert("error", "error", "error");
            }
            else
            {
                System.Net.Http.HttpResponseMessage response = lokacijaService.GetMultipleParameterResponse("UpdateIsFavorite", Global.PrijavljeniKorisnik.KorisnikID.ToString(), lokacijaID.ToString(), "0", "something");

                if (response.IsSuccessStatusCode)
                {
                    DisplayAlert("Success", "Uklonili ste lokaciju iz favorita!", "OK");

                    favoriteBtn.Text = "Add To Favorites ♥";
                    isFavorite = false;  
                }
                else
                    DisplayAlert("error", "error", "error");
            }
        }
        

        private void commentSectionBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CommentSectionPage(lokacijaID));
        }
    }
}