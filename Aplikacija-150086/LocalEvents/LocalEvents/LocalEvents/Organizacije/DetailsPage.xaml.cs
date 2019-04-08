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

namespace LocalEvents.Organizacije
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private WebAPIHelper organizacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Organizacija");

        private int organizacijaID {get; set;}

        public DetailsPage (int organizacijaId)
		{
			InitializeComponent ();

            organizacijaID = organizacijaId;

            BindOrganizacija();
        }

        private void BindOrganizacija()
        {
            System.Net.Http.HttpResponseMessage response = organizacijaService.GetActionResponse("GetById", organizacijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                Organizacija organizacija = JsonConvert.DeserializeObject<Organizacija>(jsonObject.Result);


                SlikaLogo.Source = ImageSource.FromStream(() => new MemoryStream(organizacija.SlikaLogo));

                NazivLabel.Text = organizacija.Naziv;

                GradLabel.Text = "City: ";
                grad.Text = organizacija.GradNaziv;

                TipLabel.Text = "Type: ";
                tip.Text = organizacija.Tip;

                OpisLabel.Text = "Description: ";
                opis.Text = organizacija.Opis;
                
                opcijeLabel.Text = "Options: ";
                rateBtn.Text = "Rate Organization";
                commentSectionBtn.Text = "Comment Section";
            }
            else
            {
                DisplayAlert("error", "error loading organizacija", "error");
            }

            //throw new NotImplementedException();
        }

        private void rateBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RateOrganizacijaPage(organizacijaID));
        }

        private void commentSectionBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Organizacije.CommentSectionPage(organizacijaID)); //dodati organizacijaID u konstruktor
        }
    }
}