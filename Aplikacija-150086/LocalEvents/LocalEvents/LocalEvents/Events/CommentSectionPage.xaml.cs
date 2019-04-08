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

namespace LocalEvents.Events
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentSectionPage : ContentPage
	{
        private WebAPIHelper eventToVisitService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/EventToVisit");
        private WebAPIHelper eventService = new WebAPIHelper(Application.Current.Resources["APIAddress"].ToString(), "api/Event");
        private int eventID { get; set; }

        public CommentSectionPage (int selectedEventID)
		{
			InitializeComponent ();

            eventID = selectedEventID;
		}

        protected override void OnAppearing()
        {
            System.Net.Http.HttpResponseMessage getCommentsResponse = eventService.GetActionResponse("GetComments", eventID.ToString());

            if (getCommentsResponse.IsSuccessStatusCode)
            {
                var jsonObject = getCommentsResponse.Content.ReadAsStringAsync();
                List<EventComment> comments = JsonConvert.DeserializeObject<List<EventComment>>(jsonObject.Result);

                titleLabel.Text = "Event Comments";

                commentsListView.ItemsSource = comments;
    
            }
            else
                DisplayAlert("error", "error", "ok");
        }

    }
}