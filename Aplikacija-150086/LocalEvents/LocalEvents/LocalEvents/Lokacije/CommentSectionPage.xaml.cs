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
	public partial class CommentSectionPage : ContentPage
	{
        private WebAPIHelper lokacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Lokacija");

        private int lokacijaID { get; set; }

        public CommentSectionPage (int selectedLokacijaID)
		{
			InitializeComponent ();
            lokacijaID = selectedLokacijaID;
		}

        protected override void OnAppearing()
        {
            System.Net.Http.HttpResponseMessage response = lokacijaService.GetActionResponse("GetComments", lokacijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<LokacijaComment> comments = JsonConvert.DeserializeObject<List<LokacijaComment>>(jsonObject.Result);

                titleLabel.Text = "Komentari na organizaciju";

                commentsListView.ItemsSource = comments;

            }
            else
                DisplayAlert("error", "error", "ok");

            base.OnAppearing();
        }
    }
}