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
	public partial class CommentSectionPage : ContentPage
	{
        private WebAPIHelper organizacijaService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Organizacija");

        private int organizacijaID { get; set; }

        public CommentSectionPage (int selectedOrganizacijaID)
		{
			InitializeComponent ();
            organizacijaID = selectedOrganizacijaID;


		}

        protected override void OnAppearing()
        {
            System.Net.Http.HttpResponseMessage response = organizacijaService.GetActionResponse("GetComments", organizacijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = response.Content.ReadAsStringAsync();
                List<OrganizacijaComment> comments = JsonConvert.DeserializeObject<List<OrganizacijaComment>>(jsonObject.Result);

                titleLabel.Text = "Komentari na organizaciju";

                commentsListView.ItemsSource = comments;

            }
            else
                DisplayAlert("error", "error", "ok");

            base.OnAppearing();
        }
    }
}