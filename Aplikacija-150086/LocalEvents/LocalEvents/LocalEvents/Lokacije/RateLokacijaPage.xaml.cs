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
	public partial class RateLokacijaPage : ContentPage
	{
        private WebAPIHelper lokacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Lokacija");

        private int lokacijaID { get; set; }

        public RateLokacijaPage (int selectedLokacijaID)
		{
			InitializeComponent ();

            lokacijaID = selectedLokacijaID;
            
            BindLokacija();
		}

        private void BindLokacija()
        {
            
            //random korisnik dodan zbog brzeg testiranja, promijeniti ovo!!!
            System.Net.Http.HttpResponseMessage response = lokacijaService.GetTwoParameterResponse("GetPosjetilacLokacijaByID", Global.PrijavljeniKorisnik.KorisnikID.ToString() , lokacijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var ratingList = new List<string>();


                ratingList.Add("★");
                ratingList.Add("★★");
                ratingList.Add("★★★");
                ratingList.Add("★★★★");
                ratingList.Add("★★★★★");

                picker.ItemsSource = ratingList;


                picker.TextColor = Color.Red;

                ratingPickLabel.Text = "Rating: ";
                commentInputLabel.Text = "Comment: ";

                submitBtn.Text = "Submit";

                var jsonObject = response.Content.ReadAsStringAsync();
                
                if(jsonObject.Result != "null") { 

                PosjetilacLokacija posjetilacLokacija = JsonConvert.DeserializeObject<PosjetilacLokacija>(jsonObject.Result);

                if (!String.IsNullOrEmpty(posjetilacLokacija.Comment))
                    commentInput.Text = posjetilacLokacija.Comment;

                if (posjetilacLokacija.LocationRating.HasValue)
                    picker.SelectedIndex = posjetilacLokacija.LocationRating.Value - 1;

                }
            }
            else
                DisplayAlert("error", "error", "error");
        }

        private void submitBtn_Clicked(object sender, EventArgs e)
        {

            string komentar;

            if (String.IsNullOrEmpty(commentInput.Text))
                komentar = "nullcomment";
            else
                komentar = commentInput.Text; //komentar = JsonConvert.SerializeObject(commentInput.Text);


            PosjetilacLokacija newPosjetilacLokacija = new PosjetilacLokacija
            {
                PosjetilacID = Global.PrijavljeniKorisnik.KorisnikID,
                LokacijaID = lokacijaID,
                Comment = komentar,
                LocationRating = picker.SelectedIndex + 1 //a sta ako nista ne odabere?
            };

            System.Net.Http.HttpResponseMessage response = lokacijaService
                .GetMultipleParameterResponse("UpdatePosjetilacLokacija", 
                newPosjetilacLokacija.PosjetilacID.ToString(), 
                newPosjetilacLokacija.LokacijaID.ToString(), 
                newPosjetilacLokacija.Comment, 
                newPosjetilacLokacija.LocationRating.ToString());

            if (response.IsSuccessStatusCode)
                DisplayAlert("success", "success", "ok");
            else
                DisplayAlert("error", "error", "error");
        }
    }
}