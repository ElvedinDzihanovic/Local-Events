using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCL.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCL.Models;

namespace LocalEvents.Organizacije
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RateOrganizacijaPage : ContentPage
	{
        private WebAPIHelper organizacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Organizacija");
        private int organizacijaID { get; set; }

        public RateOrganizacijaPage (int selectedOrganizacijaID)
		{
			InitializeComponent ();

            organizacijaID = selectedOrganizacijaID;

            BindOrganizacija();
		}

        private void BindOrganizacija()
        {
            //            System.Net.Http.HttpResponseMessage response = lokacijaService.GetTwoParameterResponse("GetPosjetilacLokacijaByID", Global.PrijavljeniKorisnik.KorisnikID.ToString(), lokacijaID.ToString());

            //random korisnik dodan zbog brzeg testiranja
            System.Net.Http.HttpResponseMessage response = organizacijaService.GetTwoParameterResponse("GetPosjetilacOrganizacijaByID", Global.PrijavljeniKorisnik.KorisnikID.ToString(), organizacijaID.ToString());

            if (response.IsSuccessStatusCode)
            {

                ratingPickLabel.Text = "Rate event: ";
                commentInputLabel.Text = "Comment: ";
                submitBtn.Text = "Submit";

                var ratingList = new List<string>();


                ratingList.Add("★");
                ratingList.Add("★★");
                ratingList.Add("★★★");
                ratingList.Add("★★★★");
                ratingList.Add("★★★★★");

                picker.ItemsSource = ratingList;


                picker.TextColor = Color.Red;

                //handling json response
                var jsonObject = response.Content.ReadAsStringAsync();

                if (jsonObject.Result != "null")
                {

                    PosjetilacOrganizacija posjetilacLokacija = JsonConvert.DeserializeObject<PosjetilacOrganizacija>(jsonObject.Result);

                    if (!String.IsNullOrEmpty(posjetilacLokacija.Comment))
                        commentInput.Text = posjetilacLokacija.Comment;

                    if (posjetilacLokacija.LocationRating != null)
                    {
                        picker.SelectedIndex = (posjetilacLokacija.LocationRating.Value - 1);
                    }
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

            PosjetilacOrganizacija newPosjetilacOrganizacija = new PosjetilacOrganizacija
            {
                PosjetilacID = Global.PrijavljeniKorisnik.KorisnikID,
                OrganizacijaID = organizacijaID,
                Comment = komentar,
                LocationRating = picker.SelectedIndex + 1
            };

            System.Net.Http.HttpResponseMessage response = organizacijaService
                .GetMultipleParameterResponse("UpdatePosjetilacOrganizacija", 
                newPosjetilacOrganizacija.PosjetilacID.ToString(), 
                newPosjetilacOrganizacija.OrganizacijaID.ToString(), 
                newPosjetilacOrganizacija.Comment, 
                newPosjetilacOrganizacija.LocationRating.ToString());

            if (response.IsSuccessStatusCode)
                DisplayAlert("success", "success", "ok");
            else
                DisplayAlert("error", "error", "error");
        }
    }
}